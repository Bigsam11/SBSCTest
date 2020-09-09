using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SBSCLearn.Models;
using Microsoft.EntityFrameworkCore;
namespace SBSCLearn.Controllers
{
    public class HomeController : Controller
    {
        private readonly SBSCLEARNDBContext _context;

        public  HomeController(SBSCLEARNDBContext context){

            _context = context;

           }
    
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login login)
        {

            var getUser = _context.Users.FirstOrDefault(p => p.Email == login.Email);
            TempData["UserName"] = getUser.UserName;
            TempData["UserId"] = getUser.UserId;
            TempData.Keep("UserName");
            TempData.Keep("UserId");

            try
            {
                if (getUser == null)
                {
                    ViewBag.Message = "This User does not exist";
                    return View();
                }
               else if(getUser != null)
                {
                    var validatePass = _context.Users.FirstOrDefault(p => p.Password == login.Password);
                    if(validatePass != null)
                    {
                        return RedirectToAction("UserArea", "Home",new { Id = getUser.UserId});
                    }
                    else
                    {
                        ViewBag.Message = "Wrong password was entered";
                        return View();
                    }
                }
                else
                {
                    ViewBag.Message = "Something went wrong";
                    return View();
                }
            }
            catch (Exception e)
            {
                return View();
            }
            
        }


        public async Task<IActionResult> Learn()
        {

            var Id = TempData["UserId"].ToString();

            List<Courses> getCourses = new List<Courses>();

              getCourses = _context.Courses.Where(p=>p.UserId.ToString() == Id.ToString()).ToList();

            return View();
        }


        public IActionResult UserArea()
        {

           
            TempData.Keep("UserId");

            return View();
        }

        public IActionResult Update(int id)
        {
            TempData["CourseId"] = id;
            var getCourse = _context.Courses.FirstOrDefault(p => p.CourseId.ToString() == id.ToString());
            TempData["CourseName"] = getCourse.CourseName;
            TempData["Category"] = getCourse.Category;
            TempData["Description"] = getCourse.Description;
            TempData.Keep("CourseName");
            TempData.Keep("Category");
            TempData.Keep("Description");
            TempData.Keep("CourseId");
            return View();

        }

        public IActionResult Category()
        {
            
            return View();

        }

        [HttpPost]
        public IActionResult Category(string category)
        {


            return View(_context.Attempt.Where(p=>p.Category == category).FirstOrDefault());

        }


        [HttpPost]
        public IActionResult Update(Attempt attempt)
        {
            try
            {
                
                attempt.AttemptId = System.Guid.NewGuid();
                attempt.CourseId = Guid.Parse(TempData["CourseId"].ToString());
                attempt.UserId = Guid.Parse(TempData["UserId"].ToString());
                attempt.CourseName = TempData["CourseName"].ToString();
                attempt.CourseDescription = TempData["Description"].ToString();
                attempt.Category = TempData["Category"].ToString();
                attempt.AttemptedDate = DateTime.Now;
               
                
                
                _context.Attempt.Update(attempt);
                _context.SaveChanges();
                ViewBag.Message = "Successfully graded the course";
                return RedirectToAction("Learn");
            }
            catch (Exception e)
            {
                ViewBag.Message = "An error occured!";
                return RedirectToAction();
            }
        }

        [HttpPost]
        public IActionResult UserArea(Courses courses)
        {
            TempData.Keep("UserId");
            var Id =  TempData["UserId"].ToString();

            var getbyId = _context.Users.FirstOrDefault(p => p.UserId.ToString() == Id);

            try {
                
                if(getbyId != null)
                {
                    courses.CourseId = System.Guid.NewGuid();
                     courses.UserId = Guid.Parse(getbyId.CourseId);
                    _context.Courses.Add(courses);
                    _context.SaveChangesAsync();
                    ViewBag.Message = "Succesfully created a course";
                }
                else
                {
                    ViewBag.Message = "You need to be logged in to create a course";
                    return View();
                }

            }
            catch(Exception e)
            {
                ViewBag.Message = "An error occured,please retry";
                return View();
            }
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
