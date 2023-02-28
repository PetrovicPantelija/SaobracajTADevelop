using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj.Dokumenta.TrainListItem
{
    public class TrainListItemModel
    {
        public int Id { get; set; }
        public int TrainListId { get; set; }
        public string WagonNumber { get; set; }
        public decimal WagonTare { get; set; }
        public decimal WagonLength { get; set; }
        public string UnitNumber { get; set; }
        public int Type { get; set; }
        public int UnitTare { get; set; }
        public int ADRType { get; set; }
        public decimal KG { get; set; }
        public decimal KG2 { get; set; }
        public decimal Total { get; set; }
        public decimal PCS { get; set; }
        public string InvoiceNo { get; set; }
        public decimal InvoiceValue { get; set; }
        public int ArrivalTerminal { get; set; }
        public int Customer { get; set; }
    }
}
