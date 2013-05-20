using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using AutoMapper.Configuration;
using SaltoMortale.DataRepository;
using SaltoMortale.Models;
using SaltoMortale.ViewModels;

namespace SaltoMortale
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();
            InitializeAutoMapper();
        }

        protected void InitializeAutoMapper()
        {
            Mapper.CreateMap<FrontPageListItem, FrontPageViewItem>();
        }

        private static IEnumerable<FrontPageViewItem> GetFrontPageItems()
        {
            var frontPageBaseView = new FrontPageBaseView();
            frontPageBaseView.FrontPageViewItems = frontPageBaseView.FrontPageViewItems;
           
            return frontPageBaseView.FrontPageViewItems;
        }
    }
}