using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.ServiceResponse
{
    public abstract class ServiceResponse
    {
        public bool success { get; set; }

        public int status { get; set; }

        public string message { get; set; }

    }
}
