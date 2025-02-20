using Microsoft.AspNetCore.Mvc;
using _200604735.Models;
using _200604735.Services;

namespace _200604735.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        // Display all students
        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            return View(students);
        }

        // Display create form
        public IActionResult Create() => View();

        // Handle create form submission
        [HttpPost]
        public IActionResult Create(Student student)
        {
            _studentService.Create(student);
            return RedirectToAction("Index");
        }

        // Display edit form
        public IActionResult Edit(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Handle edit form submission
        [HttpPost]
        public IActionResult Edit(int id, Student student)
        {
            if (!_studentService.Update(id, student)) return NotFound();
            return RedirectToAction("Index");
        }

        // Display student details
        public IActionResult Details(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Display delete confirmation
        public IActionResult Delete(int id)
        {
            var student = _studentService.GetById(id);
            if (student == null) return NotFound();
            return View(student);
        }

        // Handle delete action
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!_studentService.Delete(id)) return NotFound();
            return RedirectToAction("Index");
        }
    }
}
