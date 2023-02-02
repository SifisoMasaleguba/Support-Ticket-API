using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TrackingApi.Models
{
    public class SupportTicket
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public Enums.Priority Priority { get; set; }
        public Enums.SupportType SupportType { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Completed { get; set; }
    }
}
