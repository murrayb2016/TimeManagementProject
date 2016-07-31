using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeManagment.Services.Models
{
    public class TodoTaskDTO
    {
        [Required(ErrorMessage = "Description is required!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Priority Level is required!")]
        [Range(1, 5, ErrorMessage = "Priority Level is between 1 and 5!")]
        public int PriorityLevel { get; set; }

        [Required(ErrorMessage = "Start Date is required!")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "Due Date is required!")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Time Estimate is required!")]
        [Range(0, 448, ErrorMessage = "Time Estimate Between zero and 448!")]
        public int TimeEstimate { get; set; }

        [Required(ErrorMessage = "Category Name is required!")]
        public string CategoryName { get; set; }

    }
}
