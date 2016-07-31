using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeManagment.Services.Models;
using TimeManagment.Services;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TimeManagment.Controllers
{
    [Route("api/[controller]")]
    public class TodoTaskController : Controller
    {

        private TodoTaskService _ttService;
        public TodoTaskController(TodoTaskService tts)
        {
            _ttService = tts;
        }

        [HttpPost]
        public IActionResult PostForm([FromBody] TodoTaskDTO task)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // _ttService.AddForm(task);
            _ttService.AddForm(task, User.Identity.Name);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IList<TodoTaskDTO> Get()
        {
            return _ttService.GetTasksByUsername(User.Identity.Name);  //gets the user name of the currently logged in user through Identity   
        }


        [HttpDelete]
        public IList<TodoTaskDTO> Delete(string task,string category) {
            return _ttService.DeleteTasksByUsername(User.Identity.Name,task,category);
        }
    }
}
