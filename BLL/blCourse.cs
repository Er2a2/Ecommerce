using B.E;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class blCourse
    {
        public void AddTeacherCourse(Teacher_course teacherCourse)
        {
            daCourse dat = new daCourse();
            dat.AddTeacherCourse(teacherCourse);
        }
           // سایر متدها
        public Teacher GetTeacherById(int teacherId)
        {
            daCourse dac = new daCourse();
            return dac.GetTeacherById(teacherId);
        }
        public void create(course c)
        {
            daCourse dat = new daCourse();
            dat.Create(c);
        }
        public List<course> read()
        {
            daCourse dat = new daCourse();
            return dat.read();
        }
        public List<course> readByTeachers()
        {
            daCourse dat = new daCourse();
            return dat.readByTeachers();
        }

        //مشترک
        public List<course> Search(string s)
        {
            daCourse dac = new daCourse();
            return dac.Search(s);
        }
        public course SearchById(int id)
        {
            daCourse dac = new daCourse();
            return dac.SearchById(id);
        }
        public void Update(course t)
        {
            daCourse dat = new daCourse();
            dat.Update(t);
        }
        public int gettotal()
        {
            daCourse dat = new daCourse();
            return dat.gettotal();
        } 
        public List<course> getskip(int c)
        {
            daCourse dat = new daCourse();
            return dat.getskip(c);
        }
        public void DeleteCourse(int id)
        {
            daCourse dac = new daCourse();
            dac.DeleteCourse(id);
        }
        public List<course> SearchById(List<int> ids)
        {
            daCourse dac = new daCourse();
            return dac.SearchById(ids);
        }
    }
}

