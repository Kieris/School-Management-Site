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
    public class CoursesController : ControllerBase
    {
        protected readonly LMSDbContext context;

        public CoursesController(LMSDbContext _context)
        {
            context = _context;
        }

        [HttpGet("")]
        public async Task<ActionResult<Course[]>> GetCourses()
        {
            var courses =  await context.Courses.Select(x => new {
                x.Name,
                x.Id,
                x.PrefYear
            }).AsNoTracking().ToArrayAsync();

            if(courses != null)
            {
                return Ok(courses);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetCourse/{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course =  await context.Courses.Include(p => p.Instructors).SingleOrDefaultAsync(x => x.Id == id);
            
            if(course != null)
            {
                return Ok(course);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPut("AddCourse")]
        public async Task<ActionResult> AddCourse([FromBody]string stud)
        {
            var course = JsonSerializer.Deserialize<Course>(stud);
            if (course != null)
            {
                //Check to see if course already exists
                var foundCourse = context.Courses.Where(x => x.Name == course.Name);
                if (foundCourse != null && foundCourse.Count() != 0)
                {
                    return Conflict("A course with this name already exists.");
                }

                context.Courses.Add(course);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    return Conflict("There was an issue saving to the database.");
                }
                return CreatedAtAction("AddCourse", new {});
            }
            return NotFound();
        }

        [HttpDelete("DeleteCourse/{id}")]
        public async Task<ActionResult> DeleteCourse(Guid id)
        {
            var course = context.Courses.SingleOrDefault(x => x.Id == id);
            if (course != null)
            {
                context.Courses.Remove(course);
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


        [HttpPut("AddInstructor/{sid}/{cid}")]
        public async Task<ActionResult> AddInstructor(Guid sid, Guid cid)
        {
            //Check to see if student already exists
            var foundCourse = context.Courses.Include(p => p.Instructors).SingleOrDefault(x => x.Id == sid);
            if (foundCourse == null)
            {
                return NotFound();
            }
  
            var inst = context.Instructors.SingleOrDefault(x => x.Id == cid);
            if (inst != null)
            {
                    foundCourse.Instructors.Add(inst);
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