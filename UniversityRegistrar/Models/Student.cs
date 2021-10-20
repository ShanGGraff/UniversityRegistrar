using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UniversityRegistrar.Models

{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<Registrar>();
    }

    public int StudentId { get; set; }
    [DisplayName("Student Name")]
    [Required(ErrorMessage = "Student name is required")]
    public string StudentName { get; set; }
    [DisplayName("Enrollment Date")]
    [Required(ErrorMessage = "Enrollment date is required")]
    public DateTime EnrollmentDate {get; set;}

    public virtual ICollection<Registrar> JoinEntities { get;}
  }
}