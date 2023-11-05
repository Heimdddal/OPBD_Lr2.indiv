using System;
using System.Collections.Generic;

namespace OPBD_Lr2.indiv;

public partial class Employee
{
    public long EmployeeId { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? Patronymic { get; set; }

    public string BirthDate { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public string PassportSeries { get; set; } = null!;

    public string PassportNumber { get; set; } = null!;

    public long? PositionId { get; set; }

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();

    public virtual Position? Position { get; set; }
}
