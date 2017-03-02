using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Telerik.Windows.Controls;
using TrainService.LocalData;

namespace TrainService.UiHelpers
{
    public class StationFilteringBehavior : FilteringBehavior
    {
        public override IEnumerable<object> FindMatchingItems(string searchText, IList items,
            IEnumerable<object> escapedItems, string textSearchPath, TextSearchMode textSearchMode)
        {
            var stations = items.Cast<Station>().ToArray();
            var searchTextUpper = searchText.ToUpper();
            var codeResults = new List<Station>();
            var nameResults = new List<Station>();
            var pinyinResults = new List<Station>();
            var results = new List<Station>();
            switch (textSearchMode)
            {
                case TextSearchMode.StartsWith:
                case TextSearchMode.StartsWithCaseSensitive:
                    foreach (var station in stations)
                    {
                        if (station.Code == searchTextUpper) codeResults.Add(station);
                        else if (station.Name.StartsWith(searchTextUpper)) nameResults.Add(station);
                        else if (station.PinyinInitials.StartsWith(searchTextUpper)) pinyinResults.Add(station);
                    }
                    break;
                case TextSearchMode.Contains:
                case TextSearchMode.ContainsCaseSensitive:
                    foreach (var station in stations)
                    {
                        if (station.Code == searchTextUpper) codeResults.Add(station);
                        else if (station.Name.Contains(searchTextUpper)) nameResults.Add(station);
                        else if (station.PinyinInitials.Contains(searchTextUpper)) pinyinResults.Add(station);
                    }
                    break;
            }
            results.AddRange(codeResults);
            results.AddRange(nameResults);
            results.AddRange(pinyinResults);
            return results;
        }
    }
}