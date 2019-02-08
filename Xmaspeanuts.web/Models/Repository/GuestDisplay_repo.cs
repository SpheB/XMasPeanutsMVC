using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Models;
using XmasPeanuts.DAL.Repository;

namespace XmasPeanuts.Web.Models.Repository
{
    public class GuestDisplay_repo
    {
        public static List<GuestDisplay> Get_guest_display() //permet de reprendre les infos (Get) de la DB en faisant appel la methode Get_gift mais en renvoyant un object List<Gift_display> adapté au traitement dans le (Home) controller et action (Index) adéquoits
        {
            List<Guest> lg = Guest_repo.Get_guest();

            List<GuestDisplay> liste_guest_display = new List<GuestDisplay>();

            foreach (Guest item in lg)
            {
                GuestDisplay gd = GuestDisplay.Mapper(item);

                liste_guest_display.Add(gd);
            }

            return liste_guest_display;
        }

        public static GuestDisplay Get_one_guest_display(int id) //permet de reprendre les infos (Get) de la DB en faisant appel la methode Get_gift mais en renvoyant un object List<Gift_display> adapté au traitement dans le (Home) controller et action (Index) adéquoits
        {
            Guest g = Guest_repo.GetOne_guest(id);

            GuestDisplay guest_display = GuestDisplay.Mapper(g);

            return guest_display;

        }
    }
}