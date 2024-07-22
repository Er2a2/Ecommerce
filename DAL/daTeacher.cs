using B.E;
namespace DAL
{
    public class daTeacher
    {
        public void Create(Teacher t)
        {
            DB db=new DB();
            db.teachers.Add(t);
            db.SaveChanges();
        }
        
        public List<Teacher>read()
        {
            DB db=new DB();
           return db.teachers.ToList();
        }

        public List<Teacher> Search(List<string>tags)
        {
            List<Teacher>te=new List<Teacher>();
            foreach (var item  in tags)
            {
                DB db = new DB();
                var q = from i in db.teachers
                where i.name.Contains(item.ToString()) || i.family.Contains(item.ToString()) || i.email.Contains(item.ToString())
                select i;
                te = te.Concat(q.ToList()).ToList();
            }
          return te;
        }
        public void Update(Teacher t)
        {
            DB db=new DB();
            var q= from i in db.teachers where i.id==t.id
            select i;         // ایجاد یک کوئری برای پیدا کردن استاد با شناسه مشابه شناسه استادی که می‌خواهیم به‌روزرسانی کنیم
            Teacher te =new Teacher();
            te=q.Single();            // تخصیص نتیجه کوئری به شیء te
            te.name = t.name;
            te.family = t.family;
            te.email = t.email;
            te.pic=t.pic;
            db.SaveChanges();
        }
        public int gettotal()
        {
            DB dB = new DB();
            return dB.teachers.Count();
        }    
        public List<Teacher> getskip(int c)
        {
            int t = c * 10;    // محاسبه تعداد رکوردهایی که باید جا انداخته شوند 
            DB dB = new DB();
            var q = dB.teachers.Skip(t).Take(10);       // اجرای کوئری برای دریافت 10 رکورد پس از جا انداختن t رکورد
            return q.ToList();
        }
    }

}
