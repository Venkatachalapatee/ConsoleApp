namespace ConsoleApp1.Specifications
{
    class Pj : IItem, ISpecification<Person>
    {
        public Pj(Condition condition)
        {
            Condition = condition;
        }

        public Condition Condition { get; }
        public string GetItemDescription()
        {
            return "Removing PJs";
        }

        public bool Satisfies(Person t)
        {
            HasItAlready hasPj = new HasItAlready(typeof(Pj));
            return hasPj.Satisfies(t);
        }
        
    }

 
}