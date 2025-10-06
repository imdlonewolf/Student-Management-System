using ClosedXML.Excel;
using DAL.Model;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using OfficeOpenXml;
using StudentWebApp.Models;
using System.Text;


namespace StudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        IRepository _repository;    
        public StudentController(IRepository repository) { 
            _repository = repository;
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("EmailId")==null)
            {
                return RedirectToAction("Login", "User");
            }
            List<Student>students = _repository.GetStudentsList();
            List<StudentModel>studentModels = new List<StudentModel>();
            foreach (Student student in students)
            {
                StudentModel studentModel = new StudentModel();
                studentModel.StudentId = student.StudentId;
                studentModel.StudentName=student.StudentName;
                studentModel.DOB = student.DOB;
                studentModel.StudentPhone = student.StudentPhone;
                studentModel.StudentEmail = student.StudentEmail;
                studentModel.Courses = student.Courses;
                studentModels.Add(studentModel);
            }
            return View(studentModels);
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (HttpContext.Session.GetString("EmailId") == null)
            {
                return RedirectToAction("Login", "User");
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentModel studentModel)
        {
            Student student = new Student();
            //student.StudnetId = studentModel.StudnetId;
            student.StudentName = studentModel.StudentName;
            student.DOB = studentModel.DOB;
            student.StudentPhone = studentModel.StudentPhone;
            student.StudentEmail = studentModel.StudentEmail;
            student.Courses = studentModel.Courses;
            bool x=_repository.AddStudent(student);
            if (x)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (HttpContext.Session.GetString("EmailId") == null)
            {
                return RedirectToAction("Login", "User");
            }
            Student student=_repository.GetStudentById(id);
            StudentModel studentModel = new StudentModel();
            studentModel.StudentId = student.StudentId;
            studentModel.StudentName = student.StudentName;
            studentModel.DOB = student.DOB;
            studentModel.StudentPhone = student.StudentPhone;
            studentModel.StudentEmail = student.StudentEmail;
            studentModel.Courses = student.Courses;
            return View(studentModel);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (HttpContext.Session.GetString("EmailId") == null)
            {
                return RedirectToAction("Login", "User");
            }
            Student student = _repository.GetStudentById(id);
            StudentModel studentModel = new StudentModel();
            studentModel.StudentId = student.StudentId;
            studentModel.StudentName = student.StudentName;
            studentModel.DOB = student.DOB;
            studentModel.StudentPhone = student.StudentPhone;
            studentModel.StudentEmail = student.StudentEmail;
            studentModel.Courses = student.Courses;
            return View(studentModel);
        }
        [HttpPost]
        public IActionResult Edit(StudentModel studentModel,int id)
        {

            //Student student=_repository.GetStudentById(id);
            string phone=studentModel.StudentPhone;
            bool x=_repository.UpdateStudent(id, phone);
            if (x)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.GetString("EmailId") == null)
            {
                return RedirectToAction("Login", "User");
            }
            Student student = _repository.GetStudentById(id);
            StudentModel studentModel = new StudentModel();
            studentModel.StudentId = student.StudentId;
            studentModel.StudentName = student.StudentName;
            studentModel.DOB = student.DOB;
            studentModel.StudentPhone = student.StudentPhone;
            studentModel.StudentEmail = student.StudentEmail;
            studentModel.Courses = student.Courses;
            return View(studentModel);
        }
        [HttpPost]
        public IActionResult Delete(StudentModel studentModel, int id)
        {
            bool x = _repository.DeleteStudent(id);
            if (x)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Error");
            }
        }
        public IActionResult Export()
        {
            var students = _repository.GetStudentsList();
            var csv = new StringBuilder();
            csv.AppendLine("Id,Name,Email,Phone,DOB,Courses");
            DateTime today= DateTime.Now;
            string filename = "studentslist"+today+".csv";
            foreach (var s in students)
            {
                csv.AppendLine($"{s.StudentId},{s.StudentName},{s.StudentEmail},{s.StudentPhone},{s.DOB},{string.Join(";", s.Courses)}");
            }

            return File(Encoding.UTF8.GetBytes(csv.ToString()), "text/csv", filename);
        }
        public IActionResult Language()
        {
            if (HttpContext.Session.GetString("Lang") == "null" || HttpContext.Session.GetString("Lang") == "eng")
            {

               HttpContext.Session.SetString("Lang", "bn");
            }
            else
            {
                HttpContext.Session.SetString("Lang", "eng");
            }
            return RedirectToAction("Index");
        }
    }
}
