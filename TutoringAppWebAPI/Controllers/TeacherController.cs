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

    }
}
