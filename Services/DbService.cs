using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketPlace.Models.ProductModels;
using MarketPlace.Models.UsersModels;
using MarketPlace.Models;
using Microsoft.AspNetCore.Identity;
namespace MarketPlace.Services
{
    public class DbService
    {
        const int numOnePageProd = 10;
        readonly MarkePlacetDb _db;
        public DbService(MarkePlacetDb db)
        {
            _db = db;
        }
        public void AddProduct(ProductModel product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
        }
        public IEnumerable<ProductModel> GetProducts(int page = 1)
        {
            var count = numOnePageProd * page;
            var res = _db.Products.Take(count);
            return res; 
        }
        public ProductModel GetProductById(int id)
        {
            return _db.Products.Find(id);
        }
        public void AddScore(int addScore, int id)
        {
            // sumScore/num = score; 
            // num * score = sumScore
            // (sumScore + new) / num + 1 = newScore
            var prd = GetProductById(id);
            var score = prd.Score;
            var scored = prd.Scored;
            var sum = score * scored;
            var newScore = (sum + addScore) / ++prd.Scored;
            prd.Score = newScore;
            _db.Update(prd);
            _db.SaveChanges();
        }
        
        public void AddUser()
        {
            
        }
    }
}
