using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeManagment.Data;
using TimeManagment.Infrastructure;
using TimeManagment.Models;
using TimeManagment.Services.Models;

namespace TimeManagment.Services
{
    public class TodoTaskService
    {
        private TodoTaskRepository _ttRepo;
       
        public TodoTaskService(TodoTaskRepository ttr)
        {
            _ttRepo = ttr;
        }



        public void AddForm(TodoTaskDTO task,string userName) 
        {
          
            Category category = _ttRepo.GetCategoryForUser(task.CategoryName, userName);

            if (category == null)
            {
                category = new Category()
                {
                    Name = task.CategoryName,
                    UserId = _ttRepo.GetUserId(userName)
                };
            }

            TodoTask dbTask = new TodoTask()
            {
                Category = category,
                Description = task.Description,
                StartDate = task.StartDate,
                DueDate = task.DueDate,
                PriorityLevel = task.PriorityLevel,
                TimeEstimate = task.TimeEstimate,
                UserId = _ttRepo.GetUserId(userName)
            };



            _ttRepo.AddForm(dbTask);

        }

        public IList<TodoTaskDTO> GetTasksByUsername(string userName)
        {
            return (from t in _ttRepo.GetTasksForUser(userName)
                    select new TodoTaskDTO()
                    {
                        CategoryName = t.Category.Name,
                        Description = t.Description,
                        StartDate = t.StartDate,
                        DueDate = t.DueDate,
                        PriorityLevel = t.PriorityLevel,
                        TimeEstimate = t.TimeEstimate
                    }).ToList();

        }


        public IList<TodoTaskDTO> DeleteTasksByUsername(string userName,string task,string category)
        {
            return (from t in _ttRepo.DeleteTasksForUser(userName,task, category)
                    select new TodoTaskDTO()
                    {
                        CategoryName = t.Category.Name,
                        Description = t.Description,
                        StartDate = t.StartDate,
                        DueDate = t.DueDate,
                        PriorityLevel = t.PriorityLevel,
                        TimeEstimate = t.TimeEstimate
                    }).ToList();

        }

       

    }


}

