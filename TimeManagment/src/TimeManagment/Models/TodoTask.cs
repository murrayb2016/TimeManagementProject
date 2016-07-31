using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManagment.Models
{
    public class TodoTask
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority Level is required!")]
        [Range(1,5,ErrorMessage ="Priority Level is between 1 and 5!")]
        public int PriorityLevel { get; set; }


        [Required(ErrorMessage = "Start Date is required!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required!")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Time Estimate is required!")]
        [Range(0,448,ErrorMessage ="Time Estimate Between zero and 448!")]
        public int TimeEstimate { get; set; }

        public int CategoryId { get; set; }       //matches to the foreinkey to match the database
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public string UserId { get; set; }       //matches to the foreignkey to match the database
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


    }
}
