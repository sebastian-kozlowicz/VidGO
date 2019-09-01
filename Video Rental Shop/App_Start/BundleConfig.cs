using System.Web;
using System.Web.Optimization;

namespace Video_Rental_Shop
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery.datatables").Include(
                     "~/Scripts/datatables/jquery.datatables.js",
                     "~/Scripts/datatables/datatables.bootstrap.js")); ;

            bundles.Add(new ScriptBundle("~/bundles/toastr").Include(
                  "~/Scripts/toastr.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/jquery-ui").Include(
                      "~/Content/jquery-ui.css"));
        }
    }
}
