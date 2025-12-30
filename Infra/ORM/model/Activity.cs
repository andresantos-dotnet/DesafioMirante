using System;
using System.Collections.Generic;

namespace Infra.ORM.model;

public partial class Activity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public short TaskStatus { get; set; }

    public DateTime DueDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public DateTime CreateDate { get; set; }

    public bool Active { get; set; }
}
