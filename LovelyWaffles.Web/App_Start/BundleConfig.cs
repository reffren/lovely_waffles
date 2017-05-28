using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace LovelyWaffles.Web.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/bundles/css/site").Include("~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/css/bootstrap").Include("~/Content/bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/galleryScript1").Include("~/Scripts/Gallery/jquery.fancybox.js"));
            bundles.Add(new ScriptBundle("~/bundles/galleryScript2").Include("~/Scripts/Gallery/galleryScript.js"));
        }
    }
}