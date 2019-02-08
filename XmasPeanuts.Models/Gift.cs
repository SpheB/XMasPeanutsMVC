using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Models
{
    public class Gift
    {
        #region Fields
        private int _idGift;

        private string _title;

        private string _picture;

        private int _idGuest;
        #endregion

        #region Properties
        public int IdGift
        {
            get
            {
                return _idGift;
            }

            set
            {
                _idGift = value;
            }
        }

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
        #endregion
    }
}
