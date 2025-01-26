using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class NotificationStuToFa
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? ToFacultyId { get; set; }

    public int? FromStudentId { get; set; }

    public DateTime CreatedDate { get; set; }

    public bool IsRead { get; set; }

    public bool IsActive { get; set; }

    public string? FacOfficeTime { get; set; }
}
