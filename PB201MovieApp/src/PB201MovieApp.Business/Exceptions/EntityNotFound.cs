using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PB201MovieApp.Business.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public int StatusCode { get; set; }
        public EntityNotFoundException()
        {
        }

        public EntityNotFoundException (string? message) : base(message)
        {
        }

        public EntityNotFoundException(int statusCode, string? message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
