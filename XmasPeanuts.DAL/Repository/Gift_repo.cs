using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Models;

namespace XmasPeanuts.DAL.Repository
{
    public static class Gift_repo
    {
        public static List<Gift> Get_gift()
        {
            DBConnect dbtest = new DBConnect();

            List<Dictionary<string, object>> liste_gifts_brute = dbtest.Get("Gift");

            List<Gift> liste_gifts = new List<Gift>();


            foreach (var item in liste_gifts_brute)
            {
                Gift g = new Gift();
                g.IdGift = (int)item["IdGift"];
                //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
                //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
                //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
                g.Title = item["Title"].ToString();
                g.Picture = item["Picture"].ToString();
                g.IdGuest = (int)item["IdGuest"];

                liste_gifts.Add(g);
            }

            return liste_gifts;
        }

        public static Gift GetOne_gift(int id)
        {
            DBConnect dbtest = new DBConnect();

            Dictionary<string, object> d = dbtest.GetOne(id, "Gift", "IdGift");

            Gift g = new Gift();
            g.IdGift = (int)d["IdGift"];
            //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
            //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
            //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
            g.Title = d["Title"].ToString();
            g.Picture = d["Picture"].ToString();
            g.IdGuest = (int)d["IdGuest"];

            return g;
        }

        public static List<Gift> GetFilter_gift(string query_where, Dictionary<string, object> parametres)
        {
            DBConnect dbtest = new DBConnect();
            string query_filter = "SELECT * FROM Gift WHERE " + query_where; //le début de la requête ne change pas, on ne doit rajouter que les conditions qu'il y a après le Where (et concatener)

            List<Dictionary<string, Object>> liste_gifts_filter_brute = dbtest.GetFilter(query_filter, parametres); //liste de Dictionnaires to be convertis en personnes

            List<Gift> liste_gifts = new List<Gift>(); //liste_personnes de personne vide ou l'on mettre les new personnes créées (une par Dictionnaire de la liste)

            foreach (var item in liste_gifts_filter_brute)  //on attribue les values de chaque Dictionnaires de la liste aux propriétées d'une personne nouvellement créée (on utilise la clef/index du dictionnaire traité pour attribuer la bonne valeur à la bonne propriété (!faire correspondre les noms))
            {
                Gift g = new Gift();
                g.IdGift = (int)item["IdGift"];
                //en cas de valueur nullable dans la DB: on prends l'objet renvoyé, on regarde si sa valeur est DBNulle
                //--> si c'est le cas, on prend null comme valeur à mettre dans p.lapropriété
                //--> si ce n'est pas le cas, on prends la valeur convertie (en int, en string, en DateTime?,...)
                g.Title = item["Title"].ToString();
                g.Picture = item["Picture"].ToString();
                g.IdGuest = (int)item["IdGuest"];

                liste_gifts.Add(g);
            }

            return liste_gifts;
        }

        public static bool Delete_gift(int id) // on connait déjà le nom de la table et de la clonne_id --> on ne doit préciser que l'id
        {
            DBConnect dbtest = new DBConnect();

            return dbtest.Delete(id, "Gift", "IdGift");
        }

        public static bool Insert_gift(Gift g)
        {
            DBConnect dbtest = new DBConnect();

            string query_insert = @"INSERT INTO [dbo].[Gift] (Title, Picture, IdGuest) 
                                   VALUES (@Title, @Picture, @IdGuest)";

            Dictionary<string, object> parametres_insert = new Dictionary<string, object>();

            //on rempli le Dictionnaire nouvellement créé avec, en clé, le string qui indique quelle valeur en @ de la query sera remplacée (automatiquement) en en value, la valeur par laquelle le @... sera remplacé
            //ici cette valeur est trouvée grace aux propriétés de la Peronne p passée en paramètre
            parametres_insert.Add("@Title", g.Title); //le nom avec ou sans @, le programme comprends les deux apparemment: dans le execute, les entrées du tableau seront données (la Key en Key et la Value en Value) au SqlParameter (=Dictionnaire) qui servira à remplacer les @nom par les valeurs du tableau SqlParameter dont la clef @Nom ou Nom correspond
            parametres_insert.Add("@Picture", g.Picture);
            parametres_insert.Add("@IdGuest", g.IdGuest);


            return dbtest.Insert(parametres_insert, query_insert);
        }
    }
}
