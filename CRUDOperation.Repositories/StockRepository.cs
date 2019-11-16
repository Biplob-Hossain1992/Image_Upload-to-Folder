using CRUDOperation.Abstractions.Repositories;
using CRUDOperation.DatabaseContext;
using CRUDOperation.Models;
using CRUDOperation.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRUDOperation.Repositories
{
    public class StockRepository: EFRepository<Stock>, IStockRepository
    {

        private CRUDOperationDbContext _db;

        public StockRepository(DbContext dbContext) : base(dbContext)
        {
            _db = dbContext as CRUDOperationDbContext;
        }


        public override ICollection<Stock> GetAll() //Just added product in stock for show the product name in stock table.
        {
            return _db.Stocks
                      .Include(c => c.Product)
                      .ToList();
        }
        public List<Stock> GetByProduct(int productId) /*Dropdown List Binding*/
        {
            return _db.Stocks
                .Where(s => s.ProductId == productId)
                .ToList();
        }
    }
}
