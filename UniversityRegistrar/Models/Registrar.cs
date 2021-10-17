namespace UniversityRegistrar.Models
{
  public class Registrar
  {       
    public int RegistrarId { get; set; }
    public int CourseId { get; set; }
    public int StudentId { get; set; }
    public virtual Course Course { get; set; }
    public virtual Student Student { get; set; }
  }
}