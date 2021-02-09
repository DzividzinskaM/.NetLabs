using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositories
{
    class OrderSellRepository : IRepository<OrderSell>
    {
        StoreContext db;

        public OrderSellRepository(StoreContext context)
        {
            db = context;
        }

        public void Create(OrderSell item)
        {
            db.OrdersSell.Add(item);
        }

        public void Delete(int id)
        {
            OrderSell order = db.OrdersSell.Find(id);
            if (order != null)
                db.OrdersSell.Remove(order);
        }

        public IEnumerable<OrderSell> Find(Func<OrderSell, bool> predicate)
        {
            return db.OrdersSell
                .Include(o => o.Product)
                .Include(o => o.OrderBuy)
                .Where(predicate)
                .ToList();
        }

        public OrderSell Get(int id)
        {
            return db.OrdersSell
                .Include(o => o.Product)
                .Include(o => o.OrderBuy)
                .Where(o => o.Id == id).FirstOrDefault();
        }

        public IEnumerable<OrderSell> GetAll()
        {
            return db.OrdersSell
                .Include(o => o.Product)
                .Include(o => o.OrderBuy);
        }

        public void Update(OrderSell item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
