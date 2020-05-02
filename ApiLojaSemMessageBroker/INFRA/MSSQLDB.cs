using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLojaSemMessageBroker.INFRA
{
    public class MSSQLDB : IDB
    {
        public IDbConnection GetDb()
        {
            return new SqlConnection(@"Data Source=DESKTOP-FVILUGB\SQLEXPRESS; Database=SemMessageBroker; User Id=sa; Password=cesar123;");
        }
    }
}
