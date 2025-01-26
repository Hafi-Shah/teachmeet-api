namespace teachmeet_api.DTOs.Request
{
    public class FacultyNotificationReqDTO
    {
        public string Description { get; set; }
        public int FromFacultyId { get; set; }
        public int ToFacultyId { get; set; }
        public string OfficeTime { get; set; }
    }

    public class StudentNotificationReqDTO
    {
        public string Description { get; set; }
        public int FromStudentId { get; set; }
        public int ToFacultyId { get; set; }
        public string OfficeTime { get; set; }
    }
}
