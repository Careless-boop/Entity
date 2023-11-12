using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models.Shoes
{
    enum CushioningLevel
    {
        Low = 1,
        LowPlus,
        Medium,
        MediumPlus,
        High
    };
    [Table("SportShoes")]
    internal class SportShoes : Shoe
    {
        CushioningLevel _cushioning;
        bool _haveArchSupport;
        [Column(TypeName = "nvarchar(20)")]
        [EnumDataType(typeof(CushioningLevel))]
        public CushioningLevel Cushioning { get { return _cushioning; } private set { _cushioning = value; } }
        public bool HaveArchSupport { get { return _haveArchSupport; } private set { _haveArchSupport = value; } }

        public SportShoes(string name, string brand, decimal price, CushioningLevel cushioning, bool haveArchSupport) : base(name, brand, price)
        {
            _cushioning = cushioning;
            _haveArchSupport = haveArchSupport;
        }

        public override void Show()
        {
            Console.WriteLine($"Trainers -\nBrand: {_brand}\nName: {Name}\nCushioning: {_cushioning}\nArch Support:{new string(_haveArchSupport ? "Yes" : "No")}\nPrice: {Price}");
        }
        public override string ToString()
        {
            return $"Trainers -\nBrand: {_brand}\nName: {Name}\nCushioning: {_cushioning}\nArch Support:{new string(_haveArchSupport ? "Yes" : "No")}\nPrice: {Price}";
        }
    }
}
