using teachmeet_api.Entities;

namespace teachmeet_api.DTOs.Request
{
    public class RegisterFacultyReqDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;
        public string? Description { get; set; }

        public int? TitleId { get; set; }

        public int? DepartmentId { get; set; }


        public string? Email { get; set; }
        public string? Password { get; set; }

        public int? GenderId { get; set; }

        public string? ProfileImage { get; set; }

        public string? MobileNumber { get; set; }
        public int[]? OfficeTimingIds { get; set; }
    }
}
