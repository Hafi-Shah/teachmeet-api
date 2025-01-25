using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teachmeet_api.DTOs.Request;
using teachmeet_api.DTOs.Response;
using teachmeet_api.Entities;

namespace teachmeet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(TeachmeetdbContext db) : ControllerBase
    {
        [HttpPost("RegisterStudent")]
        public async Task<IActionResult> RegisterStudent([FromBody] RegisterStudentReqDTO request)
        {
            Student student = new Student()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                ProfileImage = request.ProfileImage,
                MobileNumber = request.MobileNumber,
                Description = request.Description,
                GenderId = request.GenderId,
                DepartmentId = request.DepartmentId,
                CreatedBy = "1",
                CreatedDate = DateTime.Now,
                LiveData = true,
                Status = true
            };
            db.Students.Add(student);
            await db.SaveChangesAsync();
            request.Id = student.Id;
            return Ok(request);
        }

        [HttpPost("StudentLogin")]
        public async Task<IActionResult> Login([FromBody] LoginReqDTO request)
        {
            var student = await db.Students
                                   .FirstOrDefaultAsync(f => f.Email == request.Email && f.Password == request.Password && f.LiveData == true);

            if (student == null)
            {
                return BadRequest(new { Message = "Invalid username or password" });
            }

            return Ok(new { Message = "Login successful", Id = student.Id });
        }
        [HttpGet("GetStudentDetailById")]
        public async Task<IActionResult> GetStudentDetailById(int id)
        {
            var studentDetail = await (from s in db.Students
                                       join g in db.Genders on s.GenderId equals g.Id
                                       join d in db.Departments on s.DepartmentId equals d.Id
                                       where s.Id == id && s.LiveData == true
                                       select new
                                       {
                                           s.Id,
                                           s.FirstName,
                                           s.LastName,
                                           s.Email,
                                           s.ProfileImage,
                                           s.MobileNumber,
                                           s.Description,
                                           Gender = g.Name,
                                           Department = d.Name,
                                           s.Status
                                       }).FirstOrDefaultAsync();

            if (studentDetail == null)
            {
                return NotFound(new { Message = "Student not found" });
            }

            return Ok(studentDetail);
        }
        [HttpPost("ChangeStudentStatus")]
        public async Task<IActionResult> ChangeFacultyStatus([FromBody] ChangeStudentStatusReqDTO request)
        {
            var student = await db.Faculties.FirstOrDefaultAsync(f => f.Id == request.StudentId);

            if (student == null)
            {
                return NotFound(new { Message = "Student not found" });
            }

            student.Status = request.Status;

            await db.SaveChangesAsync();

            return Ok(new { Message = "Student status updated successfully" });
        }


    }
}
