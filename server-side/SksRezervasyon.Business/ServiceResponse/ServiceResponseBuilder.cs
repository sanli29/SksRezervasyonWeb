using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SksRezervasyon.Business.ServiceResponse
{
    public static class ServiceResponseBuilder
    {


        public static ServiceResultResponse<T> SuccessResponse<T>(dynamic _data)
        {
            ServiceResultResponse<T> ab = new ServiceResultResponse<T>();
            ab.data = _data;
            ab.message = "Başarılı";
            ab.status = 0;
            ab.success = true;
            return ab;
        }

        public static ServiceResultResponse<T> FailResponse<T>(string message, int error = -1)
        {
            ServiceResultResponse<T> ab = new ServiceResultResponse<T>();
            ab.message = message;
            ab.status = error;
            ab.success = false;
            return ab;
        }




    }
}
