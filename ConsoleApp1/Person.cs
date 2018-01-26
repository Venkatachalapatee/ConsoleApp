using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Specifications;

namespace ConsoleApp1
{
    public class Person
    {
        private readonly Condition Condition;

        public readonly IList<IItem> Items = new List<IItem>();

        public Person(Condition condition)
        {
            Condition = condition;
            Items.Add(new Pj(Condition));
        }

        public void Remove(IItem item)
        {
            Items.Remove(Items.First(s => s.GetType() == item.GetType()));
        }

        public void Remove(Type itemtype)
        {
            Items.Remove(Items.First(s => s.GetType() == itemtype));
        }

        public void Puton(IItem item)
        {
            Items.Add(item);
        }
    }
}