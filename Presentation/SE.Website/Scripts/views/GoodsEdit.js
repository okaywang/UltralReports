
(function () {
    se.ui.view.GoodsEdit = GoodsEditClass;
    se.ui.view.GoodsEdit.Settings = GoodsEditSettings;
    function GoodsEditClass(settings) {
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
                bootbox.alert("保存成功", function () {
                    location.href = location.href;
                });
            });

            _self.on("updated", function () {
                bootbox.alert("保存成功", function () {
                    location.href = location.href;
                });
            });
        }

        function ensureBrandExist(model) {
            var type = webExpress.utility.array.find(model.Types, function (item) {
                return item.Id == model.Goods.SkuTypeId;
            });
            var isExist = webExpress.utility.array.exist(type.Brands, function (item) {
                return item.BrandId == model.Goods.BrandId;
            });
            if (!isExist) {
                type.Brands.unshift({ Value: model.Goods.BrandId, Text: model.Goods.BrandName });
            }
        }

        function adaptModel(model) {
            model.Types = getSkuTypes(model.Categories, model.Goods.CategoryId);
            model.Brands = getBrands(model.Types, model.Goods.SkuTypeId);
            if (model.Goods.BrandId > 0) {
                ensureBrandExist(model);
            }
            console.log(model);
        } 

        function adaptViewModel(viewModel) {
            viewModel.bind("change", function (item) {
                if (item.field == "Goods.CategoryId") {
                    var skuTypes = getSkuTypes(viewModel.Categories, viewModel.Goods.CategoryId);
                    viewModel.set("Types", getNewItems(skuTypes));
                }
                else if (item.field == "Goods.SkuTypeId") {
                    var skuTypes = getSkuTypes(viewModel.Categories, viewModel.Goods.CategoryId);
                    var brands = getBrands(skuTypes, viewModel.Goods.SkuTypeId);
                    viewModel.set("Brands", getNewItems(brands));
                }
            });

        }

        function getBrands(types, typeId) {
            var type =  $.grep(types, function (element, index) {
                return element.Id == typeId;
            })[0];
            if (type) {
                return type.Brands;
            }
            return [];
        }

        function getSkuTypes(categoryies, categoryId) {
            var category = $.grep(categoryies, function (element, index) {
                return element.Id == categoryId;
            })[0];
            if (category) {
                return category.SkuTypes;
            }
            return [];
        }

        function getNewItems(items) {
            var newItems = items.slice(0);
            newItems.unshift({ Id: "", Name: "未选择", Value: "", Text: "未选择" });
            return newItems;
        }

        _init();
    }

    function GoodsEditSettings(settings) {
        se.ui.view.EditModule.Settings.call(this, settings);
    }
})();
