using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Test.Unifiers;

namespace Test.Models.Shoes
{
    internal abstract class Shoe
    {
        protected int _id;
        protected string _name;
        protected string _brand;
        protected decimal _price;
        protected ICollection<UserCart> _userCarts;
        protected ICollection<UserFavorite> _userFavorites;
        protected ICollection<OrderShoe> _orderShoe;

        public int Id { get { return _id; } private set { _id = value; } }
        [DefaultValue("NAME")]
        public string Name { get { return _name; } private set { _name = value; } }
        [MaxLength(20)]
        public string? Brand { get { return _brand; } private set { _brand = value; } }
        [Required]
        public decimal Price { get { return _price; } private set { _price = value; } }
        public ICollection<UserCart> UserCarts { get { return _userCarts; } private set { _userCarts = value; } }
        public ICollection<UserFavorite> UserFavorites { get { return _userFavorites; } private set { _userFavorites = value; } }
        public ICollection<OrderShoe> OrderShoe { get { return _orderShoe; } private set { _orderShoe = value; } }
        public Shoe()
        {
            _userCarts = new List<UserCart>();
            _userFavorites= new List<UserFavorite>();
            _orderShoe= new List<OrderShoe>();
        }
        public Shoe(string name, string brand, decimal price):base()
        {
            _name = name;
            _brand = brand;
            _price = price;
        }

        public abstract void Show();
        public abstract override string ToString();
    }
}
