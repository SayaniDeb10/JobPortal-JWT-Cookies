using CrudOperation.Data;
using CrudOperation.Dto;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperation.Controllers
{
    public class DashboardController(AddDbContext _context) : Controller
    {
        public IActionResult Recruiter()
        {
            var list = _context.Jobs.Select(j => new JobDto 
            { Id = j.Id, JobTitle = j.JobTitle, Location= j.Location, Salary = j.Salary }).ToList();
            return View(list);
        }
        public IActionResult Student()
        {
            return View();
        }
        public IActionResult NewJobForm() => View();

        public async Task<IActionResult> EditJob(int jobId)
        {
            var job = await _context.Jobs.FirstOrDefaultAsync(job => job.Id == jobId);

            if(job == null){
                return View("Recruiter");
            }
            else
            {
                var dto = new JobDto
                {
                    Id = job.Id,
                    JobDescription = job.JobDescription,
                    Location = job.Location,
                    CompanyName = job.CompanyName,
                    Qualification = job.Qualification,
                    Salary = job.Salary,
                    Experience = job.Experience,
                    JobTitle = job.JobTitle,
                };
                return View("NewJobForm", dto);
            }
        }
        [HttpPost]
        public async Task<IActionResult> SaveJob(JobDto job)
        {
            if (job == null) {
                ViewBag.ErrorMessage = "Please Fill All Details";
                return View("NewJobForm");
            }
            try
            {
                if(job.Id == 0)
                {
                    //Add Form
                    _context.Jobs.Add(new Job
                    {
                        JobTitle = job.JobTitle,
                        CompanyName = job.CompanyName,
                        Qualification = job.Qualification,
                        Location = job.Location,
                        Experience = job.Experience,
                        Salary = job.Salary,
                        JobDescription = job.JobDescription
                    });
                }
                else
                {
                    var existUser = await _context.Jobs.FirstOrDefaultAsync(x => x.Id == job.Id);

                    if(existUser == null)
                    {
                        return RedirectToAction("Recruiter");
                    }
                    else
                    {
                        existUser.JobDescription = job.JobDescription;
                        existUser.Location = job.Location;
                        existUser.CompanyName = job.CompanyName;
                        existUser.Qualification = job.Qualification;
                        existUser.Salary = job.Salary;
                        existUser.Experience = job.Experience;
                        existUser.JobTitle = job.JobTitle;
                    }
                    _context.Jobs.Update(existUser);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction("Recruiter");
            }catch(Exception ex){
                return Content(ex.ToString());
            }
        }
    }
}
