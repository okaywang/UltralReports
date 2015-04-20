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
                var url = $(sender).attr("request-url");
                var model = settings.getModel();
                save(url, model);
            });

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

        function save(url, model) {
            _self.dialog.container.mask();
            webExpress.utility.ajax.request(url, model,
                function (data) {
                    _self.dialog.container.unmask();
                    _self.dialog.hide();
                    _self.fire("saved", [data]);
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
