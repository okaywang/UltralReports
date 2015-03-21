se.view = {};
se.view.ShopAccount = {};
se.view.ShopAccount.commands = {
    resetPassword: function (model) {
        var self = this;
        bootbox.confirm("您确定将 " + model.Name + " 的密码重置为123456吗？", function (sure) {
            if (sure) {
                $(self).closest("table").performAjax("/Account/ResetPassword", { accountId: model.AccountId });
            }
        });
    },
    closeShop: function (model) {
        var self = this;
        bootbox.confirm("老板，您关店后，用户无法查看到商品，并且无法进行下单？您确定关店吗？请您三思~", function (sure) {
            if (sure) {
                $(self).closest("table").performAjax("/Shop/CloseShop", { shopId: model.ShopId });
            }
        });
    }
};

$.fn.performAjax = function (url, model) {
    var $container = $(this);
    $container.mask("Loading...");
    webExpress.utility.ajax.request(url, model,
        function (data) {
            $container.unmask();
            if (data.IsSuccess) {

            }
            else {

            }
        }, function () {
            $container.unmask();
        });
}