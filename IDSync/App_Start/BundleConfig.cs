using System.Web;
using System.Web.Optimization;

namespace IDSync
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/tree").Include(
                        "~/Scripts/plugins/tree/jstree.js"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/plugins").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/plugins/metis-menu/jquery.metis-menu.js",
                        "~/Scripts/plugins/slimscroll/jquery.slimscroll.js",
                        "~/Scripts/inspinia.js",
                        "~/Scripts/plugins/pace/pace.js",
                        "~/Scripts/plugins/jquery-ui/jquery-ui.js",
                        "~/Scripts/plugins/context-menu/context-menu.js",
                        "~/Scripts/plugins/xamzo/x-wrapper.js",
                        "~/Scripts/plugins/xamzo/x-validation.js",
                        "~/Scripts/plugins/xamzo/x-keycode.js",
                        "~/Scripts/plugins/xamzo/x-mask.js",
                        "~/Scripts/plugins/ampcharts/ampcharts.js",
                        "~/Scripts/plugins/ampcharts/none.js",
                        "~/Scripts/plugins/ampcharts/pie.js",
                        "~/Scripts/plugins/ampcharts/serial.js",
                        "~/Scripts/plugins/editor/editor.main.js",
                        "~/Scripts/plugins/datetimepicker/locales.js",
                        "~/Scripts/plugins/timeago/jquery.timeago.js",
                        "~/Scripts/plugins/datetimepicker/bootstrap-datetimepicker.js",
                        "~/Scripts/plugins/jqtags/script.js",
                        "~/Scripts/plugins/xamzo/x-db-schema.js",
                        "~/Scripts/alasql.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/tree").Include(
               "~/Content/plugins/tree/style.css"
               ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                 "~/Content/themes/font-awesome/css/font-awesome.css",
                 "~/Content/themes/css/bootstrap.css",
                 "~/Content/themes/plugins/iCheck/custom.css",
                 "~/Content/themes/css/animate.css",
                 "~/Content/themes/css/style.css",
                 "~/Content/themes/css/lync.css",
                 "~/Content/themes/css/responsive.css",
                 "~/Content/themes/css/progress.css",
                 "~/Content/themes/plugins/editor/editor.css",
                 "~/Content/themes/base/jquery-ui.css",
                 "~/Content/themes/plugins/toastr/toastr.css",
                 "~/Content/themes/plugins/jqTag/jquery.tagit.css"
                 ));

            bundles.Add(new StyleBundle("~/Content/editor").Include(
               "~/Content/themes/font-awesome/css/font-awesome.css",
               "~/Content/themes/plugins/editor/editor.css",
               "~/Content/themes/css/bootstrap.css"
               ));

            bundles.Add(new ScriptBundle("~/bundles/editor").Include(
                "~/Scripts/plugins/pace/pace.js",
                "~/Scripts/plugins/jquery-ui/jquery-ui.js",
                "~/Scripts/plugins/xamzo/x-wrapper.js",
                "~/Scripts/plugins/xamzo/x-validation.js",
                "~/Scripts/plugins/editor/editor.main.js"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jsupload").Include(
                        "~/Scripts/plugins/upload/iframe-transport.js",
                        "~/Scripts/plugins/upload/knob.js",
                        "~/Scripts/plugins/upload/upload.widget.js",
                        "~/Scripts/plugins/upload/fileupload.js"
                        ));
        }
    }
}