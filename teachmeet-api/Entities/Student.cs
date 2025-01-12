using System;
using System.Collections.Generic;

namespace teachmeet_api.Entities;

public partial class Student
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public int? GenderId { get; set; }

    public string? ProfileImage { get; set; }

    public string? MobileNumber { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public string? ModifiedBy { get; set; }

    public DateTime? ModifiedDate { get; set; }

    public bool? LiveData { get; set; }

    public bool? Status { get; set; }
}
