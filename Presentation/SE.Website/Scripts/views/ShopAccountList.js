function ShopAccountEditModule(settings) {
    se.ui.view.EditModule.call(this, settings);
    var base = $.extend({}, this);
    var _self = this;

    function _init() {
        _self.adaptModel = adaptModel;
        _self.adaptViewModel = adaptViewModel;

        _self.init = init;
    }

    function init() {
        base.init.call(_self);

        _self.on("added", function () {
            _self.view.search();
        });

        _self.on("updated", function () {
            _self.view.refresh();
        });
    }

    function adaptModel(model) {
        webExpress.ui.control.binders.chinaAreas.buildModel(model);
    }

    function adaptViewModel(viewModel) {
        webExpress.ui.control.binders.chinaAreas.buildViewModel(viewModel);
    }

    _init();
}