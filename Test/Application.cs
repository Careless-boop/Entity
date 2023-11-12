using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Managers;
using Test.Models;

namespace Test
{
    internal class Application
    {
        public static void Run()
        {
            using(ShoeContext db = new ShoeContext())
            {
                User user;
                int tempId;
                do
                {
                    Console.Write("Enter your user Id (or 0 for new user):");
                    tempId = int.Parse(Console.ReadLine());
                    Console.Clear();
                } while (tempId != 0 && !db.Users.Any(u => u.Id == tempId));
                if (tempId == 0)
                {
                    user = new User();
                    db.Users.Add(user);
                }
                else
                {
                    user = db.Users.Include(u => u.UserCarts).ThenInclude(uc => uc.ShoeC).Include(u=>u.UserFavorites).ThenInclude(uf=>uf.ShoeF).First(u => u.Id == tempId);
                }
                uint select = 0;
                while (select != 4)
                {
                    Console.WriteLine("Select option:\n" +
                                      "0.See available shoes.\n" +
                                      "1.See favorites.\n" +
                                      "2.See cart.\n" +
                                      (user.UserCarts.Count > 0 ? "3.Purchase cart\n" : string.Empty) +
                                      "4.Exit!");
                    if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out select) && select < 5)
                    {
                        switch (select)
                        {
                            case 0:
                                ShoeManager.ShowAvailable(user, db);
                                break;
                            case 1:
                                UserManager.ShowFavorites(user);
                                break;
                            case 2:
                                UserManager.ShowCart(user);
                                break;
                            case 3:
                                if (user.UserCarts.Count > 0)
                                    OrderManager.ShowOrder(user, db);
                                break;
                            case 4:
                                break;
                        }
                    }
                    Console.Clear();
                }
                db.SaveChanges();
            }
            
        }
    }
}
