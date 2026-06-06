using CrudOperation.Data;
using Microsoft.AspNetCore.Mvc;

namespace CrudOperation.Controllers
{
    public class StudentController(AddDbContext _context) : Controller
    {
        public IActionResult ViewStudent()
        {
            return View();
        }
    }
}
