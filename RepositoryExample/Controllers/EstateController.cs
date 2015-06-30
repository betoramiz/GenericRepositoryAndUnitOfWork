using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ExampleRepository.Data.Infraestrucure;
using RepositoryExample.Core;
using Microsoft.AspNet.Identity.EntityFramework;

namespace RepositoryExample.Controllers
{
    [Authorize]
    public class EstateController : Controller
    {
        UnitOfWork unit;
        

        public EstateController()
        {
            unit = new UnitOfWork(new DatabaseContext());
        }

        public ActionResult Index()
        {
            List<Estate> estados = unit.EstateRepository.GetAll().ToList();
            return View(estados);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Estate estate)
        {
            var newEstate = unit.EstateRepository.Create(estate);
            if (newEstate != null)
            {
                unit.Commit();
                return RedirectToAction("Index");
            }
                
            else
                return View();
        }
    }
}
