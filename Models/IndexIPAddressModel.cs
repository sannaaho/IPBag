using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IPBag.Models
{
    public class IndexIPAddressModel
    {
        public int Id { get; set; }
        public int SeqId { get; set; }
        public string IPAddessSegment { get; set; }
        public string AFrom { get; set; }
        public string ATo { get; set; }
        public string UserEmail { get; set; }
        public string Notes { get; set; }

    }
}
