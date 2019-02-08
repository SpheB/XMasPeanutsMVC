using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Models;
using XmasPeanuts.DAL.Repository;

namespace XmasPeanuts.Web.Models.Repository
{
    public class GiftDisplay_repo
    {
        public static List<GifDisplay> Get_gift_display() //permet de reprendre les infos (Get) de la DB en faisant appel la methode Get_gift mais en renvoyant un object List<Gift_display> adapté au traitement dans le (Home) controller et action (Index) adéquoits
        {
            List<Gift> lg = Gift_repo.Get_gift();

            List<GifDisplay> liste_gifts = new List<GifDisplay>();
                
            foreach (Gift item in lg)
            {
                GifDisplay gd = GifDisplay.Mapper(item);

                liste_gifts.Add(gd);
            }

            return liste_gifts;
        }

        public static List<GifDisplay> GetFilter_gift_display(string query_where, Dictionary<string, object> parametres)
        {
            List<Gift> lg = Gift_repo.GetFilter_gift(query_where, parametres);

            List<GifDisplay> liste_gifts = new List<GifDisplay>();

            foreach (Gift item in lg)
            {
                GifDisplay gd = GifDisplay.Mapper(item);

                liste_gifts.Add(gd);
            }

            return liste_gifts;
        }


    }
}