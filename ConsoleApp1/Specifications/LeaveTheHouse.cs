using System.Linq;

namespace ConsoleApp1.Specifications
{
    public class LeaveTheHouse : IItem, ISpecification<Person>
    {
        public Condition Condition { get; }

        public LeaveTheHouse(Condition condition)
        {
            Condition = condition;
        }
        public bool Satisfies(Person t)
        {
            return t.Items.Any(s => s.GetType() == typeof(Footware))&&
                   t.Items.Any(s => s.GetType() == typeof(Headwear))&&
                   (Condition == Condition.Hot || (Condition == Condition.Cold  && t.Items.Any(s => s.GetType() == typeof(Socks)))) &&
                   t.Items.Any(s => s.GetType() == typeof(Shirt))&&
                   (Condition == Condition.Hot || (Condition == Condition.Cold && t.Items.Any(s => s.GetType() == typeof(Jacket)))) &&
                   t.Items.Any(s => s.GetType() == typeof(Pants));
        }

        public string GetItemDescription()
        {
            return "Leave the house";
        }
    }
}