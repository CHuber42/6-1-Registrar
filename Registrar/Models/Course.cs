using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace Registrar.Models
{
  public class Course
  {
    public Course()
    {
      this.Students = new HashSet<CourseStudent>();
    }
    public int CourseId { get; set; }
    public string Name { get; set; }
    public ICollection<CourseStudent> Students { get; set; }
  }
}