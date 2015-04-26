(function () {
    //se.ui.control.Dialog = DialogClass;
    se.ui.module.Dialog = DialogClass;
    se.ui.module.Dialog.Settings = DialogSettings;
    function DialogClass(settings) {
        se.ui.control.Eventable.call(this);
        var _self = this;

        function _init() {
            _self.viewModel = null;

            _self.init = init;

            _self.dialog = new se.ui.control.Dialog(settings.container);

            _self.bindModel = bindModel;
        }

        function init() {
            _self.dialog.on("ok", function (sender, data) {
                var isValid = $("form", _self.dialog.container).valid();
                if (isValid) {
                    var url = $(sender).attr("request-url");
                    var model = settings.getModel();
                    save(url, model);
                }
            });

            initValidation();

            settings.initializer.call(_self);
        }

        function bindModel(model) {
            //if (this.adaptModel) {
            //    this.adaptModel(model);
            //}

            _self.viewModel = kendo.observable(model);

            if (settings.viewModelSetter) {
                settings.viewModelSetter(_self.viewModel);
            }

            kendo.bind($("form", _self.dialog.container), _self.viewModel);

        }

        function initValidation() {
            var options = {
                //ignore: "input[type!='hidden']:hidden",
                errorElement: "label",
                errorPlacement: function (place, element) {
                    var igroup = element.closest(".input-group");
                    if (igroup.length > 0) {
                        place.insertAfter(igroup);
                    } else {
                        place.insertAfter(element);
                    }
                },
                rules: {}
            };

            //var options = { rules: {} };
            var properties = $("[property-name]", _self.dialog.container);
            for (var i = 0; i < properties.length; i++) {
                var $property = $(properties[i]);
                var strRule = $property.attr("validate-rule");
                if (strRule) {
                    var rules = webExpress.utility.string.getObject(strRule);
                    var propName = $property.attr("property-name");
                    options.rules[propName] = rules;
                }
            }
            $("form", _self.dialog.container).validate(options);
        }

        function save(url, model) {
            _self.dialog.container.mask();
            webExpress.utility.ajax.request(url, model,
                function (data) {
                    _self.dialog.container.unmask();
                    if (data.IsSuccess) {
                        _self.dialog.hide();
                        _self.fire("saved", [data]);
                    } else {
                        bootbox.alert(data.Message);
                    }
                },
                function () {
                    _self.dialog.container.unmask();
                    _self.dialog.hide();
                });
        }

        _init();
    }

    function DialogSettings(settings) {
        this.container = null;

        this.getModel = function () {
            return $("form", this.container).serializeObject();
        }

        this.initializer = function () { };

        this.viewModelSetter = null;

        $.extend(this, settings);
    }
})();
