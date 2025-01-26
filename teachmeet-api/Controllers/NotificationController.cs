using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teachmeet_api.DTOs.Request;
using teachmeet_api.Entities;

namespace teachmeet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController(TeachmeetdbContext db) : ControllerBase
    {
        [HttpPost("CreateFacultyNotification")]
        public async Task<IActionResult> CreateFacultyNotification([FromBody] FacultyNotificationReqDTO request)
        {
            NotificationFacToFa factToFac = new()
            {
                Title = "Faculty Notification!",
                Description = request.Description,
                FromFacultyId = request.FromFacultyId,
                ToFacultyId = request.ToFacultyId,
                OfficeTime = request.OfficeTime,
                IsActive = true
            };
            await db.NotificationFacToFas.AddAsync(factToFac);
            await db.SaveChangesAsync();

            return Ok(new { Message = "Notification generated successfully" });
        }
        [HttpGet("GetFacultyNotification")]
        public async Task<IActionResult> GetFacultyNotification(int facultyId)
        {
            var facNotifications = await (from n in db.NotificationFacToFas
                                          join ff in db.Faculties on n.FromFacultyId equals ff.Id
                                          join tf in db.Faculties on n.ToFacultyId equals tf.Id
                                          where n.IsActive &&
                                          ff.LiveData == true &&
                                          tf.LiveData == true &&
                                          n.ToFacultyId == facultyId
                                          select new
                                          {
                                              Id = n.Id,
                                              FromFacultyName = ff.FirstName + " " + ff.LastName,
                                              Title = n.Title,
                                              Description = n.Description,
                                              n.IsRead,
                                              n.CreatedDate
                                          }).ToListAsync();

            if (facNotifications == null || facNotifications.Count == 0)
            {
                return NotFound(new { Message = "Notifications not found" });
            }

            return Ok(facNotifications);
        }


        [HttpPost("CreateStudentNotification")]
        public async Task<IActionResult> CreateStudentNotification([FromBody] StudentNotificationReqDTO request)
        {
            NotificationStuToFa stuToFac = new()
            {
                Title = "Student Notification!",
                Description = request.Description,
                FromStudentId = request.FromStudentId,
                ToFacultyId = request.ToFacultyId,
                FacOfficeTime = request.OfficeTime,
                IsActive = true
            };
            await db.NotificationStuToFas.AddAsync(stuToFac);
            await db.SaveChangesAsync();

            return Ok(new { Message = "Notification generated successfully" });
        }

        [HttpGet("GetStudentNotificationForFaculty")]
        public async Task<IActionResult> GetStudentNotificationForFaculty(int facultyId)
        {
            var stuNotifications = await (from n in db.NotificationStuToFas
                                          join st in db.Students on n.FromStudentId equals st.Id
                                          where n.IsActive &&
                                          st.LiveData == true &&
                                          n.ToFacultyId == facultyId
                                          select new
                                          {
                                              Id = n.Id,
                                              FromStudentName = st.FirstName + " " + st.LastName,
                                              Title = n.Title,
                                              Description = n.Description,
                                              n.IsRead,
                                              n.CreatedDate
                                          }).ToListAsync();

            if (stuNotifications == null || stuNotifications.Count == 0)
            {
                return NotFound(new { Message = "Notifications not found" });
            }

            return Ok(stuNotifications);
        }
    }
    }
