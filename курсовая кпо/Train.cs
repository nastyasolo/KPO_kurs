using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курсовая_кпо
{
    public class Train
    {
        public string number { get; set; }

        public string endStation { get; set; }

        public DateTime date { get; set; }

        public string timeStart { get; set; }

        public string timeEnd { get; set; }

        public string price { get; set; }

        public int availableTicket { get; set; }

        public int soldTicket { get; set; }

    }
}
