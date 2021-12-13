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
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"}
            };
        }

        public static List<ItemInHistoryList> GetZerosList()
        {
            return new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:00:00"}
            };
        }

        public static (string Time, string Cost) GetCorrectValueTimeAndCost()
        {
            return ("00:01:00", "50");
        }

        public static (string Time, string Cost) GetZerosValueTimeAndCost()
        {
            return ("00:00:00", "0");
        }

        public static (string Time, string Cost) GetNegativeValueFromCostAndNotCorrectFromTime()
        {
            return ("01:99:00", "-100");
        }

        public static List<ItemInHistoryList> GetMultiClickList()
        {
            return new List<ItemInHistoryList>()
            {
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"},
                new ItemInHistoryList() {NameOfStock = "AUD/CAD", TimeOfTrade = "00:01:00"}
            };
        }
    }
}
