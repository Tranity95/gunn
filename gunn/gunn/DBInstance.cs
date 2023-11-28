using System;
using System.Collections.Generic;
using System.Text;

namespace gunn
{
    public class DBInstance
    {
        private static DB db;
        public static DB GetInstance()
        {
            if (db == null)
            {
                db = new DB();
            }
            return db;
        }
    }
}
