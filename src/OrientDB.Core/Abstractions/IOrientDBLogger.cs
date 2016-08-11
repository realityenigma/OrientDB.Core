using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Core.Abstractions
{
    public interface IOrientDBLogger
    {
        void Debug(string message);
        void Information(string message);
        void Verbose(string message);
        void Error(string message);
        void Fatal(string message);
        void Warning(string message);
    }
}
