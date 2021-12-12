using System;
using System.Collections.Generic;
using System.Text;

namespace TestsArchitecture.Utils
{
    public class GetStandartValueForTest
    {
        public static List<ItemInHistoryList> GetCorrectList()
        {
            return new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD (OTC)", TimeOfTrade = "00:01:00"}
            };
        }

        public static List<ItemInHistoryList> GetZerosList()
        {
            return new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD (OTC)", TimeOfTrade = "00:00:00"}
            };
        }

        public static (string, string) GetCorrectValueTimeAndCost()
        {
            return ("00:01:00", "50");
        }

        public static (string, string) GetZerosValueTimeAndCost()
        {
            return ("00:00:00", "0");
        }
    }
}
