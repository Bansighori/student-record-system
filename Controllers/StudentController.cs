using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Models;
using System.Text.Json;

namespace StudentRecordSystem.Controllers
{
    public class StudentController : Controller
    {
        private string GetFilePath(string faculty)
        {
            return $"Data/students_{faculty}.json";
        }

        private List<Student> LoadStudents(string faculty)
        {
            var path = GetFilePath(faculty);
            if (!System.IO.File.Exists(path))
                return new List<Student>();

            var json = System.IO.File.ReadAllText(path);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        private void SaveStudents(string faculty, List<Student> list)
        {
            var path = GetFilePath(faculty);
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(path, json);
        }

        public IActionResult Index()
        {
            var faculty = HttpContext.Session.GetString("FacultyUser");
            if (faculty == null)
                return RedirectToAction("Login", "Faculty");

            var students = LoadStudents(faculty);
            ViewBag.Faculty = faculty;
            return View(students);
        }

        [HttpPost]
        public IActionResult Add(Student s)
        {
            var faculty = HttpContext.Session.GetString("FacultyUser");
            if (faculty == null)
                return RedirectToAction("Login", "Faculty");

            var students = LoadStudents(faculty);
            students.Add(s);
            SaveStudents(faculty, students);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int rollNo)
        {
            var faculty = HttpContext.Session.GetString("FacultyUser");
            if (faculty == null)
                return RedirectToAction("Login", "Faculty");

            var students = LoadStudents(faculty);
            var student = students.FirstOrDefault(x => x.RollNo == rollNo);
            if (student != null)
                students.Remove(student);

            SaveStudents(faculty, students);
            return RedirectToAction("Index");
        }
    }
}
