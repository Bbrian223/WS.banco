using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Responce
{
    public class ApiResponce<T>
    {
        public bool status { get; private set; }
        public string? msg { get; private set; }
        public T? data { get; private set; }
        //public int statusCode { get; private set; }   ==> a futuro

        public void Success( T? data, string msg = "Operacion realizada exitosamente") 
        {
            this.status = true;
            this.msg = msg;
            this.data = data;
        }

        public void Error(string msg = "Error generado durante la operacion") 
        {
            this.status = false;
            this.msg = msg;
            this.data = default;
        }

    }
}
