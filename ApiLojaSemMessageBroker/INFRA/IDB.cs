using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace ApiLojaSemMessageBroker.INFRA
{
    public interface IDB
    {
        IDbConnection GetDb();
    }
}
