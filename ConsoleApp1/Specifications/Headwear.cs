using System.Linq;

namespace ConsoleApp1.Specifications
{
    class Headwear : IItem, ISpecification<Person>
    {
        public Headwear(Condition condition)
        {
            Condition = condition;
        }

        public Condition Condition { get; }

        public string GetItemDescription()
        {
            return Condition == Condition.Hot ? "sunglasses" : "hat";
        }

        public bool Satisfies(Person t)
        {
            return t.Items.Any(s => s.GetType() == typeof(Shirt));
        }
    }
}