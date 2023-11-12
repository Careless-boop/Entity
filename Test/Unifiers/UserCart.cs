using Test.Models;
using Test.Models.Shoes;

namespace Test.Unifiers
{
    internal class UserCart
    {
        int _userId;
        int _shoeCId;
        User _user;
        Shoe _shoeC;
        public int UserId { get { return _userId; } private set { _userId = value; } }
        public User User { get { return _user; }private set { _user = value; } }
        public int ShoeCId { get { return _shoeCId; }private set { _shoeCId = value; } }
        public Shoe ShoeC { get { return _shoeC; } private set { _shoeC = value; } }
        public UserCart() 
        {

        }
        public UserCart(User user,Shoe shoeC)
        {
            _user = user;
            _shoeC= shoeC;
        }
    }
}
