using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XmasPeanuts.Web.Models
{
    public class Model_general
    {
        private List<GifDisplay> _list_gift_display;
        private List<GuestDisplay> _list_guest_display;

        public List<GifDisplay> List_gift_display
        {
            get
            {
                return _list_gift_display;
            }

            set
            {
                _list_gift_display = value;
            }
        }

        public List<GuestDisplay> List_guest_display
        {
            get
            {
                return _list_guest_display;
            }

            set
            {
                _list_guest_display = value;
            }
        }
    }
}