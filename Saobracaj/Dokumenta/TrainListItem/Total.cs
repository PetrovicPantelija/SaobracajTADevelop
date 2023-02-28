using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saobracaj.Dokumenta.TrainListItem
{
    internal class Total
    {
        private List<TrainListItemModel> itemList;
        public int TotalUnitTare { get; set; } = 0;
        public decimal TotalGoods { get; set; } = 0;
        public decimal TotalWagonTare { get; set; } = 0;
        public decimal TotalWeight { get; set; } = 0;
        public decimal TotalTrainLength { get; set; } = 0;

        public Total(List<TrainListItemModel> itemList, int id_sup)
        {
            foreach (TrainListItemModel obj in itemList)
            {
                if (obj.TrainListId == id_sup)
                {
                    TotalUnitTare += obj.UnitTare;
                    TotalGoods += obj.KG2;
                    TotalWagonTare += obj.WagonTare;
                    TotalWeight += obj.Total;
                    TotalTrainLength += obj.WagonLength;
                }
            }
        }
    }
}
