using System;
using System.ComponentModel.DataAnnotations;


 /*
    Creating, updating etc. will create a new row to this log table.
 */
namespace IPBag.Models
{
    public class EventsModel
    {
        [Key]
        public int Id { get; set; }
        public int SeqId { get; set; }
        public DateTime? AFrom { get; set; }
        public DateTime? ATo { get; set; }
        public string UserEmail { get; set; }
        public string Notes { get; set; }
        public string Event { get; set; }
    }
}
