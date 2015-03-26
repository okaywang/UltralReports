(function () {
    se.ui.control.Dialog = DialogClass;
    //se.ui.control.dialog = {};
    //se.ui.control.dialog.factory = new DialogFactory();
    function DialogClass(container) {
        se.ui.control.Eventable.call(this);
        var _self = this;

        function _init() {
            _self.container = container;

            _self.show = show;

            _self.hide = hide;

            _self.save = save;

            init();
        }

        function init() {
            _self.container.find("[command-name]").click(function () {
                var data = _self.container.find("form").serializeObject();
                _self.fire("ok", [this, data]);
            });
            _self.container.on('hidden.bs.modal', function (e) {
                _self.container.find("form")[0].reset();
            });
        }

        function show() {
            _self.container.modal("show");
        }

        function hide() {
            _self.container.modal("hide");
        }

        function save(url, model) {
            _container.mask("Loading...");
            webExpress.utility.ajax.request(url, model, function (data) {
                _container.unmask();
                if (data.IsSuccess) {
                    _self.hide();
                }
                else {
                    alert(data.Message);
                }
            }, function () {
                console.log("error");
            });
        }

        _init();
    }

    function DialogFactory() {
        var _cache = {};
        var _self = this;

        function _init() {
            _self.get = get;
        }

        function get(settings) {
            if (_cache[settings.container] === undefined) {
                var dialog = new DialogClass(settings.container);
                dialog.on("ok", settings.okHandler);
                _cache[settings.container] = dialog;
            }
            return _cache[settings.container];
        }

        _init();
    }
})();
