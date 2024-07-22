using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTerm2.Controllers
{
    //اینو اگه نمیذاشتیم وقتی طرف لاگین نکرده بود و خرید میزد میرفت برا پرداخت صفحه ارور میداد و اینطوری وقتی پرداخت رو میزنیم میبره مارو به صفحه لاگین 
    [Authorize]
    //[Route("پروفایل")]
    public class ProfileController : Controller
    {
        //[Route("اول")]
        public IActionResult Index(string showBasket,string message = null)
        {
            //اینجا برای اینه که رو پرداخت زدیم مستقیم بره رو اون دکمه هه بقیش لی اوت خط 76 اکتیو کردیمش
            //خط227 ایندکس و 16 همون ویو
            ViewBag.showBasket = showBasket;
            if (!string.IsNullOrWhiteSpace(message))
            {
                @ViewBag.successPayment=message;
            }
            return View();
        }
    }
}
