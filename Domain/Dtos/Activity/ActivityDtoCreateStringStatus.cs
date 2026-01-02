using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoCreateStringStatus
    {
        [Required]
        [StringLength(150)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [Required]
        public string TaskStatus { get; set; }  // ← agora é string

        [Required]
        public DateTime DueDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
