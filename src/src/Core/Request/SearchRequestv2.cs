using Featurify.Core.Enums;

namespace Featurify.Core.Request
{
    public class SearchRequestv2
    {
        public string Name { get; set; }
        public SearchEnum SearchType { get; set; }
        public int OffSet { get; set; }
        public SearchRequestv2() { }
        public SearchRequestv2(string name, SearchEnum searchType, int offSet)
        {
            Name = name;
            SearchType = searchType;
            OffSet = offSet;
        }
    }
}
