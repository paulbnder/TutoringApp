using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringAppWebAPI.Interfaces;
using TutoringAppWebAPI.Models;

namespace TutoringAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class TeacherController : Controller
    {
        private readonly IRepository<Teacher> _teacherRepository;

        public TeacherController(IRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_teacherRepository.GetItemsAsync());
        }

        [HttpPost]
        public IActionResult Create([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                }
                bool teacherExists = _teacherRepository.DoesTeacherExist(teacher.ID);
                if (teacherExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TeacherIDInUse.ToString());
                }
                _teacherRepository.Insert(teacher);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateTeacher.ToString());
            }
            return Ok(teacher);
        }

    }
}
