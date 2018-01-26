using System.Linq;

namespace ConsoleApp1.Specifications
{
    class Footware : IItem, ISpecification<Person>
    {
        public Footware(Condition icondition)
        {
            Condition = icondition;
            
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return !hasPj.Satisfies(t) && !t.Items.Any(s => s.GetType() == typeof(Footware));
        }

        public Condition Condition { get; }
        public string GetItemDescription()
        {
            if (Condition == Condition.Hot) return "sandals";
            else return "boots";
        }
    }
}