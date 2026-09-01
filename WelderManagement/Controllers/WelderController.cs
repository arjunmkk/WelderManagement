using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using WelderManagement.Models;
using WelderManagement.Repository;

namespace WelderManagement.Controllers
{
    public class WelderController : Controller                  
    {//                                                                       VIEW`1q
        WelderRepository repo = new WelderRepository();
        public IActionResult Index()
        {
          
            List<Welder> welders = repo.GetAllWelders();
            return View(welders);
        }
        //                                                                  ADD FORM
        [HttpGet]
        public  IActionResult Add()
        {
            return View();
        }
        //                                                                  SAVE DATA
        [HttpPost]
        public IActionResult Add(Welder w)
        {
            repo.AddWelder(w);
            return RedirectToAction("Index");
           
        }

        [HttpGet]
        public IActionResult Edit(int WelderID)
        {
            WelderRepository repo = new WelderRepository();

            Welder w = repo.GetWelderByID(WelderID);

            return View(w);
        }

        [HttpPost]
        public IActionResult Edit(Welder w)
        {
            WelderRepository repo = new WelderRepository();

            repo.UpdateWelder(w);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult del(int WelderID)
        {
            WelderRepository repo = new WelderRepository();
            Welder w = repo.GetDeleteWelderID(WelderID);
            return View(w);
        }
        [HttpPost]
        public IActionResult del(Welder w)
        {
            WelderRepository repo = new WelderRepository();
            repo.DeleteWelder(w);
            return RedirectToAction("Index");
        }
    }
}
 