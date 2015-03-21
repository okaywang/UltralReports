
function ActivityEditModule(settings) {
    se.ui.view.EditModule.call(this, settings);
    var base = $.extend({}, this);
    var _self = this;

    function _init() {
        

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

    

    _init();
}

