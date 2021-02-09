using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> Products { get; }

        IRepository<OrderBuy> OrdersBuy { get; }

        IRepository<OrderSell> OrdersSell { get; }

        void Save();
    }
}
