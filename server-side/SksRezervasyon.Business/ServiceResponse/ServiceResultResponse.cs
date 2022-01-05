using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.ServiceResponse
{
    public class ServiceResultResponse<T> : ServiceResponse
    {
        public T data { get; set; }
    }
}
