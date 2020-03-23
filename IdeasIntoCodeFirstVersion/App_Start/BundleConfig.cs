﻿using System.Web;
using System.Web.Optimization;

namespace IdeasIntoCodeFirstVersion
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(                       
                         "~/Scripts/jquery.signalR-2.4.1.js", 
                          "~/Scripts/typeahead.bundle.js",
                          "~/Scripts/jquery-{version}.js",
                          "~/Scripts/bootstrap.js",
                          "~/Scripts/bootbox.js",
                          "~/Scripts/datatables/jquery.datatables.js",
                           "~/Scripts/underscore.min.js",
                          "~/Scripts/datatables/datatables.bootstrap.js"                          
                          ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                         "~/Scripts/popper.js",
                        "~/Scripts/popper.min.js",
                         "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(                       
                      "~/Content/typeahead.css",
                       "~/Content/style.css",
                       "~/Content/ fontawesome.css",
                      
                      "~/Content/bootstrap.css",
                       "~/Content/animate.css"
                      /*"~/Content/site.css"*/));
        }
    }
}
