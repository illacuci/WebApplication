using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersAPI.Application.CustomExeptions
{
    public class ServiceExeption : Exception
    {
        public ServiceExeption() { }

        public ServiceExeption(string message):base (message)
        {
            
        }

        public ServiceExeption(string message, Exception inner):base(message, inner)
        {
            
        }
    }
}
