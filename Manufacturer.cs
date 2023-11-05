using System;
using System.Collections.Generic;

namespace OPBD_Lr2.indiv;

public partial class Manufacturer
{
    public long ManufacturerId { get; set; }

    public string ManufacturerName { get; set; } = null!;

    public string ManufacturerCountry { get; set; } = null!;

    public string ManufacturerAddress { get; set; } = null!;

    public long? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
