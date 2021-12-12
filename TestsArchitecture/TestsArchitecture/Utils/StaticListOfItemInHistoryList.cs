using System;
using System.Collections.Generic;
using System.Text;

namespace TestsArchitecture.Utils
{
    public static class StaticListOfItemInHistoryList
    {
        public static bool EqualListsOfItemInHistoryList(this List<ItemInHistoryList> anotherItem, List<ItemInHistoryList> currectItem)
        {
            if (anotherItem.Count != currectItem.Count) return false;

            for (int i = 0; i < anotherItem.Count; i++)
            {
                if (!anotherItem[i].Equals(currectItem[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
