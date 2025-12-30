using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ActivityEntity: BaseEntity
    {
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public short TaskStatus { get; set; }

        public DateTime DueDate { get; set; }
       
    }


}
