using OrientDB.ConnectionProtocols.Http.Extensions;
using OrientDB.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrientDB.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            new OrientDBConfiguration().ConnectWith.HttpProtocol<string>(null);
            
        }
    }
}
