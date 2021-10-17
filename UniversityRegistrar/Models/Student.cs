using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    public Student()
    {
      this.JoinEntities = new HashSet<Registrar>();
    }

    public int StudentId { get; set; }
    public string StudentName { get; set; }
    public DateTime EnrollmentDate {get; set;}

    public virtual ICollection<Registrar> JoinEntities { get;}
  }
}