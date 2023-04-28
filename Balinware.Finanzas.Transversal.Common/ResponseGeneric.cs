using System;
using System.Collections.Generic;
using System.Text;

namespace Balinware.Finanzas.Transversal.Common
{
    public class ResponseGeneric<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
