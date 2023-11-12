using System.ComponentModel.DataAnnotations.Schema;
using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Models
{
    internal class Order
    {
        int _id;
        DateTime _date;
        decimal _sum;
        ICollection<OrderShoe> _orderShoe;
        public int Id { get { return _id; }private set { _id = value; } }   
        public DateTime Date { get { return _date; } private set { _date = value; } }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sum { get { return _sum; } private set { _sum = value; } }
        public ICollection<OrderShoe> OrderShoe { get { return _orderShoe; } private set { _orderShoe = value; } }

        public Order()
        {
            _orderShoe = new List<OrderShoe>();
        } 
        public void PackOrder(User user)
        {
            _date = DateTime.Now;
            List<Shoe> shoes = user.UserCarts.Select(uc=>uc.ShoeC).ToList();
            decimal sum = 0;
            foreach(Shoe shoe in shoes)
            {
                OrderShoe.Add(new OrderShoe(this, shoe));
                sum += shoe.Price;
            }
            _sum = sum;
            user.ClearCart();
        }
    }
}
