using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbsentManagement.Areas.Home.Data.DTOs.AbsentLog
{
    public class AbsentLogDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Teacher can not empty")]
        public long TeacherId { get; set; }
        public string TeacherName { get; set; }
        public long StudentId { get; set; }

        [Required(ErrorMessage = "Please,choose datetime")]
        public DateTime From { get; set; }

        [Required(ErrorMessage = "Please,choose datetime")]
        public DateTime To { get; set; }

        [Required(ErrorMessage = "Please, Enter Reason")]
        public string Reason { get; set; }

        public string Status { get; set; }
    }
}