using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online.Infrastructure.MyCourse;
using Online.DomainModel;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnLine.Controllers
{
    public class StudentController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
                var studentService = new StudentService();
           
                var students = studentService.GetAll();
                ViewData["Students"] = students;
          
               
                return View();
        }

        public IActionResult Detail(Student student)
        {
            var userService = new StudentService();
            var model = userService.GetUserById(student.Sid);
            return View(model);
        }

        public IActionResult StudentDel(int sid)
        {

            var userService = new StudentService();
            userService.StudentDel(sid) ;
           
            return Redirect(Url.Action("Index", "Student"));
        }

        public IActionResult AddUser(Student student)
        {
            var userService = new StudentService();
            var count = userService.StudentAdd(student.Sid,student.Sname,student.Depart,student.Class,student.Major,student.Password);
            return Redirect(Url.Action("Index", "Student"));
        }
        public IActionResult UpdateUser(Student student)
        {
            var userService = new StudentService();
            var ab = userService.UpdateUser(student.Sid,student.Sname,student.Depart,student.Class,student.Major,student.Password);
            return Redirect(Url.Action("Index", "Student"));
        }


    }
}
