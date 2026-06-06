using CrudOperation.Data;
using CrudOperation.Dto;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Controllers
{
    public class AuthController(AddDbContext _context) : Controller
    {
        public IActionResult Login()
        {
            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View("Registration", dto);
            }
            if (dto == null || string.IsNullOrEmpty(dto.Username)
                || string.IsNullOrEmpty(dto.Email)
                || string.IsNullOrEmpty(dto.Password))
            {
                ViewBag.ErrorMessage = "Please Fill All Required Fields.";
                return View("Registration", dto);
            }
           try
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);
                if (existingUser == null)
                {
                    var user = new User
                    {
                        Email = dto.Email,
                        Password = dto.Password,
                        Username = dto.Username
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    ViewBag.ErrorMessage = "User Already Exists.";
                    return View("Registration", dto);
                }
            }catch(Exception ex)
            {
                return Content(ex.ToString());
            }
            TempData["SuccessMessage"] = "User Created Successfully.";
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> CreateUser()
        {
            return View();
        }
        public async Task<IActionResult> LoginUser(UserDto dto)
        {
            if (dto == null 
                || string.IsNullOrEmpty(dto.Email)
                ||string.IsNullOrEmpty(dto.Password))
            {
                ViewBag.ErrorMessage = "Kindly Fill All The Details.";
            }
            try
            {
                var isUserExist = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
                if (isUserExist == null) {
                    ViewBag.ErrorMessage = "User Does Not Exist";
                    return View("Login");
                }
                else
                {
                    if(isUserExist.Password == dto.Password)
                    {
                        return RedirectToAction("ViewStudent", "Student");
                    }
                    else { ViewBag.ErrorMessage = "Pasword Does Not Matched."; return View("Login"); }
                }
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
    }
}
