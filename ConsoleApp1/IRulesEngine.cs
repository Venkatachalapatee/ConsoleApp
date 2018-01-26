using System.Collections.Generic;

namespace ConsoleApp1
{
    public interface IRulesEngine<T>
    {
        Condition Condition { get; }

        IEnumerable<string> ExecuteCommand(IEnumerable<string> commands, T t);


    }
}