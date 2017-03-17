using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Demo.Helper;
using Demo.Helper.External;

namespace WebApplication1.Controllers
{
    public class DemoUsingXMLController : Controller
    {
        // GET: DemoUsingXML
        public ActionResult Index()
        {
            XMLReader readXML = new XMLReader();
            var data = readXML.ReturnListOfProducts();
            return View(data.ToList());

            }
        }
    }
