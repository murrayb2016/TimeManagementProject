using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManagment.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required!")]
        public string Name { get; set; }

        public IList<TodoTask> Tasks { get; set; }

        public string UserId { get; set; }       //matches to the foreignkey to match the database
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

    }
}
