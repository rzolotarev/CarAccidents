using Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Contracts.Db
{
    public interface IDbProvider
    {
        IEnumerable<Accident> GetCarAccidents();
    }
}
