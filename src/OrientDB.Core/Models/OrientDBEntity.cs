﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Models
{
    public abstract class OrientDBEntity
    {
        public ORID ORID { get; set; }
        public int OVersion { get; set; }
        public short OClassId { get; set; }
        public string OClassName { get; set; }
        public abstract void Hydrate(IDictionary<string, object> data);
    }
}
