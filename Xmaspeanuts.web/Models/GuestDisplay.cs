using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Models;
using XmasPeanuts.Web.Models.Repository;

namespace XmasPeanuts.Web.Models
{
    public class GuestDisplay
    {
        private int _idGuest;
        private string _firstName;
        private bool _isOrganizer;
        private string _picture;
        private List<GifDisplay> list_g;

        public int IdGuest
        {
            get
            {
                return _idGuest;
            }

            set
            {
                _idGuest = value;
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                _firstName = value;
            }
        }

        public bool IsOrganizer
        {
            get
            {
                return _isOrganizer;
            }

            set
            {
                _isOrganizer = value;
            }
        }

        public string Picture
        {
            get
            {
                return _picture;
            }

            set
            {
                _picture = value;
            }
        }

        public List<GifDisplay> List_g
        {
            get
            {
                Dictionary<string, Object> parametres = new Dictionary<string, Object>();
                parametres.Add("IdGuest", IdGuest);
                string query_where = "IdGuest=@IdGuest";
                List<GifDisplay> list_g = GiftDisplay_repo.GetFilter_gift_display(query_where, parametres);
          

                return list_g;
            }

            set
            {
                list_g = value;
            }
        }

        public static GuestDisplay Mapper(Guest g) 
        {
            return new GuestDisplay
            {
                IdGuest = g.IdGuest,
                FirstName = g.FirstName,
                Picture = g.Picture,
                IsOrganizer = g.IsOrganizer
            };
        }
    }
}