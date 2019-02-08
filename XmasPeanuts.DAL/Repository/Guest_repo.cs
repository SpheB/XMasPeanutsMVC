using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xmas.Models;

namespace XmasPeanuts.DAL.Repository
{
    public static class Guest_repo
    {
        public static List<Guest> Get_guest()
        {
            DBConnect dbtest = new DBConnect();

            List<Dictionary<string, object>> liste_guests_brute = dbtest.Get("Guest");

            List<Guest> liste_guests = new List<Guest>();


            foreach (var item in liste_guests_brute)
            {
                Guest g = new Guest();
                g.IdGuest = (int)item["IdGuest"];
                g.FirstName = item["FirstName"].ToString();
                g.LastName = item["LastName"].ToString();
                g.BirthDate = (DateTime)item["BirthDate"];
                g.Email = item["Email"] == DBNull.Value ? null : item["Email"].ToString();
                g.IsOrganizer = (bool)item["IsOrganizer"];  //même si nullable dans la base de donnée, la valeur par défaut sera 0, donc false --> pas besoin de rendre le booléen nullable)
                g.Picture = item["Picture"].ToString();

                liste_guests.Add(g);
            }

            return liste_guests;
        }

        public static Guest GetOne_guest(int id)
        {
            DBConnect dbtest = new DBConnect();

            Dictionary<string, object> d = dbtest.GetOne(id, "Guest", "IdGuest");

            Guest g = new Guest();
            g.IdGuest = (int)d["IdGuest"];
            g.FirstName = d["FirstName"].ToString();
            g.LastName = d["LastName"].ToString();
            g.BirthDate = (DateTime)d["BirthDate"];
            g.Email = d["Email"] == DBNull.Value ? null : d["Email"].ToString();
            g.IsOrganizer = (bool)d["IsOrganizer"];  //même si nullable dans la base de donnée, la valeur par défaut sera 0, donc false --> pas besoin de rendre le booléen nullable)
            g.Picture = d["Picture"].ToString();

            return g;
        }

        public static List<Guest> GetFilter_guest(string query_where, Dictionary<string, object> parametres)
        {
            DBConnect dbtest = new DBConnect();
            string query_filter = "SELECT * FROM Guest WHERE " + query_where; //le début de la requête ne change pas, on ne doit rajouter que les conditions qu'il y a après le Where (et concatener)

            List<Dictionary<string, Object>> liste_gifts_filter_brute = dbtest.GetFilter(query_filter, parametres); //liste de Dictionnaires to be convertis en personnes

            List<Guest> liste_guests = new List<Guest>(); //liste_personnes de personne vide ou l'on mettre les new personnes créées (une par Dictionnaire de la liste)

            foreach (var item in liste_gifts_filter_brute)  //on attribue les values de chaque Dictionnaires de la liste aux propriétées d'une personne nouvellement créée (on utilise la clef/index du dictionnaire traité pour attribuer la bonne valeur à la bonne propriété (!faire correspondre les noms))
            {
                Guest g = new Guest();
                g.IdGuest = (int)item["IdGuest"];
                g.FirstName = item["FirstName"].ToString();
                g.LastName = item["LastName"].ToString();
                g.BirthDate = (DateTime)item["BirthDate"];
                g.Email = item["Email"] == DBNull.Value ? null : item["Email"].ToString();
                g.IsOrganizer = (bool)item["IsOrganizer"];  //même si nullable dans la base de donnée, la valeur par défaut sera 0, donc false --> pas besoin de rendre le booléen nullable)
                g.Picture = item["Picture"].ToString();

                liste_guests.Add(g);
            }

            return liste_guests;
        }

        public static bool Delete_guest(int id) // on connait déjà le nom de la table et de la clonne_id --> on ne doit préciser que l'id
        {
            DBConnect dbtest = new DBConnect();

            return dbtest.Delete(id, "Guest", "IdGuest");
        }

        public static bool Insert_guest(Guest g)
        {
            DBConnect dbtest = new DBConnect();

            string query_insert = @"INSERT INTO [dbo].[Guest] (FirstName, LastName, BirthDate, Email, IsOrganizer, Picture) 
                                   VALUES (@FirstName, @LastName, @BirthDate, @Email, @IsOrganizer, @Picture)"; 

            Dictionary<string, object> parametres_insert = new Dictionary<string, object>();

           
            parametres_insert.Add("@FirstName", g.FirstName); //le nom avec ou sans @, le programme comprends les deux apparemment: dans le execute, les entrées du tableau seront données (la Key en Key et la Value en Value) au SqlParameter (=Dictionnaire) qui servira à remplacer les @nom par les valeurs du tableau SqlParameter dont la clef @Nom ou Nom correspond
            parametres_insert.Add("@LastName", g.Picture);
            parametres_insert.Add("@BirthDate", g.Picture);
            parametres_insert.Add("@Email", g.Picture);
            parametres_insert.Add("@IsOrganizer", g.Picture);
            parametres_insert.Add("@Picture", g.Picture);

            return dbtest.Insert(parametres_insert, query_insert);
        }

    }
}
