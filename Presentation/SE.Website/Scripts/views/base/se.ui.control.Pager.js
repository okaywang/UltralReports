se.ui.control.Pager = PagerClass;
function PagerClass(pagerContainer, redirectToPage) {
    this.container = pagerContainer;
    this.redirectToPage = redirectToPage;
}
PagerClass.prototype.init = function () {
    var _self = this;
    $(this.container).on("click", ".grid-pager a[pageIndex]", function () {
        var pageIndex = $(this).attr("pageIndex");
        _self.redirectToPage(pageIndex);
    });

    $(this.container).on("click", ".t-arrow-prev", function () {
        var pageIndex = _self.getCurrentPageIndex() - 1;
        _self.redirectToPage(pageIndex);
    });

    $(this.container).on("click", ".t-arrow-next", function () {
        var pageIndex = _self.getCurrentPageIndex() + 1;
        _self.redirectToPage(pageIndex);
    });
    $(this.container).on("click", ".t-arrow-last", function () {
        var pageIndex = parseInt($(this).attr("pageIndex")) - 1;
        _self.redirectToPage(pageIndex);
    });
    $(this.container).on("click", ".t-arrow-first", function () {
        _self.redirectToPage(0);
    });
    $(this.container).on("click", ".t-refresh", function () {
        _self.redirectToPage();
    });

    $(this.container).on("change", "select.pagesize", function (e) {
        _self.redirectToPage(0);
    }); 
}

PagerClass.prototype.getCurrentPageIndex = function () {
    return $(".t-state-active", this.container).text() - 1;
}
PagerClass.prototype.getPageSize = function () {
    return $("select.pagesize", this.container).val();
}
PagerClass.prototype.setPageSize = function (pagesize) {
    $("select.pagesize", this.container).val(pagesize);
}

//se.ui.control.Pager = {

//    enablePaging: function (pagerContainer, redirectToPage) {
//        $(pagerContainer).on("click", ".grid-pager a[pageIndex]", function () {
//            var pageIndex = $(this).attr("pageIndex");
//            redirectToPage(pageIndex);
//        });

//        $(pagerContainer).on("click", ".t-arrow-prev", function () {
//            var pageIndex = getCurrentPageIndex() - 1;
//            redirectToPage(pageIndex);
//        });

//        $(pagerContainer).on("click", ".t-arrow-next", function () {
//            var pageIndex = getCurrentPageIndex() + 1;
//            redirectToPage(pageIndex);
//        });
//        $(pagerContainer).on("click", ".t-arrow-last", function () {
//            var pageIndex = parseInt($(this).attr("pageIndex")) - 1;
//            redirectToPage(pageIndex);
//        });
//        $(pagerContainer).on("click", ".t-arrow-first", function () {
//            redirectToPage(0);
//        });
//        $(pagerContainer).on("click", ".t-refresh", function () {
//            redirectToPage();
//        });

//        $(pagerContainer).on("change", "select.pagesize", function (e) {
//            redirectToPage(0);
//        });

//        function getCurrentPageIndex() {
//            return $(".t-state-active", pagerContainer).text() - 1;
//        }
//    },
//    getPageSize: function () {
//        return $("select.pagesize").val();
//    },
//    setPageSize: function (pagesize) {
//        $("select.pagesize").val(pagesize);
//    }
//}