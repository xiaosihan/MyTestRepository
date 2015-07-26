using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GitTest.Models
{
    public class Result
    {
        public int ReturnCode { get; set; }

        public string ReturnMessage { get; set; }

        public string ReturnBody { get; set; }
    }
}