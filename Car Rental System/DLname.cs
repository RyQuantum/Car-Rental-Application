using System;
using System.Collections.Generic;
using System.Text;

namespace Super_market
{
    class DLname
    {
        private string str;
        private static DLname c;
        private DLname() { }

        public static DLname getInstance()
        {
            if (c == null)
            {
                c = new DLname();
                return c;
            }
            else
            {
                return c;
            }
        }
        public string Str
        {
            get
            {
                return str;
            }
            set
            {
                str = value;
            }
        }
    }
}
