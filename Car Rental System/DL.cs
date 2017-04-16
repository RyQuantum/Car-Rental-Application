using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Super_market
{
    class DL
    {
        private static DL c;
        private DL()
        { 
        }
        public static DL getIns()
        {
            if (c==null)
            {
                c = new DL();
                return c;
            }
            else
            {
                return c;
            }
        }
        private int num = 0;
        public int Num
        {
            get
            {
                return num;
            }
            set 
            {
                num = value;
            }
        }
    }
}
