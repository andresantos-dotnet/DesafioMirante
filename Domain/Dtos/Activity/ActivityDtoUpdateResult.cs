using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoUpdateResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public short TaskStatus { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
