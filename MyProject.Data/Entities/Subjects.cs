﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Data.Entities
{
    public class Subjects
    {
        public Subjects()
        {
            StudentSubjects = new HashSet<StudentSubject>();   
            DepartmentSubjects = new HashSet<DepartmentSubject>();   
        }
        [Key] public int SubjectsId { get; set; }
        [StringLength(500)]
        public string SubjectName { get; set; }
        public int Period { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
        public virtual ICollection<DepartmentSubject> DepartmentSubjects { get; set; }

        

    }
}
