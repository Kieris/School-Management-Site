using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using LMS.Database;
using LMS.Database.Model;


namespace LMS.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        protected readonly LMSDbContext context;

        public StudentsController(LMSDbContext _context)
        {
            context = _context;
        }

        [HttpGet("")]
        public async Task<ActionResult<Student[]>> GetStudents()
        {
            var students =  await context.Students.Select(x => new {
                x.FirstName,
                x.LastName,
                x.Year,
                x.Id
            }).AsNoTracking().ToArrayAsync();

            if(students != null)
            {
                return Ok(students);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetStudent/{id}")]
        public async Task<ActionResult<Student>> GetStudent(Guid id)
        {
            var student =  await context.Students.Where(x => x.Id == id).Select(k => new {
                k.Address,
                k.Id,
                k.Username,
                k.City,
                k.State,
                k.Phone,
                k.AltPhone,
                k.Email,
                k.AltEmail,
                k.FirstName,
                k.LastName,
                k.Year,
                Courses = k.Courses.Select(h => new {
                    h.Instructors,
                    h.Name
                }),
            }).AsSplitQuery().SingleOrDefaultAsync();
            
            if(student != null)
            {
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("AddStudent")]
        public async Task<ActionResult> AddStudent([FromBody]string stud)
        {
            var student = JsonSerializer.Deserialize<Student>(stud);
            if (student != null)
            {
                //Check to see if student already exists
                var foundStudent = context.Students.Where(x => x.FirstName == student.FirstName && 
                                    x.LastName == student.LastName && x.Username == student.Username);
                if (foundStudent != null && foundStudent.Count() != 0)
                {
                    return Conflict("A student with these first, last, and user names already exists.");
                }

                context.Students.Add(student);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict("There was an issue saving to the database.");
                }
                return CreatedAtAction("AddStudent", new {});
            }
            return NotFound();
        }

        [HttpDelete("DeleteStudent/{id}")]
        public async Task<ActionResult> DeleteStudent(Guid id)
        {
            var student = context.Students.SingleOrDefault(x => x.Id == id);
            if (student != null)
            {
                context.Students.Remove(student);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict("There was an issue saving to the database.");
                }
                return Ok();
            }
            else 
            {
                return NotFound();
            }            
        }

        [HttpPut("AddCourse/{sid}/{cid}")]
        public async Task<ActionResult> AddCourse(Guid sid, Guid cid)
        {
            //Check to see if student already exists
            var foundStudent = context.Students.Include(p => p.Courses).SingleOrDefault(x => x.Id == sid);
            if (foundStudent == null)
            {
                return NotFound();
            }
  
            var course = context.Courses.SingleOrDefault(x => x.Id == cid);
            if (course != null)
            {
                    foundStudent.Courses.Add(course);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict("There was an issue saving to the database.");
                }
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}