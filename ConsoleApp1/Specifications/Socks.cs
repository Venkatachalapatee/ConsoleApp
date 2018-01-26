using System.Linq;

namespace ConsoleApp1.Specifications
{
    class Socks : IItem, ISpecification<Person>
    {
        public Socks(Condition condition)
        {
            Condition = condition;
        }

        public Condition Condition { get; }
        public string GetItemDescription()
        {
            return Condition == Condition.Hot ? "fail" : "socks";
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return Condition != Condition.Hot && !hasPj.Satisfies(t) &&
                   !t.Items.Any(s => s.GetType() == typeof(Socks)) &&
                   !t.Items.Any(s => s.GetType() == typeof(Footware));
        }
    }
}