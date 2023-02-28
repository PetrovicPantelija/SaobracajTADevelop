using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj.Dokumenta.TrainList
{
    public class TrainListModel
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public string TrainNo { get; set; }
        public string Note { get; set; }
    }
}

