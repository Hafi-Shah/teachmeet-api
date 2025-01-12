using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class OfficeTiming
{
    public int Id { get; set; }

    public string? Day { get; set; }

    public TimeOnly? StartTime { get; set; }

    public TimeOnly? EndTime { get; set; }
}
