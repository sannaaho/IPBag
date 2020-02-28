using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace IPBag.Models
{
    public class IndexModel
    {
        public List<SelectListItem> items { get; set; }
        public bool OnHoldFilter { get; set; }
        public string IPFilter { get; set; }
        public string UserFilter { get; set; }
        public string SortOrder { get; set; }
        public string UserSortParm { get; set; }
        public string DateSortParm1 { get; set; }
        public string DateSortParm2 { get; set; }

        public List<IndexIPAddressModel> Ipaddresses { get; set; }

    }
}
