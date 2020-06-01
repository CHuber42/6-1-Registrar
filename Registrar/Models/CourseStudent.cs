using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Registrar.Models
{
  public class CourseStudent
  {
    public Course Course { get; set; }
    public Student Student { get; set; }

    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public int CourseStudentId { get; set; }
  }
}
