using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleancashChat2.Model.Objects
{
    class Dialog
    {
        public List<Message> Messages { get; set; }
        public Header Header { get; set; }

        public int NewMessage { get; set; }
    }
}
