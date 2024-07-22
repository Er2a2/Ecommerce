using B.E;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjectTerm2.Models;

namespace ProjectTerm2.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<UserApp>userManager;
        private SignInManager<UserApp> SignInManager;

        public AccountController(UserManager<UserApp> userManager, SignInManager<UserApp> signInManager)
        {
            this.userManager = userManager;
            SignInManager = signInManager;
        }
        //دوتا بالایی برای ساین آپ و لاگین و اینان


        public async Task<IActionResult> Register()
        {
            return View();
        }


        // متد GET برای نمایش فرم ورود
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {         
            //var user =  userManager.FindByNameAsync(model.Username);
            //این مث پایینیس ولی یه await نزده بودم کارنمیکرد:)))
            var user= await userManager.FindByNameAsync(model.Username);
            if(user == null)
            {
                ModelState.AddModelError("", "کاربر با این نام کاربری پیدا نشد");
                return View(model);
            }
            var signInResult =await SignInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "نام کاربری یا پسورد اشتباه است");
                return View(model);
            } 
            return RedirectToAction("courses", "course" );
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var user = await userManager.FindByNameAsync(model.Username);
            if (user != null)
                //این یعنی شخصی رو پیدا کرده
            {
                ModelState.AddModelError("", "این نام کاربری در سیستم موجود میباشد");
                return View(model);

            }
            if (model.Password == model.Password2)
            {
                var Newuser = new UserApp
                {
                    UserName = model.Username,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                };
                //توابعی که آسینک هستن برای صدا زدنشون باید اِوِیت هم باشه اینجا پایین ننوشتم خراب شد اول
                var addresult = await userManager.CreateAsync(Newuser, model.Password);
            }
            else
            {
                ModelState.AddModelError("", "پسوردا مث هم نیستن");
                return View(model);
            }
            return View();
          
        }
        public IActionResult Index()
        {
            return View();
        }


        //[Authorize]
        //public async Task<IActionResult> Logout()
        //{
        //       await SignInManager.SignOutAsync();
        //       return RedirectToAction("Index","Home");
        //} 



        //یه روش این بود حالا یه روش بالا
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await SignInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

    }
}
