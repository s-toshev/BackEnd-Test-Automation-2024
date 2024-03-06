using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpTestingProjectDemo
{
    public class Issue
    {
        public long Id {  get; set; }
        public int Number { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

      
    }
}
