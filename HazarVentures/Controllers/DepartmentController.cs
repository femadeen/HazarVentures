using HazarVentures.Interfaces.Services;
using HazarVentures.ViewModels.RequestModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HazarVentures.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _DepartmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _DepartmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _DepartmentService.GetAllDepartments();
            return View(departments);
        }

        public IActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDepartment(CreateDepartmentRequestModel model)
        {
            _DepartmentService.AddDepartment(model);
            return RedirectToAction("Index");
        }
        public IActionResult UpdateDepartment(int id)
        {
            var department = _DepartmentService.GetDepartmentById(id);
            return View(department);
        }

        [HttpPost]
        public IActionResult UpdateDepartment(int id, UpdateDepartmentRequestModel model)
        {
            _DepartmentService.UpdateDepartment(id, model);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var department = _DepartmentService.GetDepartmentById(id);
            return View(department);
        }
        [Authorize]
        public IActionResult Delete(int id)
        {
            var department = _DepartmentService.GetDepartmentById(id);
            return View(department);
        }
        [Authorize]
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _DepartmentService.DeleteDepartment(id);
            return RedirectToAction("Index");
        }
    }
}
