using B.E;
using BLL;
using DAL;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectTerm2.Controllers
{
    public class OrderController : Controller
    {
        public async Task<IActionResult> AddToBasket(int courseId)
        {
            var basketDict = new Dictionary<int, int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                basketDict = JsonConvert.DeserializeObject<Dictionary<int, int>>(HttpContext.Session.GetString("basket"));
            }

            if (basketDict.ContainsKey(courseId))
            {
                basketDict[courseId]++;
            }
            else
            {
                basketDict[courseId] = 1;
            }

            HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketDict));
            return RedirectToAction("details", "course", new { id = courseId });
        }
    }
}





//public async Task<IActionResult> AddToBasket(int courseId)
//{
//    var basketlist = new List<int>();
//    if (HttpContext.Session.GetString("basket")!=null)
//    {
//      //چون هر مشتری میتونه هر ثانیه رو یه محصول کلیک کنه و اونو بخره پس یه لیستی از محصولات تعریف میکنیم
//      basketlist= JsonConvert.DeserializeObject<List<int>>(HttpContext.Session.GetString("basket")).ToList();

//    }
//    //بالا دی سریالایز میکنیم برای گرفتن اطلاعات پایین سریالایز برای دادن اطلاعات
//    basketlist.Add(courseId);
//    HttpContext.Session.SetString("basket", JsonConvert.SerializeObject(basketlist));
//    return RedirectToAction("details", "course", new {id= courseId });
//    //دیتیل ورودیش آیدی بود که محصول رو کامل لود میکرد و اینجا هم میدیم ک همون محصول قبلی بیاد بالا
//}