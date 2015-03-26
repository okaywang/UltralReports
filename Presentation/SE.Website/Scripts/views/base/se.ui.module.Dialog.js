(function () {
    //se.ui.control.Dialog = DialogClass;
    se.ui.module.Dialog = DialogClass;
    function DialogClass(container) {
        se.ui.control.Eventable.call(this);
        var _self = this;

        function _init() {
            _self.init = init;

            _self.dialog = new se.ui.control.Dialog(container);

            _self.bindModel = bindModel;
        }

        function init() {
            _self.dialog.on("ok", function (sender, data) {
                var url = $(sender).attr("request-url");
                var model = $("form", _self.dialog.container).serializeObject();
                save(url, model);
            });
        }

        function bindModel(model) {
            //if (this.adaptModel) {
            //    this.adaptModel(model);
            //}

            var viewModel = kendo.observable(model);

            //if (this.adaptViewModel) {
            //    this.adaptViewModel(_self.viewModel);
            //}

            kendo.bind($("form", _self.dialog.container), viewModel);

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
})();
