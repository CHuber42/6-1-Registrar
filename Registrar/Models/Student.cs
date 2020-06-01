using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Registrar.Models
{
  public class Student
  {
    public Student()
    {
      this.Courses = new HashSet<CourseStudent>();
    }
    public string Name { get; set; }
    public int StudentId { get; set; }

    public ICollection<CourseStudent> Courses { get; set; }
  }
}