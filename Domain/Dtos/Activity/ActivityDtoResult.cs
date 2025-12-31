using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Dtos.Activity
{
    public class ActivityDtoResult
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public short TaskStatus { get; set; }
        public DateTime DueDate { get; set; }
    }
}
