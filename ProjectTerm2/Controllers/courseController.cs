using BLL;
using B.E;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using DAL;
using Microsoft.IdentityModel.Tokens;
using ProjectTerm2.Models;

namespace ProjectTerm2.Controllers
{
    public class courseController : Controller
    {
        private IWebHostEnvironment Environment;
        public courseController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        //پایینیه واسه درست کردن ویو عه
        public IActionResult Courses()
        {
            return View();
        }
        public IActionResult Index()
        {
            blteacher blt = new blteacher();
            ViewBag.Teachers = blt.read();
            return View();
        }

    
        [HttpPost]
        public IActionResult Create(Models.course c)
        {
            blCourse blt = new blCourse();
            B.E.course te = new B.E.course();
            te.title = c.title;
            te.descript = c.descript;
            te.price = c.price;
            te.totaltime = c.totaltime;
            UploadFile upf = new UploadFile(Environment);
            te.pic = upf.uploadImage(c.pic);
            te.videointro = upf.uploadvideo(c.videointro);
            blt.create(te);
            if (c.teachers != null && c.teachers.Any())
            {
                foreach (var teacherId in c.teachers)
                {
                    var teacherCourse = new Teacher_course
                    {
                        CourseId = te.id,
                        TeacherId = teacherId
                    };
                    blt.AddTeacherCourse(teacherCourse);
                }
            }

            return RedirectToAction(nameof(Index));
        }
    
        //مشترک ai و mohsen
        public JsonResult tsjson()
        {
            return Json(new { redirect = "Search" });
        }
        //ai و اون یکی مشترک
        public IActionResult Search(string s)
        { 

            blCourse blc = new blCourse();
            List<B.E.course> ll = blc.Search(s);
            //چون تو getall.cshtml ما با مدل تعریفش نکردیم اینجا هم ویو بگ میذاریم
            ViewBag.courses=ll;
            return View("getall");
          // دیگه ال ال نمیذاریم چون ویو بگیه  return View("course/getall", ll);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            blCourse blc = new blCourse();
            var becourse = blc.SearchById(id);
            blteacher blt = new blteacher();
            ViewBag.Teachers = blt.read();
            var modelCourse = new Models.course()
            {
                id = becourse.id,
                title = becourse.title,
                price = becourse.price,
                totaltime = becourse.totaltime,
                descript = becourse.descript,
                picUrl=becourse.pic,
                videoUrl = becourse.videointro,
                teachers = becourse.teacher_Courses.Select(x => x.TeacherId).ToList(),
                teacher_Courses = becourse.teacher_Courses  // مقداردهی اولیه در اینجا
            };
            return View(modelCourse); 
            //return View();  اینو course رو نذاشتم داخل پرانتز کلا اطلاعات رو بالا نمیاورد برام

        }
     

        [HttpPost]
        public IActionResult Edit(Models.course course)
        {
            blCourse blc = new blCourse();
            var becourse = blc.SearchById(course.id);

            becourse.title = course.title;
            becourse.price = course.price;
            becourse.descript = course.descript;
            becourse.totaltime = course.totaltime;

            if (course.videointro != null)
            {
                UploadFile upf = new UploadFile(Environment);
                string videoPath = upf.uploadvideo(course.videointro);
                becourse.videointro = videoPath;
            }

            // به‌روزرسانی اساتید
            becourse.teacher_Courses.Clear();
            foreach (var teacherId in course.SelectedTeacherIds)
            {
                var teacher = blc.GetTeacherById(teacherId);
                if (teacher != null)
                {
                    becourse.teacher_Courses.Add(new Teacher_course
                    {
                        TeacherId = teacherId,
                        CourseId = becourse.id,
                        teacher = teacher,
                        course = becourse
                    });
                }
            }

            blc.Update(becourse);
            return RedirectToAction(nameof(getall));
        }

        public IActionResult getskip(int c)
        {
            blteacher blt = new blteacher();
            return View("Teacher/show", blt.getskip(c));
        }
        //برای دیتیل اون کامپوننت لیست کورس
        public IActionResult Details(int id)
        {
            blCourse blc=new blCourse();
            B.E.course tt=new B.E.course();
            tt=blc.SearchById(id);
            return View(tt);
        }
        public IActionResult getall()
        {
            blCourse blc = new blCourse();
            ViewBag.courses = blc.read();
            return View();
        }
        public IActionResult Delete(int id)
        {
            // انجام عملیات حذف دوره با استفاده از شناسه
            // مثال:
            blCourse blc = new blCourse();
            blc.DeleteCourse(id);

            // Redirect به محل مورد نظر بعد از حذف (مثلاً صفحه اصلی یا صفحه لیست دوره‌ها)
            return RedirectToAction("getall", "course");
        }
    }
}
