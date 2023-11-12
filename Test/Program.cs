using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;
using Test.Models.Shoes;
using Test.Unifiers;

using (ShoeContext db = new ShoeContext())
{
    /*List<Shoe> shoes = new List<Shoe>();
    shoes.Add(new HikingShoes("hiking 1", 6000.99m, true));
    shoes.Add(new Sandals("sandals 1", 2000.3m, 15));
    shoes.Add(new HikingShoes("hiking 2", 5500, false));
    shoes.Add(new Sandals("sandals 2", 1200.99m, 5));
    shoes.Add(new SportShoes("sport 1", 2200,Height.Low));
    shoes.Add(new SportShoes("sport 2", 3099.99m, Height.High));*/
    User user;
    int tempId;
    do
    {
        Console.Write("Enter your user Id:");
        tempId = int.Parse(Console.ReadLine());
    } while (tempId != 0 && !db.Users.Any(u => u.Id == tempId));
    if (tempId == 0)
    {
        user = new User();
        db.Users.Add(user);
    }
    else
    {
        user = db.Users.Include(u => u.UserCarts).ThenInclude(uc=>uc.ShoeC).First(u => u.Id == tempId);
    }
    foreach(UserCart shoe in user.UserCarts)
    {
        shoe.ShoeC.Show();
    }
    Console.WriteLine("-------------------------");
    List<Shoe> shoes = db.Shoes.ToList();
    foreach(Shoe shoe in shoes)
    {
        Console.Write(shoes.IndexOf(shoe)); shoe.Show();
    }
    Console.Write("Shoe Id to add to cart:");   
    user.AddToCart(shoes[int.Parse(Console.ReadLine())]);
    Console.Clear();
    Console.WriteLine("Your order :");
    decimal sum = 0;
    foreach(UserCart uc in user.UserCarts)
    {
        uc.ShoeC.Show();
        sum += uc.ShoeC.Price;
    }
    Console.WriteLine($"----------------------\n" +
                      $"Total: {sum}\n" +
                      $"Press any button to proceed...");
    Console.ReadKey();
    Order order = new Order();
    order.PackOrder(user);
    db.Orders.Add(order);
    db.SaveChanges();
}