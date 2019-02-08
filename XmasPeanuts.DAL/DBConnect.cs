using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasPeanuts.DAL
{
    public class DBConnect : IDBConnect
    {
        SqlCommand _oCmd; //object commande
        SqlConnection _oConn; //objet connection
        string ConnectionString = @"Server = WAD-11\SQLEXPRESS; Database = XMasDB; User Id = sa;
            Password = wad;";

        private bool Connect()  //on renvoie quelque chose pour ne pas la faire planter
        {
            //création de l'objet de connection
            _oConn = new SqlConnection(ConnectionString);

            //ouverture de la connection avec récupération de l'exception avec un try/catch
            try
            {
                _oConn.Open();
                _oCmd = new SqlCommand();
                _oCmd.Connection = _oConn;
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

        }
        private bool Disconnect()
        {

            try
            {
                _oConn.Close(); // pour entourer d'un code un truc déjà créé : Ctrl k->s
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }
        private bool Execute(string query, Dictionary<string, object> datas)
        {
            if (Connect())
            {
                //associer la requête à la demande
                _oCmd.CommandText = query;
                //remplir les paramètres
                foreach (KeyValuePair<string, object> item in datas)
                {
                    SqlParameter Sp = new SqlParameter();
                    Sp.ParameterName = item.Key;
                    Sp.Value = item.Value;
                    _oCmd.Parameters.Add(Sp);
                }




                //exécuter la requête
                _oCmd.ExecuteNonQuery();
                Disconnect();
                return true;
            }
            else
            {
                return false;
            }

        }
        private Dictionary<string, object> ReaderToDictionary(SqlDataReader Odr)
        {
            Dictionary<string, object> el = new Dictionary<string, object>();

            for (int i = 0; i < Odr.FieldCount; i++)
            {
                string Name = Odr.GetName(i);
                object valeur = Odr[i];
                el.Add(Name, valeur);
            }

            return el;
        }


        public List<Dictionary<string, object>> Get(string Nomtable)
        {
            if (Connect())
            {

                _oCmd.CommandText = string.Format(@"Select * FROM {0}", Nomtable);


                SqlDataReader Odr = _oCmd.ExecuteReader();
                List<Dictionary<string, object>> ld = new List<Dictionary<string, object>>();

                while (Odr.Read()) // au moment où on fait le read, on ramène les données du Reader(Odr) du coté C# -> en mémoire et peut l'utiliser
                {
                    ld.Add(ReaderToDictionary(Odr));

                }

                Odr.Close();

                Disconnect();
                return ld;
            }
            else
            {
                return null;
            }
        }

        public Dictionary<string, object> GetOne(int Id, string Nomtable, string nom_colonne)
        {
            if (Connect())
            {

                _oCmd.CommandText = string.Format(@"Select * FROM {0} WHERE {1} = {2}", Nomtable, nom_colonne, Id);

                SqlDataReader Odr = _oCmd.ExecuteReader();
                Dictionary<string, object> d = new Dictionary<string, object>();

                if (Odr.Read())
                {
                    d = ReaderToDictionary(Odr);

                }

                Odr.Close();

                Disconnect();
                return d;
            }
            else
            {
                return null;
            }
        }

        public List<Dictionary<string, object>> GetFilter(string query, Dictionary<string, object> parametres)
        {
            if (Connect())
            {

                //_oCmd.CommandText = string.Format(query, parametres.Values.ToArray());
                _oCmd.CommandText = query;
                foreach (KeyValuePair<string, object> item in parametres)
                {
                    _oCmd.Parameters.Add(item.Key, item.Value);
                }


                SqlDataReader Odr = _oCmd.ExecuteReader();
                List<Dictionary<string, object>> ld = new List<Dictionary<string, object>>();

                while (Odr.Read()) // au moment où on fait le read, on ramène les données du Reader(Odr) du coté C# -> en mémoire et peut l'utiliser
                {
                    ld.Add(ReaderToDictionary(Odr));

                }

                Odr.Close();

                Disconnect();
                return ld;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(int Id, string Nomtable, string NomId)
        {

            string requete = string.Format(@"Delete from {0} where {1}=@id", Nomtable, NomId);
            Dictionary<string, object> datas = new Dictionary<string, object>();
            datas.Add("@id", Id);

            return Execute(requete, datas);
        }

        public bool Insert(Dictionary<string, object> Datas, string Query)
        {
            //construire la requête sql à partir de l'objet vi(Visiteur)
            //string requete = string.Format(query, datas.Values.ToArray());


            return Execute(Query, Datas);
        }

        public bool Update(Dictionary<string, object> Datas, string Query)
        {


            //string requete = string.Format(query, datas.Values.ToArray());


            return Execute(Query, Datas);
        }
    }
}
