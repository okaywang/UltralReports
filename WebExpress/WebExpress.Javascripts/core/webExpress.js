window.webExpress = {};

webExpress.ui = {};
webExpress.ui.view = {};

webExpress.ui.control = {};

webExpress.config = {};
webExpress.config.enums = {};
  
function EnumItem(value, text) {
    this.Value = value;
    this.Text = text;
}

EnumItem.prototype.toString = function () {
    return this.Value;
}