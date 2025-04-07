using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTSDomain
{
    public class TaskManager
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Status { get; set; } //Completed, Pending, No Action
        public DateTime DateCreated { get; set; } = DateTime.Today;
        public DateTime? DueDate { get; set; }
    }
}
