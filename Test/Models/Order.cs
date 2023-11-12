using System.ComponentModel.DataAnnotations.Schema;
using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Models
{
    internal class Order
    {
        int _id;
        DateTime _date;
        protected decimal _sum;
        ICollection<OrderShoe> _orderShoe;
        public int Id { get { return _id; } private set { _id = value; } }
        public DateTime Date { get { return _date; } protected set { _date = value; } }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Sum { get { return _sum; } protected set { _sum = value; } }
        public ICollection<OrderShoe> OrderShoe { get { return _orderShoe; } protected set { _orderShoe = value; } }

        public Order()
        {
            _orderShoe = new List<OrderShoe>();
        }
        public Order(DateTime date, decimal sum):base()
        {
            _orderShoe = new List<OrderShoe>();
            _date = date;
            _sum = sum;
        }
    }
}
