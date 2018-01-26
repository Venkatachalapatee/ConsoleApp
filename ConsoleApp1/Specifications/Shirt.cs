using System.Linq;

namespace ConsoleApp1.Specifications
{
    class Shirt : IItem, ISpecification<Person>
    {
        public Shirt(Condition condition)
        {
            Condition = condition;
        }

        public Condition Condition { get; }

        public string GetItemDescription()
        {
            return "shirt";
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return !hasPj.Satisfies(t) && !t.Items.Any(s => s.GetType() == typeof(Shirt)) && (
                       !t.Items.Any(s => s.GetType() == typeof(Headwear))||
                       !t.Items.Any(s => s.GetType() == typeof(Jacket))
                   );

        }


    }
}