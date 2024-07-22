using B.E;

namespace ProjectTerm2.Models
{
    public class teacher
    {
        public int id { get; set; }
        public string name { get; set; }
        public string family { get; set; }
        public string email { get; set; }
        public IFormFile pic { get; set; }
        public List<Teacher_course> teacher_Courses { get; set; }
    }
    public class course
    {
        public int id { get; set; }
        public string title { get; set; }
        public float totaltime { get; set; }
        public string descript { get; set; }
        public IFormFile pic { get; set; }
        public string picUrl { get; set; }
        public IFormFile videointro { get; set; }
        public string videoUrl {  get; set; }
        public float price { get; set; }
        public List<int>teachers{ get; set; }
        public List<Teacher_course> teacher_Courses { get; set; }
        public string Teachers { get; set; } // Add this property for hidden input

                                             //اینو جدید برای ویرایش
        public List<int> SelectedTeacherIds { get; set; } = new List<int>();

    }
  


}
