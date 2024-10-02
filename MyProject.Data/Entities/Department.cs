using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
    public partial class Department
    {
        public Department()
        {
            Students = new List<Student>();
            DepartmentSubjects = new List<DepartmentSubject>();
        }

        [Key] public int DepartmentId { get; set; }
        [StringLength(500)] public string Name { get; set; }

       // [InverseProperty("Departments")]
        public virtual ICollection<Student> Students { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }


    }
}
