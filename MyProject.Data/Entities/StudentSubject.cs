using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
    public class StudentSubject
    {
        [Key] public int Id { get; set; }
        public int StudentId { get; set; }
        public int SubjectsId { get; set; }


        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [ForeignKey("SubjectsId")]
        public virtual Subjects Subjects { get; set; }
    }
}
