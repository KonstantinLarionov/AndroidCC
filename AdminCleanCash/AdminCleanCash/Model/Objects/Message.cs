using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancashChat2.Model.Objects
{
    class Message
    {
        public string Text { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsARead { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public string ID_Dialog { get; set; }
    }
}
