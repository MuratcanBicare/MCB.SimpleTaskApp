using MCB.SimpleTaskApp.Tasks;
using MCB.SimpleTaskApp.Tasks.Dtos;
using MCB.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }
        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output.Items) 
            { 
                SelectedTaskState = input.State
            };
            return View(model);
        }
    }
}
