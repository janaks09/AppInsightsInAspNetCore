using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;

namespace AppInsightsSample.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            try
            {
                TelemetryClient tc = new TelemetryClient();
                tc.TrackPageView(new PageViewTelemetry("Index page") { Timestamp = DateTime.UtcNow }); //You can set up other options too.

                throw new Exception("This is cutome exception");
                //return View();
            }
            catch (Exception ex)
            {
                TelemetryClient tc = new TelemetryClient();
                tc.TrackException(new ExceptionTelemetry(ex) { Timestamp = DateTime.UtcNow, SeverityLevel = SeverityLevel.Critical });
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
