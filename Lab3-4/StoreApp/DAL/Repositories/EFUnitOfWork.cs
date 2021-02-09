using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork,
        IDisposable
    {
        private StoreContext db;


        private ProductRepository productRepository;
        private OrderBuyRepository orderBuyRepository;
        private OrderSellRepository orderSellRepository;
        //private StoreRepository storeRepository;

        public EFUnitOfWork(StoreContext context)
        {
            db = context;
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }

        public IRepository<OrderBuy> OrdersBuy
        {
            get
            {
                if (orderBuyRepository == null)
                    orderBuyRepository = new OrderBuyRepository(db);
                return orderBuyRepository;
            }
        }

        public IRepository<OrderSell> OrdersSell
        {
            get
            {
                if (orderSellRepository == null)
                    orderSellRepository = new OrderSellRepository(db);
                return orderSellRepository;
            }
        }

 
        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
