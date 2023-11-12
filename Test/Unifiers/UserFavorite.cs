using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Models.Shoes;
using Test.Models;

namespace Test.Unifiers
{
    internal class UserFavorite
    {
        int _userId;
        int _shoeFId;
        User _user;
        Shoe _shoeF;
        public int UserId { get { return _userId; } private set { _userId = value; } }
        public User User { get { return _user; } private set { _user = value; } }
        public int ShoeFId { get { return _shoeFId; } private set { _shoeFId = value; } }
        public Shoe ShoeF { get { return _shoeF; } private set { _shoeF = value; } }
        public UserFavorite()
        {

        }
        public UserFavorite(User user, Shoe shoeC)
        {
            _user = user;
            _shoeF = shoeC;
        }
    }
}
