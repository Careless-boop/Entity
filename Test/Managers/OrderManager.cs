using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Data;
using Test.Models;
using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Managers
{
    internal class OrderManager
    {
        public static void ShowOrder(User user,ShoeContext db)
        {
            Console.Clear();
            Console.WriteLine("Your order:");
            decimal sum = 0;
            foreach (Shoe shoe in user.UserCarts.Select(uc=>uc.ShoeC))
            {
                shoe.Show();
                sum += shoe.Price;
                Console.WriteLine("=================================");
            }
            Console.WriteLine($"Total: {sum}$");
            bool agree = Agreement();
            if (agree)
            {
                PackOrder(user, sum, db);
            }
            else
            {
                return;
            }
        }

        public static void PackOrder(User user,decimal sum,ShoeContext db)
        {
            List<Shoe> shoes = user.UserCarts.Select(uc => uc.ShoeC).ToList();
            Order order = new Order(DateTime.Now, sum);
            foreach (Shoe shoe in shoes)
            {
                order.OrderShoe.Add(new OrderShoe(order, shoe));
            }
            db.Orders.Add(order);
            user.ClearCart();
        }
        public static bool Agreement()
        {
            Console.WriteLine("Do you agree to purchase?\n0. Yes\n1. No");
            while (true)
            {
                uint select;
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out select) && select < 2)
                {
                    return select == 0 ? true : false;
                }
            }
        }
    }
}
