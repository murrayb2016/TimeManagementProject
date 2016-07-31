using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeManagment.Data;
using TimeManagment.Models;

namespace TimeManagment.Infrastructure
{
    public class TodoTaskRepository
    {
        private ApplicationDbContext _db;
        public TodoTaskRepository(ApplicationDbContext db) {
            _db = db;
        }

        public string GetUserId(string userName)
        {
            return (from u in _db.Users
                    where u.UserName == userName
                    select u).First().Id;
        }

        public void AddForm(TodoTask task)
        {            
            _db.Tasks.Add(task);
            _db.SaveChanges();
        }

        public IQueryable<TodoTask> GetTasksForUser(string userName)
        {

            return from t in _db.Tasks
                   where t.User.UserName == userName
                   orderby t.Category.Name
                   select t;
        }

        public Category GetCategoryForUser(string category, string userName) {

            return (from c in _db.Categories
                    where c.User.UserName==userName
                    where c.Name==category
                    select c).FirstOrDefault();
        }

        public IQueryable<TodoTask> DeleteTasksForUser(string userName, string task,string category)
        {

            var taskRow=(from t in _db.Tasks
                        where t.Description == task && t.Category.Name==category
                         where t.User.UserName == userName
                         orderby t.Category.Name
                         select t).First();

            _db.Tasks.Remove(taskRow);
            _db.SaveChanges();

            var Categoryrow = (from t in _db.Tasks
                              where t.Category.Name==category
                               where t.User.UserName == userName
                               select t).FirstOrDefault();

            
            if (Categoryrow == null) {

                var Category = (from c in _db.Categories
                                   where c.Name == category
                                where c.User.UserName == userName
                                select c).First();

                _db.Categories.Remove(Category);
                _db.SaveChanges();
            }

            return GetTasksForUser(userName);
        }



    }
}
