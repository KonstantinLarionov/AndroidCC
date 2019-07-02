using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancashChat2.Model.Objects
{
    class Header
    {
        public string NameUser { get; set; }
        public string ID { get; set; }
        public DateTime LastDateMessage { get; set;}
        public string LastMessage { get; set; }
    }
}
