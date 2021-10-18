using System.Collections.Generic;
using System.ComponentModel;


namespace UniversityRegistrar.Models
{
  public class Department
  {
    public Department()
    {
      // this.JoinEntities3 = new HashSet<CourseDepartment>();
      // this.JoinEntities2 = new HashSet<DepartmentStudent>();
      this.CourseDepartmentJE = new HashSet<CourseDepartment>();
      this.DepartmentStudentJE = new HashSet<DepartmentStudent>();
    }

    [DisplayName("Department Id")]
    public int DepartmentId { get; set; }
    [DisplayName("Department Name")]
    public string DepartmentName { get; set; }
    public virtual ICollection<CourseDepartment> CourseDepartmentJE { get; set; }
    public virtual ICollection<DepartmentStudent> DepartmentStudentJE { get; set; }
  }
}