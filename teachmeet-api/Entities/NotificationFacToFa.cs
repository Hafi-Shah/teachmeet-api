using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class NotificationFacToFa
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ToFacultyId { get; set; }

    public int? FromFacultyId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRead { get; set; }

    public bool IsActive { get; set; }

    public string? OfficeTime { get; set; }
}
