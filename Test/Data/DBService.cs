using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Shoes;

namespace Test.Data
{
    internal class DBService
    {
        public List<Shoe> GetShoes(ShoeContext db)
        {
            return db.Shoes.ToList();
        }
    }
}
