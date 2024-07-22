using Microsoft.AspNetCore.Mvc;
namespace ProjectTerm2.viewcomponents.user
{
    public class TeachersViewComponent:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            BLL.blteacher blt = new BLL.blteacher();
            return View ("_Teachers",blt.read());
        } 
    }
}
