using System.Linq;

namespace ConsoleApp1.Specifications
{
    class Jacket : IItem, ISpecification<Person>
    {
        public Jacket(Condition icondition)
        {
            Condition = icondition;
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return Condition != Condition.Hot && !t.Items.Any(s => s.GetType() == typeof(Jacket)) && !hasPj.Satisfies(t);
        }

        public Condition Condition { get; }
        public string GetItemDescription()
        {
            if (Condition == Condition.Hot) return "fail";
            else return "jacket";
        }
    }
}