using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Models
{
    internal class User
    {
        int _id;
        ICollection<UserCart> _userCarts;
        public int Id { get { return _id; } private set { _id = value; } }
        public ICollection<UserCart> UserCarts { get { return _userCarts; } private set { _userCarts = value; } }
        public User()
        {
            _userCarts = new List<UserCart>();
        }
        public void AddToCart(Shoe shoe)
        {
            var userCart = new UserCart(this,shoe);
            UserCarts.Add(userCart);
        }
        public void RemoveFromCart(Shoe shoe)
        {
            UserCarts.Remove(UserCarts.FirstOrDefault(us => us.ShoeC == shoe));
        }
        public void ClearCart()
        {
            UserCarts.Clear();
        }
    }
}


