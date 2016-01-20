using System.Web;
using System.Web.Optimization;

namespace MoToolsMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendor/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/bootstrap.js",
                      "~/Scripts/vendor/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/Menu").Include(
                    "~/Scripts/menu/menu.js",
                    "~/Scripts/vendor/tree.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/Main").Include(
                    "~/Scripts/main.js"));

            bundles.Add(new ScriptBundle("~/bundles/Helpers").Include(
          "~/Scripts/helpers/helpers.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/site.css",
                      "~/Content/side-menu.css",
                      "~/Content/top-menu.css",
                      "~/Content/top-bar.css",
                      "~/Content/buttons.css",
                      "~/Content/vendor/jqtree.cs"
                      ));


        }
    }
}
