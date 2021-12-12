using System;
using System.Collections.Generic;
using System.Text;

namespace TestsArchitecture.Utils
{
    public class ItemInHistoryList
    {
        public string NameOfStock { get; set; }
        public string TimeOfTrade { get; set; }

        public bool Equals(ItemInHistoryList other)
        {
            return other.NameOfStock.Contains(this.NameOfStock) && other.TimeOfTrade.Contains(this.TimeOfTrade);
        }
    }
}
