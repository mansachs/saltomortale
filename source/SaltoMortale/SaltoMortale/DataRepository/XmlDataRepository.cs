using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;
using SaltoMortale.Models;

namespace SaltoMortale.DataRepository
{
    public static class XmlDataRepository
    {
        public static IEnumerable<FrontPageListItem> GetFrontPageItems()
        {
            var filePath = Path.Combine(HostingEnvironment.ApplicationPhysicalPath, @"App_Data\FrontPageData.xml");

            var xDocument = XDocument.Load(filePath);

            IEnumerable<XElement> elements = null;

            if(xDocument.Root != null)
                elements = xDocument.Root.Elements("Item");

            var list = new  List<FrontPageListItem>();

            if (elements != null)
                list.AddRange(elements.Select(element => new FrontPageListItem {Title = (string)element.Element("Title"), ImageUrl = (string)element.Element("ImageUrl"), TeaserText = (string)element.Element("TeaserText"), ButtonText = (string)element.Element("ButtonText")}));

            return list;
        }
    }
}