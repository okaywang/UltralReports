
(function () {
    se.ui.view.ShopEdit = ShopEditClass;
    se.ui.view.ShopEdit.Settings = ShopEditSettings;
    function ShopEditClass(settings) {
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

            _self.on("updated", function () {
                bootbox.alert("保存成功", function () {
                    location.href = location.href;
                });
            });


            var module = new CommunitySelectModule({
                container: $(".community-selector"),
                activate: function () {
                    $('ul.nav li:first a', this.container).tab("show")
                    $('ul.nav:eq(1) li:first a', this.container).tab("show")
                    $(".modal", this.container).modal("show");
                },
                inactivate: function () {
                    $(".modal", this.container).modal("hide");
                }
            });
            module.init();
            $(".btn-community-selector-multiple").click(function () {
                module.activate();
                var values = $.map(_self.viewModel.DeliveryCommunities, function (item) { return item.Value; });
                module.setCommunities(values);
                module.okHandler = function () {
                    var communities = module.getCommunities();
                    _self.viewModel.set("DeliveryCommunities", communities);
                    module.inactivate();
                }
            });
            $(".btn-community-selector-single").click(function () {
                module.activate();
                var items = []
                if (_self.viewModel.LocalCommunity) {
                    items = [_self.viewModel.LocalCommunity.Value];
                }
                module.setCommunities(items);
                module.okHandler = function () {
                    var communities = module.getCommunities();
                    if (communities.length > 1) {
                        alert("只能选择一个社区");
                        return;
                    }
                    _self.viewModel.set("LocalCommunity", communities[0]);
                    module.inactivate();
                }
            });
        }

        function adaptModel(model) {
            if (model.OpeningTime) {
                model.OpeningTime = formatTimePart(model.OpeningTime.Hours) + ":" + formatTimePart(model.OpeningTime.Minutes);
            }
            if (model.ClosingTime) {
                model.ClosingTime = formatTimePart(model.ClosingTime.Hours) + ":" + formatTimePart(model.ClosingTime.Minutes);
            }
            webExpress.ui.control.binders.chinaAreas.buildModel(model);

        }

        function adaptViewModel(viewModel) {
            webExpress.ui.control.binders.chinaAreas.buildViewModel(viewModel);
        }

        function formatTimePart(n) {
            return ("0" + n).slice(-2);
        }


        _init();
    }

    function ShopEditSettings(settings) {
        se.ui.view.EditModule.Settings.call(this, settings);
    }

    function CommunitySelectModule(settings) {
        se.ui.view.Module.call(this, settings);
        var _self = this;

        function _init() {
            _self.init = init;
            _self.okHandler = function () { };
            _self.setCommunities = setCommunities;
            _self.getCommunities = getCommunities;
        }

        function init() {
            $(":checkbox", this.container).change(function () {
                displaySelectedItems();
            });

            $(".btn-ok", this.container).click(function () {
                var items = getCommunities();
                _self.okHandler.call(this, items);
            });

            $('ul.county a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                $(".tab-pane:visible ul li a:first").tab("show");
            })

            //$('ul.county a[data-toggle="tab"]').on("mouseenter", function (e) {
            //    $(e.currentTarget).tab("show");
            //});
        }

        function setCommunities(ids) {
            $(":checkbox", this.container).prop("checked", false);
            for (var i = 0; i < ids.length; i++) {
                var id = ids[i];
                var control = $(":checkbox[value=" + id + "]");
                control.prop("checked", true);
            }
            displaySelectedItems();
        }

        function getCommunities() {
            var communities = $(":checkbox:checked", this.container);
            return $.map(communities, function (elementOfArray, indexInArray) {
                return {
                    Value: $(elementOfArray).val(),
                    Text: $.trim($(elementOfArray).parent().text())
                };
            });
        }

        function displaySelectedItems() {
            var communities = getCommunities();
            var strs = $.map(communities, function (item, index) {
                return item.Text;
            });
            $(".selected-items", this.container).text(strs.join(" , "));
        }

        _init();
    }
})();
