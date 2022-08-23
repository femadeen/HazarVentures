using HazarVentures.Implementations.Services;
using HazarVentures.Interfaces.Services;
using HazarVentures.ViewModels.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HazarVentures.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        public StudentController(IStudentService studentService, IDepartmentService departmentService)
        {
            _studentService = studentService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }

        public IActionResult CreateStudent()
        {
            var departments = _departmentService.GetAllDepartments();
            ViewData["Departments"] = new SelectList(departments.Data, "Id", "Name");
            return View(); 
        }

        [HttpPost]
        public IActionResult CreateStudent(CreateStudentRequestModel model)
        {
            _studentService.AddStudent(model);
            return RedirectToAction("Index");
        }

        public IActionResult StudentDetails(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }
        
        public IActionResult Update(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateStudentRequestModel model)
        {
            _studentService.UpdateStudent(id, model);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }

        [Authorize]
        [HttpPost, ActionName("DeleteStudent")]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }

    }
}
