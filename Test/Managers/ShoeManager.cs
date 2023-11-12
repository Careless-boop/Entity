using Test.Data;
using Test.Models;
using Test.Models.Shoes;

namespace Test.Managers
{
    internal class ShoeManager
    {
        public delegate void ManagingChosen(User user, Shoe shoe);
        public static void ShowAvailable(User user,ShoeContext db)
        {
            DBService dbService = new DBService();
            List<Shoe> temp = dbService.GetShoes(db);

            List<Shoe>[] shoes = ManagePages(temp);
            int select = 1;
            int page = 0;
            while (select != 0)
            {
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                Console.Write("Available shoes");
                select = ShowPages(user, shoes, ref page, Shoe_ManageChosen);
            }
        }
        public static int ShowPages(User user, List<Shoe>[] shoes, ref int page, ManagingChosen manageChosen)
        {
            int select = 0;
            if (page + 1 > shoes.Length)
            {
                page--;
            }

            if (page == 0 && shoes.Length == 1)
            {
                Console.WriteLine("\n0.Return");
                ShowPage(shoes[page]);
                select = ChooseShown(user, shoes[page], manageChosen);
            }
            else if (page == 0 && shoes.Length > 1)
            {
                Console.WriteLine($" (page:{page}):\n0.Return 5.Next page->");
                ShowPage(shoes[page]);
                select = ChooseShown(user, shoes[page], manageChosen);
                if (select == 5)
                {
                    page++;
                }
            }
            else if (page > 0 && page + 1 != shoes.Length)
            {
                Console.WriteLine($" (page:{page}):\n0.Return 5.Prev page<- 6.Next page->");
                ShowPage(shoes[page]);
                select = ChooseShown(user, shoes[page], manageChosen);
                if (select == 5)
                {
                    page--;
                }
                else if (select == 6)
                {
                    page++;
                }
            }
            else if (page > 0 && page + 1 == shoes.Length)
            {
                Console.WriteLine($" (page:{page}):\n0.Return 5.Prev page<-");
                ShowPage(shoes[page]);
                select = ChooseShown(user, shoes[page], manageChosen);
                if (select == 5)
                {
                    page--;
                }
            }
            return select;
        }
        static void ShowPage(List<Shoe> shoePage)
        {
            foreach (Shoe shoe in shoePage)
            {
                Console.Write(shoePage.IndexOf(shoe) + 1 + ".");
                shoe.Show();
                Console.WriteLine("===========================");
            }
        }
        public static List<Shoe>[] ManagePages(List<Shoe> temp)
        {
            int pgcount = temp.Count % 4 == 0 ? temp.Count / 4 : (temp.Count / 4) + 1;
            List<Shoe>[] pages = new List<Shoe>[pgcount];
            if (pgcount > 0) pages[0] = new List<Shoe>();
            int i = 0;
            int j = 0;
            foreach (Shoe shoe in temp)
            {
                if (j == 4)
                {
                    i++;
                    pages[i] = new List<Shoe>();
                    j = 0;
                }
                pages[i].Add(shoe);
                j++;
            }
            return pages;
        }
        static int ChooseShown(User user, List<Shoe> shoes, ManagingChosen managingChosen)
        {
            uint choose;
            while (true)
            {
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out choose) && choose <= shoes.Count)
                {
                    if (choose == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("\u001b[2J\u001b[3J");
                        return 0;
                    }
                    else
                    {
                        managingChosen(user, shoes.ElementAt((int)choose - 1));
                        return 1;
                    }
                }
                else if (choose == 5 || choose == 6)
                {
                    return (int)choose;
                }

            }
        }
        static void Shoe_ManageChosen(User user, Shoe shoe)
        {
            uint select;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\u001b[2J\u001b[3J");
                shoe.Show();
                Console.WriteLine($"0. Return\n1. Add to cart\n" +
                              $"{(user.UserFavorites.Select(uf => uf.ShoeF).Contains(shoe) ? "2. Remove from favorites" : "2. Add to favorites")}");
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out select) && select < 3)
                {
                    if (select == 0)
                    {
                        return;
                    }
                    else if (select == 1)
                    {
                        user.AddToCart(shoe);
                        Console.Clear();
                        Console.WriteLine("Added to cart!!!" +
                                          "Press any button...");
                        Console.ReadKey();
                    }
                    else
                    {
                        if (user.UserFavorites.Select(uf=>uf.ShoeF).Contains(shoe))
                        {
                            user.RemoveFromFavorite(shoe);
                        }
                        else
                        {
                            user.AddToFavorite(shoe);
                        }
                    }
                }

            }
        }
    }
}
