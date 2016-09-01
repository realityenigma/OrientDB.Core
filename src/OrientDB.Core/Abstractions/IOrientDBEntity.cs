using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBEntity
    {
        ORID ORID { get; set; }
        int OVersion { get; set; }
        short OClassId { get; set; }
        string OClassName { get; set; }
        void Hydrate(IDictionary<string, object> data);
    }
}
