using DAL;
using B.E;
namespace BLL
{
    public class blteacher
    { 
        public void create(Teacher teacher)
        {
            daTeacher dat=new daTeacher();
            dat.Create(teacher);
        }

        public List<Teacher> read()
        {
            daTeacher dat = new daTeacher();
            return dat.read();
        }

        //مشترک
        public List<Teacher> Search(List<string> tags)
        {
            daTeacher dat = new daTeacher();
            return dat.Search(tags);
        }

        public void Update(Teacher t)
        {
            daTeacher dat=new daTeacher();
            dat.Update(t);
        }

        public int gettotal()
        {
            daTeacher dat = new daTeacher();
            return dat.gettotal();
        }
        public List<Teacher>getskip(int c)
        {
            daTeacher dat = new daTeacher();
            return dat.getskip(c);
        }
    }
}
