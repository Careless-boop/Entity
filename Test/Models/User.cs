using Test.Models.Shoes;
using Test.Unifiers;

namespace Test.Models
{
    internal class User
    {
        int _id;
        ICollection<UserCart> _userCarts;
        ICollection<UserFavorite> _userFavorites;
        public int Id { get { return _id; } private set { _id = value; } }
        public ICollection<UserCart> UserCarts { get { return _userCarts; } private set { _userCarts = value; } }
        public ICollection<UserFavorite> UserFavorites { get { return _userFavorites; } private set { _userFavorites = value; } }
        public User()
        {
            _userCarts = new List<UserCart>();
            _userFavorites = new List<UserFavorite>();
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
        public void AddToFavorite(Shoe shoe)
        {
            var userFavorite = new UserFavorite(this, shoe);
            UserFavorites.Add(userFavorite);
        }
        public void RemoveFromFavorite(Shoe shoe)
        {
            UserFavorites.Remove(UserFavorites.FirstOrDefault(us => us.ShoeF == shoe));
        }
    }
}


