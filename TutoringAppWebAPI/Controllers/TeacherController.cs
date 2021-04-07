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
            return Ok(_teacherRepository.GetItems());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TeacherIsNullOrModelStateInvalid.ToString());
                }
                bool teacherExists = await _teacherRepository.DoesTeacherExist(teacher.Id);
                if (teacherExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TeacherIDInUse.ToString());
                }
                await _teacherRepository.AddItemAsync(teacher);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotCreateTeacher.ToString());
            }
            return Ok(teacher);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Teacher teacher)
        {
            try
            {
                if (teacher == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCode.TeacherIsNullOrModelStateInvalid.ToString());
                }
                var existingTeacher = _teacherRepository.GetItemAsync(teacher.Id);
                if (existingTeacher == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _teacherRepository.UpdateItemAsync(teacher);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotUpdateTeacher.ToString());
            }
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                var teacher = _teacherRepository.DoesTeacherExist(id);
                if (teacher == null)
                {
                    return NotFound(ErrorCode.RecordNotFound.ToString());
                }
                _teacherRepository.DeleteItemAsync(id);
            }
            catch (Exception)
            {
                return BadRequest(ErrorCode.CouldNotDeleteTeacher.ToString());
            }
            return NoContent();
        }

    }



    public enum ErrorCode
    {
        TeacherIsNullOrModelStateInvalid,
        TeacherIDInUse,
        RecordNotFound,
        CouldNotCreateTeacher,
        CouldNotUpdateTeacher,
        CouldNotDeleteTeacher
    }
}
