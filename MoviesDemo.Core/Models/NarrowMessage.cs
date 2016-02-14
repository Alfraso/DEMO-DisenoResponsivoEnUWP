using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoviesDemo.Models
{
    public class NarrowMessage 
    {
        public NarrowMessage(string senderView, bool isNarrow) 
        {
            IsNarrow = isNarrow;
            SerderView = senderView;
        }

        public bool IsNarrow { get; set; }

        public string SerderView { get; set; }
    }
}
