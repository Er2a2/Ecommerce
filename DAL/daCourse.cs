using B.E;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class daCourse
    {
        public void AddTeacherCourse(Teacher_course teacherCourse)
        {
            DB db = new DB();
            db.teacher_Courses.Add(teacherCourse);
            db.SaveChanges();
        }
            // سایر متدها
            public Teacher GetTeacherById(int teacherId)
            {
                DB db = new DB();
                return db.teachers.SingleOrDefault(t => t.id == teacherId);
            }
        
        public void Create(course c)
        {
            DB db=new DB();
            db.course.Add(c);
            db.SaveChanges();
        }
        //public List<course> getall()
        //{
        //    DB db = new DB();
        //    var q = from i in db.course select i;
        //    return q.ToList();
        //}
        public List<course> read()
        {
            DB db = new DB();
            return db.course.ToList();
        }
        public List<course> readByTeachers()
        {
            DB db = new DB();
            return db.course.Include(s=>s.teacher_Courses).ThenInclude(s=>s.teacher).ToList();
        }
        public List<course> Search(string s)
        {
            int n = 0;
            float ft = 0;
            DB db = new DB();
            var q = from i in db.course
            where i.title.Contains(s.ToString()) ||
            (int.TryParse(s, out n) ? i.price==n:false ) ||               //این s رو به اینت تبدیل میکنه پایینی به عدداعشاری یا همون فلوت
            (float.TryParse(s, out ft) ? i.totaltime == ft : false)
              select i;        
            return q.ToList();
        }
        public course SearchById(int id)
        {
            DB db = new DB();
            var q = from i in db.course.Include(s=> s.teacher_Courses).ThenInclude(s=>s.teacher)
            where i.id == id select i;           
            return q.SingleOrDefault();
        }
        public void Update(course t)
        {
            DB db = new DB();
            var q = from i in db.course where i.id == t.id select i;
            course te = new course(); 
            te = q.Single();
            te.title = t.title;
            te.totaltime = t.totaltime;
            te.price = t.price;
            te.videointro = t.videointro;
            te.descript = t.descript;
            db.SaveChanges();
        }
        public int gettotal()
        {
            DB dB = new DB();
            return dB.course.Count();
        }
        public List<course> getskip(int c)
        {
            int t = c * 10;
            DB dB = new DB();
            var q = dB.course.Skip(t).Take(10);
            return q.ToList();
        }
        public void DeleteCourse(int id)
        {
            DB dB = new DB();
            var course = dB.course.FirstOrDefault(c => c.id == id);
            if (course != null)
            {
                dB.course.Remove(course);
                dB.SaveChanges();
            }
        }
        
        //خط 50 layout.cs برای اون نوشتیم اینو
        public List<course> SearchById(List<int> ids)
        {
            DB db = new DB();
            var q=from i in db.course where ids.Contains(i.id) select i;
            return q.ToList();
        }
    }
}
