using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teachmeet_api.DTOs.Request;
using teachmeet_api.DTOs.Response;
using teachmeet_api.Entities;

namespace teachmeet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController(TeachmeetdbContext db) : ControllerBase
    {
        [HttpPost("RegisterFaculty")]
        public async Task<IActionResult> RegisterFaculty([FromBody] RegisterFacultyReqDTO request)
        {
            Faculty faculty = new Faculty()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password,
                ProfileImage = request.ProfileImage,
                MobileNumber = request.MobileNumber,
                Description = request.Description,
                TitleId = request.TitleId,
                GenderId = request.GenderId,
                DepartmentId = request.DepartmentId,
                CreatedBy = "1",
                CreatedDate = DateTime.Now,
                LiveData = true,
                Status = true
            };
            db.Faculties.Add(faculty);
            await db.SaveChangesAsync();
            request.Id = faculty.Id;

            List<FacultyOfficeTime> fac = [];
            if (request.OfficeTimingIds != null)
            {
                foreach (var item in request.OfficeTimingIds)
                {
                    fac.Add(new FacultyOfficeTime()
                    {
                        FacId = faculty.Id,
                        OfficeTimeId = item,
                        LiveData = 1
                    });
                }
                if (fac.Count > 0)
                {
                    await db.FacultyOfficeTimes.AddRangeAsync(fac);
                    await db.SaveChangesAsync();
                }
            }

            return Ok(request);
        }        
        [HttpGet("GetTimingsOfFacultyById")]
        public async Task<IActionResult> GetTimingsOfFacultyById(int facultyId)
        {
            var result = from f in db.Faculties
                         join fot in db.FacultyOfficeTimes on f.Id equals fot.FacId
                         join ot in db.OfficeTimings on fot.OfficeTimeId equals ot.Id
                         where f.Id == facultyId &&
                         f.LiveData == true &&
                         fot.LiveData == 1
                         select ot;
            return Ok(await result.AsNoTracking().ToListAsync());
        }
        [HttpGet("GetFacultyDetailById")]
        public async Task<IActionResult> GetFacultyDetailById(int facultyId)
        {
            var facultyDetail = await (from f in db.Faculties
                                       join t in db.Titles on f.TitleId equals t.Id
                                       join g in db.Genders on f.GenderId equals g.Id
                                       join d in db.Departments on f.DepartmentId equals d.Id
                                       where f.Id == facultyId && f.LiveData == true
                                       select new
                                       {
                                           f.Id,
                                           f.FirstName,
                                           f.LastName,
                                           f.Email,
                                           f.ProfileImage,
                                           f.MobileNumber,
                                           f.Description,
                                           Title = t.Name,
                                           Gender = g.Name,
                                           Department = d.Name,
                                           f.CreatedBy,
                                           f.CreatedDate,
                                           f.LiveData,
                                           f.Status
                                       }).FirstOrDefaultAsync();

            if (facultyDetail == null)
            {
                return NotFound(new { Message = "Faculty not found" });
            }

            var officeTimings = await (from fot in db.FacultyOfficeTimes
                                       join ot in db.OfficeTimings on fot.OfficeTimeId equals ot.Id
                                       where fot.FacId == facultyId && fot.LiveData == 1
                                       select new
                                       {
                                           ot.Id,
                                           ot.Day,
                                           ot.StartTime,
                                           ot.EndTime
                                       }).ToListAsync();

            var response = new
            {
                Faculty = facultyDetail,
                OfficeTimings = officeTimings
            };

            return Ok(response);
        }
        [HttpPost("FacultyLogin")]
        public async Task<IActionResult> Login([FromBody] LoginReqDTO request)
        {
            var faculty = await db.Faculties
                                   .FirstOrDefaultAsync(f => f.Email == request.Email && f.Password == request.Password && f.LiveData == true);

            if (faculty == null)
            {
                return BadRequest(new { Message = "Invalid username or password" });
            }

            return Ok(new { Message = "Login successful", Id = faculty.Id });
        }
        [HttpPost("ChangeFacultyStatus")]
        public async Task<IActionResult> ChangeFacultyStatus([FromBody] ChangeFacultyStatusReqDTO request)
        {
            var faculty = await db.Faculties.FirstOrDefaultAsync(f => f.Id == request.FacultyId);

            if (faculty == null)
            {
                return NotFound(new { Message = "Faculty not found" });
            }

            // Update the Status field
            faculty.Status = request.Status;

            await db.SaveChangesAsync();

            return Ok(new { Message = "Faculty status updated successfully" });
        }

        [HttpGet("GetFacultyCards")]
        public async Task<IActionResult> GetFacultyCards()
        {
            var facultyCards = await (from f in db.Faculties
                                      join t in db.Titles on f.TitleId equals t.Id
                                      where f.LiveData == true
                                      select new
                                      {
                                          f.Id,
                                          f.FirstName,
                                          f.LastName,
                                          f.Status,
                                          f.ProfileImage,
                                          Title = t.Name
                                      }).ToListAsync();

            return Ok(facultyCards);
        }


    }
}
