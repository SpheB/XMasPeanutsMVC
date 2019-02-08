using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xmas.Models
{
    public class Guest
    {
        #region Fields
        private int _idGuest;
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;
        private string _email;
        private bool _isOrganizer;
        private string _picture;
        #endregion

        #region Properties
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

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDate;
            }

            set
            {
                _birthDate = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
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
       
        public List<Gift> Gifts
        {
            get;
            set;
        }
        #endregion

    }
}
