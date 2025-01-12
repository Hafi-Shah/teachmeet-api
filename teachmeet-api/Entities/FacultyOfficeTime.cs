using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class FacultyOfficeTime
{
    public int Id { get; set; }

    public int FacId { get; set; }

    public int OfficeTimeId { get; set; }

    public int? LiveData { get; set; }
}
