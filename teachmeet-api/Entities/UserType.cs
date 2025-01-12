using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class UserType
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? LiveData { get; set; }
}
