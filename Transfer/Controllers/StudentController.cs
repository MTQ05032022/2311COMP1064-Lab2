using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;
using Transfer.Models;

namespace Transfer.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Show(Student model, String command)
        {
            if(command == "Ghi file Json")
            {
                var myPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student1.json");

                // Chuyển đổi obiect sang json
                var jsonString = JsonSerializer.Serialize(model);
                System.IO.File.WriteAllText(myPath, jsonString);
                ViewBag.Message = "Đã ghi vào file Json!";
            }
            if (command == "Ghi file text")
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "Student.txt");
                String[] lines = { model.StudentId, model.StudentName, model.Mark.ToString(), model.IsMale.ToString(), model.Grade };
                //Chuyển đổi IsMale thành text
                /* if (model.IsMale == true)
                     lines[3] = "Nam";
                 else
                     lines[3] = "Nữ";*/
                System.IO.File.WriteAllLines(path, lines);
                ViewBag.Message = "Đã ghi vào file Text!";
            }


            return View("Index");
        }

        public IActionResult OpenData(string type)
        {
            var student = new Student();
            if(type == "JSON")
            {
                var myPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Student1.json");
                var content = System.IO.File.ReadAllText(myPath);
                student = JsonSerializer.Deserialize<Student>(content);
                ViewBag.StudentId = student.StudentId;
                ViewBag.StudentName = student.StudentName;
                ViewBag.Mark = Convert.ToDouble(student.Mark);
                ViewBag.IsMale = student.IsMale;
                ViewBag.Grade = student.Grade;

                ViewBag.Message = "Đã đọc từ file Json!";
            }
            if(type == "TEXT")
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
            "wwwroot", "Student.txt");
                String[] lines = System.IO.File.ReadAllLines(path);
                ViewBag.StudentId = lines[0];
                ViewBag.StudentName = lines[1];
                ViewBag.Mark = Convert.ToDouble(lines[2]);
                student.IsMale = Convert.ToBoolean(lines[3]);
                
                ViewBag.Grade = lines[4];

                ViewBag.Message = "Đã đọc từ file Text!";
            }
            return View("Index", student);
        }
    }
}
