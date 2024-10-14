using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WebApplication1.Appcode
{
    public class DBConnection 
    {
        public DBConnection TransDbConn;

        internal void CloseConnection()
        {
            throw new NotImplementedException();
        }

        internal void Dispose()
        {
            throw new NotImplementedException();
        }

        internal object ExecuteDataSet(string query, CommandType text)
        {
            throw new NotImplementedException();
        }

        internal void OpenConnection()
        {
            throw new NotImplementedException();
        }
    }
}