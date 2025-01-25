namespace teachmeet_api.DTOs.Request
{
    public class ChangeStudentStatusReqDTO
    {
        public int StudentId { get; set; }
        public bool Status { get; set; }
    }
}
