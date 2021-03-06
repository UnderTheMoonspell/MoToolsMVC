﻿using System.Web;
using System.Web.Optimization;

namespace MoToolsMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            #region Scripts

            bundles.Add(new ScriptBundle("~/bundles/Vendors").Include(
                "~/Scripts/vendor/jquery-{version}.js",
                "~/Scripts/vendor/jquery.validate*",
                "~/Scripts/vendor/alertify.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/alertify").Include(
                "~/Scripts/vendor/alertify.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/vendor/jquery-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/vendor/jquery.validate*"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/vendor/modernizr-*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/vendor/bootstrap.js",
                "~/Scripts/vendor/respond.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Menu").Include(
                "~/Scripts/menu/menu.js",
                "~/Scripts/vendor/tree.jquery.js",
                "~/Scripts/vendor/jstree.js",
                "~/Scripts/vendor/jstree.types.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Main").Include(
                "~/Scripts/main.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Helpers").Include(
                "~/Scripts/helpers/helpers.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/Upload").Include(
                "~/Scripts/app/upload.js",
                "~/Scripts/vendor/jquery.form.min.js"
            ));

            #endregion

            #region Styles

            bundles.Add(new StyleBundle("~/CSS/SideMenu").Include(
                "~/Content/side-menu.css"
            ));

            bundles.Add(new StyleBundle("~/CSS/MoTools").Include(
                "~/Content/CloserAlertifyTheme.css",
                "~/Content/CloserDataTablesTheme.css",
                "~/Content/CloserMultiSelector.css",
                "~/Content/FormSeparators.css",
                "~/Content/site.css",
                "~/Content/top-bar.css",
                "~/Content/top-menu.css",
                "~/Content/buttons.css",
                "~/Content/NewActivities.css",
                "~/Content/MyBO.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Vendors").Include(
                "~/Content/vendor/alertify/alertify.core.css",
                "~/Content/vendor/alertify/alertify.default.css",
                "~/Content/CloserAlertifyTheme.css"
            ));

            bundles.Add(new StyleBundle("~/CSS/Upload").Include(
                "~/Content/upload.css"
            ));

            #endregion
        }
    }
}
