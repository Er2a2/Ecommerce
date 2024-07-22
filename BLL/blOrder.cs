using B.E;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class blOrder
    {
        public void Create(Order o)
        {
            daOrder dao=new daOrder();
            dao.Create(o);
        }
        public List<Order> getall()
        {
            daOrder dao = new daOrder();
            return dao.getall();
        }
        public List<Order> getskip(int c)
        {
            daOrder dao = new daOrder();
            return dao.getskip(c);
        }
        public Order SearchById(int id)
        {
            daOrder dao = new daOrder();
            return dao.SearchById(id);
        }
        public void DeleteOrder(int id)
        {
            daOrder dao = new daOrder();
            dao.DeleteOrder(id);
        }
    }
}
