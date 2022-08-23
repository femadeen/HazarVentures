using HazarVentures.Implementations.Services;
using HazarVentures.Interfaces.Services;
using HazarVentures.ViewModels.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace HazarVentures.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ILecturerService _lecturerService;
        private readonly IDepartmentService _departmentService;
        private readonly IUserService _userService;
        public LecturerController(ILecturerService lecturerService, IDepartmentService departmentService, IUserService userService)
        {
            _lecturerService = lecturerService;
            _departmentService = departmentService;
            _userService = userService;
        }
    
        public IActionResult Index()
        {
            var lecturers = _lecturerService.GetAllLecturer();
            return View(lecturers);
        }

        public IActionResult RegisterLecturer()
        {
            var departments = _departmentService.GetAllDepartments();
            ViewData["Departments"] = new SelectList(departments.Data, "Id", "Name");
            return View();
        }
        [HttpPost]
        public IActionResult RegisterLecturer(CreateLecturerRequestModel model)
        {
            _lecturerService.RegisterLecturer(model);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult DeleteLecturer(int id)
        {
            var lecturer = _lecturerService.GetLecturerById(id);
            return View(lecturer);
        }

        [Authorize(Roles = "Student")]
        [HttpPost, ActionName("DeleteLecturer")]
        public IActionResult DeleteConfirmed(int id)
        {
            var lecturer = _lecturerService.DeleteLecturer(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var lecturer = _lecturerService.GetLecturerById(id);
            return View(lecturer);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateLecturerRequestModel model)
        {
            _lecturerService.UpdateLecturer(id, model);
            return RedirectToAction("Index");
        }
        
        public IActionResult Details()
        {
            int id  = int.Parse(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var user = _userService.GetUserById(id);
            var lecturer = _lecturerService.GetLecturerById(user.Data.LecturerId);
                return View(lecturer);
        }
    }
}
