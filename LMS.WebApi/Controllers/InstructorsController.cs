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
    public class InstructorsController : ControllerBase
    {
        protected readonly LMSDbContext context;

        public InstructorsController(LMSDbContext _context)
        {
            context = _context;
        }

        [HttpGet("")]
        public async Task<ActionResult<Instructor[]>> GetInstructors()
        {
            var instructors =  await context.Instructors.Select(x => new {
                x.FirstName,
                x.LastName,
                x.Id
            }).AsNoTracking().ToArrayAsync();

            if(instructors != null)
            {
                return Ok(instructors);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetInstructor/{id}")]
        public async Task<ActionResult<Instructor>> GetInstructor(Guid id)
        {
            var instructor =  await context.Instructors.Where(x => x.Id == id).Select(k => new {
                k.Address,
                k.Id,
                k.Username,
                k.City,
                k.State,
                k.Phone,
                k.AltPhone,
                k.Email,
                k.AltEmail,
                k.Specialty,
                k.FirstName,
                k.LastName,
                Courses = k.Courses.Select(h => new {
                    h.Instructors,
                    h.Name
                }),
            }).AsSplitQuery().SingleOrDefaultAsync();
            
            if(instructor != null)
            {
                return Ok(instructor);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("AddInstructor")]
        public async Task<ActionResult> AddInstructor([FromBody]string stud)
        {
            var instructor = JsonSerializer.Deserialize<Instructor>(stud);
            if (instructor != null)
            {
                //Check to see if instructor already exists
                var foundInstructor = context.Instructors.Where(x => x.FirstName == instructor.FirstName && 
                                    x.LastName == instructor.LastName && x.Username == instructor.Username);
                if (foundInstructor != null && foundInstructor.Count() != 0)
                {
                    return Conflict("A instructor with these first, last, and user names already exists.");
                }

                context.Instructors.Add(instructor);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict("There was an issue saving to the database.");
                }
                return CreatedAtAction("AddInstructor", new {});
            }
            return NotFound();
        }

        [HttpDelete("DeleteInstructor/{id}")]
        public async Task<ActionResult> DeleteInstructor(Guid id)
        {
            var instructor = context.Instructors.SingleOrDefault(x => x.Id == id);
            if (instructor != null)
            {
                context.Instructors.Remove(instructor);
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
            var foundInst = context.Students.Include(p => p.Courses).SingleOrDefault(x => x.Id == sid);
            if (foundInst == null)
            {
                return NotFound();
            }
  
            var course = context.Courses.SingleOrDefault(x => x.Id == cid);
            if (course != null)
            {
                    foundInst.Courses.Add(course);
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