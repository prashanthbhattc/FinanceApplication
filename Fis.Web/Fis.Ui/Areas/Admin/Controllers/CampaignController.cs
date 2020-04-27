using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Fis.Ui.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CampaignController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult GetFilter()
        {
            return PartialView("FilterPartial");
        }

        public PartialViewResult CreateCampaign()
        {
            return PartialView("CreateCampaign");
        }
    }
}
