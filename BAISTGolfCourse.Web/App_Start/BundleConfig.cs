using System.Web;
using System.Web.Optimization;

namespace BAISTGolfCourse.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate.min.js",
                        "~/Scripts/jquery.validate.unobtrusive.min.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/respond.js",                    
                      "~/Scripts/bootstrap-datepicker.min.js",                      
                      "~/Scripts/DataTables/jquery.dataTables.min.js",
                      "~/Scripts/DataTables/dataTables.bootstrap.min.js",
                      "~/Scripts/DataTables/dataTables.buttons.min.js",
                      "~/Scripts/DataTables/buttons.bootstrap.min.js",
                      "~/Scripts/toastr.min.js",
                      "~/Scripts/nprogress.min.js",
                      "~/Scripts/bootstrap-timepicker.js",
                      "~/Scripts/underscore-min.js",
                      "~/Scripts/jquery.steps.min.js",
                      "~/Scripts/jquery-ui.min.js",
                      "~/Scripts/fullcalendar.js",
                      "~/Scripts/generalScript.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css",
                      "~/Content/bootstrap-datepicker.min.css",
                      "~/Content/timepicker.min.css",
                      "~/Content/jquery.steps.css",
                      "~/Content/toastr.min.css",
                      "~/Content/cupertino/jquery-ui.min.css",
                      "~/Content/fullcalendar.min.css",
                      "~/Content/nprogress.css",
                      "~/Content/site.css"));

            

            bundles.Add(new StyleBundle("~/Content/dataTableCss").Include(
                      "~/Content/DataTables/css/dataTables.bootstrap.min.css",
                      "~/Content/DataTables/css/buttons.bootstrap.min.css"));
            BundleTable.EnableOptimizations = false;
        }
        
      
    }
}
