using BLL;
using Microsoft.AspNetCore.Mvc;
namespace ProjectTerm2.viewcomponents.course
{
    public class ListCourseViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            blCourse blc = new blCourse();
            var courses = blc.readByTeachers();
            return View(courses);
        }
    }
}
