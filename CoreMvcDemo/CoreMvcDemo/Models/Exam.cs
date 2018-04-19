using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcDemo.Models
{
    public class Exam
    {
        [Key]
        public int ExamID { get; set; }

        public string Code { get; set; }
        public string Description { get; set; }
    }
}
