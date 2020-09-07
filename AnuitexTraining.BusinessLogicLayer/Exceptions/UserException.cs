using System;
using System.Collections.Generic;
using System.Net;

namespace AnuitexTraining.BusinessLogicLayer.Exceptions
{
    public class UserException : Exception
    {
        public HttpStatusCode Code { get; set; }
        public List<string> Errors { get; set; }

        public UserException(HttpStatusCode code, List<string> errors)
        {
            Code = code;
            Errors = errors;
        }
    }
}