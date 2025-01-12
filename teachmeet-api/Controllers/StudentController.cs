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
        [HttpGet("GetTitles")]
        public async Task<IActionResult> GetTitles()
        {
            return Ok(await db.Titles.AsNoTracking().Select(s => new DropDownResDTO() { Id = s.Id, Name = s.Name }).ToListAsync());
        }
    }
}
