using B.E;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class daOrder
    {
        public void Create(Order o)
        {
            DB db = new DB();
            db.Orders.Add(o);
            db.SaveChanges();
        }
        public List<Order> getall()
        {
            DB db = new DB();
            var q = from i in db.Orders select i;
            return q.ToList();
        }
        public List<Order> getskip(int c)
        {
            int t = c * 10;
            DB dB = new DB();
            var q = dB.Orders.Skip(t).Take(10);
            return q.ToList();
        }
        public Order SearchById(int id)
        {
            DB db = new DB();
            var q = from i in db.Orders
                    where i.id == id
                    select i;
            return q.SingleOrDefault();
        }   
        public void DeleteOrder(int id)
        {
            DB dB = new DB();
            var Order = dB.Orders.FirstOrDefault(c => c.id == id);
            if (Order != null)
            {
                dB.Orders.Remove(Order);
                dB.SaveChanges();
            }
        }
    }
}
