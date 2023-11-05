using System;
using System.Collections.Generic;

namespace OPBD_Lr2.indiv;

public partial class Position
{
    public long PositionId { get; set; }

    public string PositionName { get; set; } = null!;

    public double Salary { get; set; }

    public string? Responsibilities { get; set; }

    public string? Requirements { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
