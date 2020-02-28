using System;
using System.ComponentModel.DataAnnotations;

/*
    CodeFirst DB table.
*/
namespace IPBag.Models
{
    public class IPv4Addresses
    {
        [Key]
        public int Id { get; set; }
        public int SeqId { get; set; }
        public string IpaddressSeqment { get; set; }
        public DateTime? AFrom { get; set; }
        public DateTime? ATo { get; set; }
        public string UserEmail { get; set; }
        public string Notes { get; set; }

    }
}
