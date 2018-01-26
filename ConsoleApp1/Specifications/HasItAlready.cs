using System;
using System.Linq;

namespace ConsoleApp1.Specifications
{
    class HasItAlready : ISpecification<Person>
    {
        private readonly Type _itemType;

        public HasItAlready(Type itemType)
        {
            this._itemType = itemType;
        }
        public bool Satisfies(Person t)
        {
            return t.Items.AsEnumerable().Any(s => s.GetType() == _itemType);
        }
    }
}