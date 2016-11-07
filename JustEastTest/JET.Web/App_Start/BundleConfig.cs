using System.Web.Optimization;

namespace JET.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Javascript/Jquery and third party library
            string[] commonJsBundles = { };


            //Angular JS bundles

            string[] spaMainApp =
            {
                "~/Spa/App/app.js"
            };


            string[] spaModules =
            {
                "~/Spa/Modules/common.core.js",
                "~/Spa/Modules/common.ui.js",
            };

            string[] spaServices =
            {

            };

            string[] spaControllers =
            {

            };

            string[] spaDirectives =
            {

            };

            string[] spaFilters =
            {

            };

            string[] helpers =
            {

            };

            //main application
            bundles.Add(new ScriptBundle("~/bundles/application")
                .Include(commonJsBundles)
                .Include(spaMainApp)
                .Include(spaModules));

            //directives
            bundles.Add(new ScriptBundle("~/bundles/spa")
                .Include(spaServices)
                .Include(spaControllers)
                .Include(spaDirectives)
                .Include(spaFilters));

            //helpers

            bundles.Add(new ScriptBundle("~/bundles/helpers")
             .Include(helpers));


            // CSS BUNDLES
        }


    }
}