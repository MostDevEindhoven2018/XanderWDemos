using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace CoreMvcDemo.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage ="This is required!")]
        public string Firstname { get; set; }

        [StringLength(30)]
        [Required]
        public string Lastname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [RegularExpression("http://.*|https://.*")]
        public string PictureURL { get; set; }

        public string Country { get; set; }


        // Make it virtual and ICollection!
        // Because of Lazy Loading the related records
        public virtual ICollection<ExamResult> ExamResults { get; set; }

    }
}
