using Microsoft.AspNetCore.Mvc;
using StudentRecordSystem.Models;
using System.Text.Json;

namespace StudentRecordSystem.Controllers
{
    public class FacultyController : Controller
    {
        private readonly string filePath = "Data/faculty.json";

        private List<Faculty> LoadFaculty()
        {
            if (!System.IO.File.Exists(filePath))
                return new List<Faculty>();
            var json = System.IO.File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Faculty>>(json) ?? new List<Faculty>();
        }

        private void SaveFaculty(List<Faculty> list)
        {
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            System.IO.File.WriteAllText(filePath, json);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Faculty f)
        {
            var facultyList = LoadFaculty();
            var faculty = facultyList.FirstOrDefault(x => x.Username == f.Username && x.Password == f.Password);

            if (faculty != null)
            {
                HttpContext.Session.SetString("FacultyUser", f.Username);
                TempData["Message"] = "Login successful!";
                return RedirectToAction("Index", "Student");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Faculty f)
        {
            var facultyList = LoadFaculty();
            if (facultyList.Any(x => x.Username == f.Username))
            {
                ViewBag.Error = "Username already exists!";
                return View();
            }

            facultyList.Add(f);
            SaveFaculty(facultyList);
            TempData["Message"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
