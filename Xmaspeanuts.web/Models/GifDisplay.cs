using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xmas.Models;
using XmasPeanuts.DAL;
using XmasPeanuts.DAL.Repository;

namespace XmasPeanuts.Web.Models
{
    public class GifDisplay
    {
        private string _title;
        private string _picture;
        private int _idGuest;
        private string _proposeur;

        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                _title = value;
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

        public string Proposeur
        {
            get
            {
                Guest g = Guest_repo.GetOne_guest(IdGuest);
                return g.FirstName;
            }

            set
            {
                _proposeur = value;
            }
        }

        public static GifDisplay Mapper (Gift g) //on aurait pu faire une class Mappers à part mais on la met ici en static (pour qu'elle ne dépende pas d'une instanciation).
                                                 //appellée (enutilisant le nom de la class GidfDisplay.Mapper(unGiftdonné), elle renverra un GifDisplay
                                                 //on aurait aussi pu aussi mettre ici les fonction,s du CRUD en static, mais  elles sont dans un dossier à part (XmasPeanuts.Wb.Models.Repositary -> GiftDisplay_repo.cs)
        {
            return new GifDisplay
            {
                Title = g.Title,
                Picture = g.Picture,
                IdGuest = g.IdGuest
            };
        }
    }
}