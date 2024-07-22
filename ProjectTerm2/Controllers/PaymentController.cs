using B.E;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ProjectTerm2.Controllers
{
    public class PaymentController : Controller
    {
        private UserManager<UserApp>userManager;
        public PaymentController(UserManager<UserApp> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Payment()
        {
             
            var courseIds = new Dictionary<int, int>();
            // var courseIds = new List<int>();
            if (HttpContext.Session.GetString("basket") != null)
            {
                courseIds = JsonConvert.DeserializeObject<Dictionary<int, int>>(HttpContext.Session.GetString("basket"));

                var blc = new blCourse();
                var courses = blc.SearchById(courseIds.Keys.ToList());

                var user = await userManager.FindByNameAsync(User.Identity.Name);
                blOrder blo = new blOrder();
                var orderCourses = new List<Order_Course>();
                foreach (var item in courses)
                {
                    orderCourses.Add(new Order_Course { CourseId = item.id });
                }
                blo.Create(new Order
                {
                    Order_Courses = orderCourses,
                    TotalPrice = courses.Sum(s => s.price),
                    UserId =   user.Id 
                });
            }
            return RedirectToAction("index", "profile", new {message= "پرداخت با موفقیت انجام شد" });
        } 
        
    }
}
