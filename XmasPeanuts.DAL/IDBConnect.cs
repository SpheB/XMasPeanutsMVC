using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmasPeanuts.DAL
{
    interface IDBConnect
    {
        List<Dictionary<string, object>> Get(string Nomtable);

        Dictionary<string, object> GetOne(int Id, string Nomtable, string nom_colonne);

        List<Dictionary<string, object>> GetFilter(string query, Dictionary<string, object> parametres);

        bool Insert(Dictionary<string, object> d, string query);

        bool Update(Dictionary<string, object> d, string query);

        bool Delete(int Id, string Nomtable, string NomId);
    }
}
