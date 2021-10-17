using System.Collections.Generic;
using System.ComponentModel;

namespace UniversityRegistrar.Models
{
  public class Course
  {
    public Course()
    {
      this.JoinEntities = new HashSet<Registrar>();
    }

    public int CourseId { get; set; }

    [DisplayName("Course Name")]
    public string CourseName { get; set; }
    [DisplayName("Course Number")]
    public string CourseNumber { get; set; }
    public virtual ICollection<Registrar> JoinEntities { get; set; }
  }
}