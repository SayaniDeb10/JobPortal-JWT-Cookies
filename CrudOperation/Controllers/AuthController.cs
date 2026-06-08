using CrudOperation.Data;
using CrudOperation.Dto;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                        Username = dto.Username,
                        UserType = dto.UserType
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
                        //var token = GenerateJWToken(dto);

                        //Response.Cookies.Append("jwt_key", token, new CookieOptions
                        //{
                        //    HttpOnly = true,
                        //    Secure = true,
                        //    SameSite = SameSiteMode.Strict,
                        //    Expires = DateTime.UtcNow.AddMinutes(30)
                        //});
                        if (isUserExist.UserType.ToLower() == "student")
                        {
                            return RedirectToAction("Student", "Dashboard");
                        }
                        else
                        {
                            HttpContext.Session.SetInt32("UserId", isUserExist.Id);
                            return RedirectToAction("Recruiter", "Dashboard");
                        }

                    }
                    else { ViewBag.ErrorMessage = "Pasword Does Not Matched."; return View("Login"); }
                }
            }
            catch (Exception ex)
            {
                return Content(ex.ToString());
            }
        }
           
       
        //private string GenerateJWToken(UserDto dto)
        //{
        //    var jwtHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.UTF8.GetBytes("eFwndUlSUWLFDnBAxTOpspSDvK8RpeYFdlnaCXQ4mJb");

        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new System.Security.Claims.ClaimsIdentity(new[]
        //        {
        //            new Claim(ClaimTypes.Name, dto.Email),
        //        }),
        //        Expires = DateTime.UtcNow.AddMinutes(30),
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = jwtHandler.CreateToken(tokenDescriptor);
        //    return jwtHandler.WriteToken(token);
        //}
    }
}
