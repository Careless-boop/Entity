using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models;
using Test.Models.Shoes;

namespace Test.Managers
{
    internal class UserManager
    {
        public static void ShowCart(User user)
        {
            int select = 1;
            int page = 0;
            while (select != 0)
            {
                List<Shoe>[] cartPages = ShoeManager.ManagePages(user.UserCarts.Select(uc=>uc.ShoeC).ToList());
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Write("Cart");
                select = ShoeManager.ShowPages(user, cartPages, ref page, Cart_ManageChosen);
            }
        }
        public static void ShowFavorites(User user)
        {
            int select = 1;
            int page = 0;
            while (select != 0)
            {
                List<Shoe>[] cartPages = ShoeManager.ManagePages(user.UserFavorites.Select(uf => uf.ShoeF).ToList());
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Write("Favorites");
                select = ShoeManager.ShowPages(user, cartPages, ref page, Favorites_ManageChosen);
            }
        }
        static void Cart_ManageChosen(User user, Shoe shoe)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                shoe.Show();
                Console.WriteLine($"0. Return\n1. Remove from cart\n");
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint select) && select < 2)
                {
                    if (select == 0)
                    {
                        return;
                    }
                    else if (select == 1)
                    {
                        user.RemoveFromCart(shoe);
                        return;
                    }
                }

            }
        }
        static void Favorites_ManageChosen(User user, Shoe shoe)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                shoe.Show();
                Console.WriteLine($"0. Return\n1. Remove from favorites\n2. Add to cart");
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint select) && select < 3)
                {
                    if (select == 0)
                    {
                        return;
                    }
                    else if (select == 1)
                    {
                        user.RemoveFromFavorite(shoe);
                        return;
                    }
                    else
                    {
                        user.AddToCart(shoe);
                        Console.Clear();
                        Console.WriteLine("Added to cart!!!" +
                                          "Press any button...");
                        Console.ReadKey();
                    }
                }

            }
        }
    }
}
