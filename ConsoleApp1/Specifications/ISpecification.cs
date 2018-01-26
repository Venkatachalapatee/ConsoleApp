namespace ConsoleApp1.Specifications
{
    
    internal interface ISpecification<in T>
    {
        bool Satisfies(T t);

        
    }
}