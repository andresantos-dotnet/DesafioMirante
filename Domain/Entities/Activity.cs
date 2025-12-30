using Domain;
using System;
using System.Collections.Generic;

namespace Domain.Entities;

public partial class Activity : BaseEntity
{
    
    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public short TaskStatus { get; set; }

    public DateTime DueDate { get; set; }

    
}
