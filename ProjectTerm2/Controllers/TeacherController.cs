using Microsoft.AspNetCore.Mvc;
using B.E;
using BLL;
using Newtonsoft.Json.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectTerm2.Controllers
{
    public class TeacherController : Controller
    {
        private IWebHostEnvironment Environment;
        public TeacherController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View("Teacher/Create");
        }
        public IActionResult Showall()
        {
            blteacher blt=new blteacher();
            return View("Teacher/show",blt.getskip(0));
           // return View("Teacher/show",blt.read()); با این کل دیتا رو نشون میداد با بالایی بعد پیج بندی فقط 10 تا
        }       
        [HttpPost]
        public IActionResult Create(Models.teacher teacher)
        {   
            blteacher blt = new blteacher();
            B.E.Teacher te = new Teacher();
            te.name= teacher.name;
            te.family= teacher.family;
            te.email= teacher.email;
            UploadFile upf = new UploadFile(Environment);
            te.pic=upf.upload(teacher.pic);
            blt.create(te);
            ViewBag.Message = "ثبت استاد با موفقیت انجام شد.";
            return View("Teacher/Create");
        }
        //مشترک ai و mohsen

        public JsonResult tsjson()
        {
            //ریدایرکت هر اکشنی میتونه باشه ک اسمشو گذاشتیم سرچ و با پایینی پرش کردیم
            return Json(new { redirect = "Search" });
        }
            //ai و اون یکی مشترک
        public IActionResult Search(string tags)
        {
            //اینجا parse تگز رو که یه رشته است رو به یه ارایه تبدیل کرده
            JArray jsonArray = JArray.Parse(tags);
            List<string> split = new List<string>(); 

            foreach (var item in jsonArray)
            {
                    split.Add(item.ToString());
            }
            
            blteacher blt = new blteacher();
            List<Teacher> ll = blt.Search(split);
            return View("Teacher/show", ll);
            //در نهایت لیست معلمان به ویویی به نام show در فولدر Teacher ارسال می‌شود تا نتایج به کاربر نمایش داده شود.
        }

        public void Update(Models.teacher teacher)
        {
            blteacher blt = new blteacher();
            B.E.Teacher te = new Teacher();
            te.id = teacher.id;
            te.name = teacher.name;
            te.family = teacher.family;
            te.email = teacher.email;
            UploadFile upf = new UploadFile(Environment);
            te.pic = upf.upload(teacher.pic);
            blt.Update(te);
        } 

        // وقتی میخوای همزمان رفرش بشه اینطوری تعریف میکنی و تهش جیسون مینویسی
        //public IActionResult Update(Models.teacher teacher)
        //{
        //    blteacher blt = new blteacher();
        //    B.E.Teacher te = new Teacher();
        //    te.id = teacher.id;
        //    te.name = teacher.name;
        //    te.family = teacher.family;
        //    te.email = teacher.email;
        //    UploadFile upf = new UploadFile(Environment);
        //    te.pic = upf.upload(teacher.pic);
        //    blt.Update(te);
        //    return Json(new { success = true, data = te });
        //}
        public IActionResult getskip(int c)
        {
            blteacher blt = new blteacher();
            return View("Teacher/show", blt.getskip(c));
        }
        public IActionResult NewList()
        {
            blteacher blt = new blteacher();
            //var teachers = blt.read();
            //return View("_Teachers", teachers);
            return View("_Teachers",blt.read());
        }

    }

}
    