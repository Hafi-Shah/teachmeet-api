using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class Title
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? LiveData { get; set; }

    public virtual ICollection<Faculty> Faculties { get; set; } = new List<Faculty>();
}
