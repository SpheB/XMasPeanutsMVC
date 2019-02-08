using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xmas.Models;
using XmasPeanuts.Web.Models;
using XmasPeanuts.Web.Models.Repository;

namespace XmasPeanuts.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            Model_general mg = new Model_general();

            mg.List_gift_display = GiftDisplay_repo.Get_gift_display(); //Set la List_gift_display du Model_g (met la liste de 
            mg.List_guest_display = GuestDisplay_repo.Get_guest_display();

            return View(mg);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";  //pour l'afficher, sur la View, faire appel à @Viewbag.Message

            return View();
        }

        public ActionResult ListeGift(int Id) //reçoit parce que dans le <a> de redirection dans l'Index, , on a réjouter le Guest en question, qu'il récupère donc ("~Home/ListeGifts/@item.IdGuest")
        {
            ViewBag.Message = "Your GiftList page.";

            GuestDisplay gd = GuestDisplay_repo.Get_one_guest_display(Id);

            return View(gd);
        }
    }
}