using System.Linq;

namespace ConsoleApp1.Specifications
{
    public class Pants :IItem, ISpecification<Person>
    {
        private readonly Condition _condition;

        public Pants(Condition condition)
        {
            _condition = condition;
        }
        public string GetItemDescription()
        {
            return _condition == Condition.Hot ? "shorts" : "pants";
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return !hasPj.Satisfies(t) && !t.Items.Any(s => s.GetType() == typeof(Footware)) &&
                   !t.Items.Any(s => s.GetType() == typeof(Pants));

        }
    }
}