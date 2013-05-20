using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using SaltoMortale.DataRepository;
using SaltoMortale.ViewModels;

namespace SaltoMortale.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var baseView = new FrontPageBaseView();
            var list = XmlDataRepository.GetFrontPageItems();

            var baseList  = list.Select(Mapper.Map<FrontPageViewItem>).ToList();
            baseView.FrontPageViewItems = baseList;
            return View(baseView);

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
