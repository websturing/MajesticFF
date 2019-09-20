using System.Web;
using System.Web.Optimization;

namespace AgentBookVue
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Content/assets/js/plugins/pickers/pickadate/picker.js",
                      "~/Content/assets/js/plugins/pickers/pickadate/picker.date.js",
                      "~/Content/assets/plugins/tables/footable/footable.min.js",
                      "~/Content/assets/plugins/Overlay/vue-Overlay.js",
                      "~/Content/assets/plugins/typehead/typehead.js",
                       "~/Content/assets/plugins/jqueryUi/jqueryUi-1.2.1.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/bootstrap.css",
                      "~/Content/assets/css/components.min.css",
                      "~/Content/assets/css/core.min.css",
                      "~/Content/assets/css/colors.css",
                      "~/Content/assets/css/icomoon/styles.css",
                      "~/Content/assets/css/animate.min.css",
                      "~/Content/assets/plugins/Overlay/vue-Overlay.css",
                      "~/Content/assets/plugins/jqueryUi/jqueryUi-1.2.1.css",
                       "~/Content/assets/plugins/typehead/typehead.css",
                      "~/Content/mff.css"));
        }
    }
}
