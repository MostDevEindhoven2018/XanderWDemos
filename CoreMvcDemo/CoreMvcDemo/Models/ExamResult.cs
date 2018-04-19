using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMvcDemo.Models
{
    public class ExamResult
    {
        [Key]
        public int ExamResultID { get; set; }

        public int Score { get; set; }

        public DateTime When { get; set; }

        // This object reference in C#
        // Translates in SQL to an ID (Foreign Key)
        public virtual Student Student { get; set; }
        public virtual Exam Exam { get; set; }
    }
}
