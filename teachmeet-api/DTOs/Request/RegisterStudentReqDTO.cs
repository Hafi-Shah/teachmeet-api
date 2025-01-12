namespace teachmeet_api.DTOs.Request
{
    public class RegisterStudentReqDTO
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
    }
}
