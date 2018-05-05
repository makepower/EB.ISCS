using System.Web;
using System.Web.Optimization;

namespace EB.ISCS.Admin
{
    public class BundleConfig
    {
        // 有关绑定的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkId=301862

        public static void RegisterBundles(BundleCollection bundles)
        {
            //基本的css
            StyleBundle css = new StyleBundle("~/Content/css");
            ScriptBundle scripts = new ScriptBundle("~/bundles/jquery");

            css.Include(
                "~/Scripts/jqGrid/css/ui.jqgrid-bootstrap.css"
                , "~/Content/easyui/themes/bootstrap/easyui.css"
                , "~/Content/easyui/themes/icon.css"
            );


            scripts.Include(
                "~/Scripts/jqGrid/i18n/grid.locale-cn.js",
                "~/Scripts/jqGrid/plugins/jquery.contextmenu.js",
                "~/Scripts/jQuery/w5cValidator.js",
                "~/Scripts/jQuery/jquery.cookie.js",
                "~/Scripts/jquery-easyui-1.4.5/jquery.easyui.min.js",
                "~/Scripts/easyui/jquery.easyui.min.js",
                "~/Scripts/bootstrap/js/bootstrap.min.js",
                "~/ViewScript/ZhiDun.framework.js",
                "~/ViewScript/common/dataGrid.js"
  
            );
            bundles.Add(css);
            bundles.Add(scripts);

            bundles.Add(new StyleBundle("~/LayoutHeader/css").Include(
                   "~/Content/font-awesome/font-awesome.min.css",
                   "~/Content/ionicons/ionicons.min.css",
                   "~/Content/adminlte/AdminLTE.min.css",
                   "~/Content/adminlte/skins/skin-blue.min.css",
                   "~/Scripts/bootstrap/css/bootstrap.min.css",
                   "~/Scripts/bootstrap/css/Site.css",
                   "~/Content/page-tab/page-tab.min.css",
                   "~/Scripts/layer/skin/layer.css"
           ));

            bundles.Add(new ScriptBundle("~/LayoutHeader/js").Include(
                  "~/Scripts/jQuery/jquery-1.11.0.min.js",
                  "~/Scripts/angular/angular.js",
                  "~/Scripts/bootstrap/js/bootstrap.js",
                  "~/ViewScript/common/commonService.js",
                  "~/ViewScript/common/commonControl.js",
                  "~/Scripts/adminlte/app.min.js",
                  "~/Scripts/page-tab/contabs.min.js",
                  "~/Scripts/slimScroll/jquery.slimscroll.min.js",
                  "~/Scripts/jqGrid/jquery.jqGrid.min.js",
                  "~/Scripts/fastclick/fastclick.js",
                  "~/Scripts/adminlte/demo.js",
                  "~/Scripts/daterangepicker/daterangepicker.js",
                  "~/Scripts/datepicker/bootstrap-datepicker.js",
                  "~/Scripts/datepicker/locales/bootstrap-datepicker.zh-CN.js",
                  "~/Scripts/layer/layer.js"
           ));
        }
    }
}
