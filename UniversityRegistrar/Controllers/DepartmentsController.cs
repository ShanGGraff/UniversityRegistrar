using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UniversityRegistrar.Models;
using System.Collections.Generic;
using System.Linq;

namespace UniversityRegistrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;

    public DepartmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Department> model = _db.Departments.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Department department, int CourseId)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      if (CourseId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() { CourseId = CourseId, DepartmentId = department.DepartmentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Department thisDepartment = _db.Departments
          .Include(department => department.DepartmentStudentJE)
          .ThenInclude(join => join.Student)
          .Include(department => department.CourseDepartmentJE)
          .ThenInclude(join => join.Course)
          .FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    public ActionResult Edit(int id)
    { 
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department, int CourseId)
    {
       if (CourseId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() { CourseId = CourseId, DepartmentId = department.DepartmentId });
      }
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddCourse(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      ViewBag.CourseId = new SelectList(_db.Courses, "CourseId", "CourseName");
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult AddCourse(Department department, int CourseId)
    {
      if (CourseId != 0)
      {
      _db.CourseDepartment.Add(new CourseDepartment() { CourseId = CourseId, DepartmentId = department.DepartmentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddStudent(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      ViewBag.StudentId = new SelectList(_db.Students, "StudentId", "StudentName");
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult AddStudent(Department department, int StudentId)
    {
      if (StudentId != 0)
      {
      _db.DepartmentStudent.Add(new DepartmentStudent() { StudentId = StudentId, DepartmentId = department.DepartmentId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Department thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      _db.Departments.Remove(thisDepartment);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteCourse(int joinId)
    {
      var joinEntry = _db.CourseDepartment.FirstOrDefault(entry => entry.CourseDepartmentId == joinId);
      _db.CourseDepartment.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}