using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class OrderBuyRepository : IRepository<OrderBuy>
    {
        StoreContext db;

        public OrderBuyRepository(StoreContext context)
        {
            db = context;
        }
        public void Create(OrderBuy item)
        {
            db.OrdersBuy.Add(item);
        }

        public void Delete(int id)
        {
            OrderBuy order = db.OrdersBuy.Find(id);
            if (order != null)
                db.OrdersBuy.Remove(order);
        }

        public IEnumerable<OrderBuy> Find(Func<OrderBuy, bool> predicate)
        {
            return db.OrdersBuy
                .Include(o => o.Product)
                .Include(o => o.OrderSell)
                .Where(predicate).ToList();
        }

        public OrderBuy Get(int id)
        {
            return db.OrdersBuy
                .Include(o => o.Product)
                .Include(o => o.OrderSell)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }

        public IEnumerable<OrderBuy> GetAll()
        {
            return db.OrdersBuy
                .Include(o => o.Product)
                .Include(o => o.OrderSell);
        }

        public void Update(OrderBuy item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
