using Microsoft.AspNetCore.Identity;

namespace B.E
{
    public class Teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string email { get; set; }
        public string pic { get; set; }
        public List<Teacher_course> teacher_Courses { get; set; }
    }
    public class course
    {
        public int id { get; set; }
        public string title { get; set; }
        public float totaltime { get; set; }
        public string descript { get; set; }
        public string videointro { get; set; }
        public string pic { get; set; }
        public float price { get; set; }
        public List<course_detailfile> files { get; set; } = new List<course_detailfile>();
        public List<Teacher_course> teacher_Courses { get; set; }
        public List<Order_Course> Order_Courses { get; set; }


    }
    public class Teacher_course
    {
        public int id { get; set; }
        public int TeacherId { get; set; }
        public Teacher teacher { get; set; }
        public int CourseId { get; set; }
        public course course { get; set; }

    }
    public class course_detailfile
    {
        public int id { get; set; }
        public string adress { get; set; }
        public string descript { get; set; }
    }

    public class UserApp : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

    }

    public class Order
    {
        public int id { get; set; }
        public string UserId {  get; set; }
        public UserApp User { get; set; }
        public float TotalPrice {get; set; } 
        public List<Order_Course> Order_Courses { get; set; }

    }
    public class Order_Course
    {
        public int id { get; set; }
        public int CourseId { get; set; }
        public course Course { get; set; }
        public int OrderId {  get; set; }
        // اینجا با گذاشتن اردر ایدی دیگه نمیخواد موقع جستجو بری تو دیتابیس کل اردر رو لود کنی بعد دیگه اینکلود و اینا هم نمیخواد
        public Order Order {get; set;}
    }
}
