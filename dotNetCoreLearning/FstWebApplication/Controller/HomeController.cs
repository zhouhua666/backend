using FstWebApplication.Models;
using FstWebApplication.ViewModels;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class HomeController : Controller
{
    private readonly IStudentRepository _studentRepository;

    public HomeController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public ViewResult Index()
    {
        var model = _studentRepository.GetAllStudents();
        return View(model);
    }
    public ViewResult Details(int? id)
    {
        HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
        {
            Student = _studentRepository.GetStudent(id ?? 2),
            PageTitle = "Student Details"
        };

        // 将ViewModel对象传递给View()方法
        return View(homeDetailsViewModel);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        if (ModelState.IsValid)
        {
            Student newStudent = _studentRepository.Add(student);
            return RedirectToAction("Details", new {id = newStudent.Id});
        }
        return View();
    }
}