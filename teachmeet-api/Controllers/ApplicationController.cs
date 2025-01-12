using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using teachmeet_api.DTOs.Response;
using teachmeet_api.Entities;

namespace teachmeet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController(TeachmeetdbContext db) : ControllerBase
    {
        [HttpGet("GetTitles")]
        public async Task<IActionResult> GetTitles()
        {
            return Ok(await db.Titles.AsNoTracking().Select(s => new DropDownResDTO() { Id = s.Id, Name = s.Name }).ToListAsync());
        }
        [HttpGet("GetGenders")]
        public async Task<IActionResult> GetGenders()
        {
            return Ok(await db.Genders.AsNoTracking().Select(s => new DropDownResDTO() { Id = s.Id, Name = s.Name }).ToListAsync());
        }
        [HttpGet("GetDepartments")]
        public async Task<IActionResult> GetDepartments()
        {
            return Ok(await db.Departments.AsNoTracking().Select(s => new DropDownResDTO() { Id = s.Id, Name = s.Name }).ToListAsync());
        }
        [HttpGet("GetOfficeTimings")]
        public async Task<IActionResult> GetOfficeTimings()
        {
            return Ok(await db.OfficeTimings.AsNoTracking().ToListAsync());
        }
    }
}
