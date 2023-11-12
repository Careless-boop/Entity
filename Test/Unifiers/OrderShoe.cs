using Test.Models;
using Test.Models.Shoes;

namespace Test.Unifiers
{
    internal class OrderShoe
    {
        int _orderId;
        int _shoeId;
        Order _order;
        Shoe _shoe;
        public int OrderId { get { return _orderId; } private set { _orderId = value; } }
        public Order Order { get { return _order; } private set { _order = value; } }
        public int ShoeId {  get { return _shoeId; } private set { _shoeId = value;} }
        public Shoe Shoe { get { return _shoe; } private set { _shoe = value; } }
        public OrderShoe()
        {

        }
        public OrderShoe(Order order, Shoe shoe)
        {
            _order = order;
            _shoe = shoe;
        }
    }
}
