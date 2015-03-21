(function () {
    webExpress.ui.control.binders = new BindersClass();
    webExpress.ui.control.binders.nativeTextbox = new NativeTextboxBinderClass();
    webExpress.ui.control.binders.nativeRadiobutton = new NativeRadiobuttonBinderClass();
    webExpress.ui.control.binders.chinaAreas = new ChinaAreasBinderClass();
    function BindersClass() {
        var _self = this;
        function _init(){
            _self.get = get;
        }
        function get(controlType) {
            if (controlType == "NativeTextbox") {
                return webExpress.ui.control.binders.nativeTextbox;
            } else if (controlType == "ChinaAreas") {
                return webExpress.ui.control.binders.chinaAreas;
            } else if (controlType == "NativeRadiobutton")
                return webExpress.ui.control.binders.nativeRadiobutton;
        }

        _init();
    }

    function NativeTextboxBinderClass() {
        var _self = this;
        function _init() {
            _self.build = build;
        }
        function build($property) {
            var control = $property.find("*").andSelf().filter(":text");
            var propName = $property.attr("property-name");
            var expression = $(control).attr("data-bind");
            expression = "value:" + propName;
            $(control).attr("name", propName);
            $(control).attr("data-bind", expression);
        }
        _init();
    }

    function NativeRadiobuttonBinderClass() {
        var _self = this;
        function _init() {
            _self.build = build;
        }
        function build($property) {
            var controls = $property.find("*").andSelf().filter(":radio");
            var propName = $property.attr("property-name");
            for (var i = 0; i < controls.length; i++) {
                var control = controls[i];
                var expression = $(control).attr("data-bind");
                expression = "checked:" + propName;
                $(control).attr("name", propName);
                $(control).attr("data-bind", expression);
            }
        }
        _init();
    }

    function ChinaAreasBinderClass() {
        var _self = this;
        function _init() {
            _self.build = build;

            _self.buildModel = buildModel;

            _self.buildViewModel = buildViewModel;
        }
        function build($property) {
            var provinceControl = $("[name='ProvinceId']", $property);
            var cityControl = $("[name='CityId']", $property);
            var countyControl = $("[name='CountyId']", $property);
            provinceControl.attr("data-bind", "value:ProvinceId,source:SourceProvinces");
            provinceControl.attr("data-value-field", "Value");
            provinceControl.attr("data-text-field", "Text");

            cityControl.attr("data-bind", "value:CityId,source:SourceCities");
            cityControl.attr("data-value-field", "Value");
            cityControl.attr("data-text-field", "Text");

            countyControl.attr("data-bind", "value:CountyId,source:SourceCounties");
            countyControl.attr("data-value-field", "Value");
            countyControl.attr("data-text-field", "Text");
        }

        function buildModel(model) {
            if (!model) {
                model = {
                    ProvinceId: "",
                    CityId: "",
                    CountyId: ""
                };
            }
            model.SourceProvinces = webExpress.data.china.getProvinces();
            if (model.ProvinceId > 0) {
                model.SourceCities = webExpress.data.china.getCities(model.ProvinceId);
            }
            else {
                model.SourceCities = [{ Value: "", Text: "未填" }];
            }

            if (model.CityId > 0) {
                model.SourceCounties = webExpress.data.china.getCounties(model.CityId);
            }
            else {
                model.SourceCounties = [{ Value: "", Text: "未填" }];
            }
        }

        function buildViewModel(viewModel) {
            viewModel.bind("change", function (item) {
                if (item.field == "ProvinceId") {
                    var cities = webExpress.data.china.getCities(viewModel.ProvinceId);
                    if (cities.length == 0) {
                        cities = [{ Value: "", Text: "未填" }];
                    }
                    viewModel.set("SourceCities", cities);
                    if (cities.length == 2) {
                        viewModel.set("CityId", cities[1].Value);
                    }
                    else {
                        viewModel.set("CityId", 0);
                    }
                }

                if (item.field == "CityId") {
                    var counties = webExpress.data.china.getCounties(viewModel.CityId);
                    if (counties.length == 0) {
                        counties = [{ Value: "", Text: "未填" }];
                    }
                    viewModel.set("SourceCounties", counties);
                    viewModel.set("CountyId", 0);
                }
            });
        }
        _init();
    }
})();