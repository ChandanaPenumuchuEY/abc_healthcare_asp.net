using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace abc_healthcare.Models
{
    public class Medicine
    {
        public int id { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string image { get; set; }
        public string seller { get; set; }
        public string description { get; set; }
    }
}
