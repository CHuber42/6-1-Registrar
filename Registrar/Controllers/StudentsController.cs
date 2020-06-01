using Microsoft.AspNetCore.Mvc;
using Registrar.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Registrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly RegistrarContext _db;

    public StudentsController(RegistrarContext _db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View("Index", _db.Students.ToList());
    }

    public ActionResult Details()
    {
      Student thisStudent = _db.Students
        .Include(student => student.Courses)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(student => student.StudentId = id);
      return View("Details");
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Student student)
    {
      _db.Students.Add(student);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Student thisStudent = _db.Students.FirstOrDefault(Student => Student.StudentId == id);
      return View("Edit");
    }
    [HttpPost]
    public ActionResult Edit(int id)
    {

      return View("Index");
    }
    public ActionResult Delete()
    {
      return View("Delete");
    }
    public ActionResult AddCourse(int id)
    {
      var thisStudent = _db.Students.FirstOrDefault(student => student.StudentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "Name");
      return View(thisStudent);
    }
    [HttpPost]
    public ActionResult AddCourse(Student student, int CourseId)
    {
      if (CourseId != 0)
      {
        _db.CourseStudent.Add(new CourseStudent() { CourseId = CourseId, StudentId = student.StudentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.CourseStudent.FirstOrDefault(entry => entry.CourseStudentId == joinId);
      _db.CourseStudent.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}
