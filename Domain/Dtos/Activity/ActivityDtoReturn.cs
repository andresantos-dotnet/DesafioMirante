using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoReturn
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TaskStatus { get; set; } // ← string no retorno
        public DateTime DueDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
