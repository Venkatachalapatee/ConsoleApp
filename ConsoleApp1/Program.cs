using System;
using System.Linq;
using ConsoleApp1.Specifications;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = "COLD 8, 6, 3, 4, 2, 5, 1, 7";
            //var input = "HOT 8, 6, 4, 2, 1, 7";
            //var input = "HOT 8, 6, 6";
            var input = "HOT 8, 6, 3";
            var commands = input.Split( new []{',', ' '}, StringSplitOptions.RemoveEmptyEntries);
            var condition = (commands[0] == "HOT") ? Condition.Hot :
                (commands[0] == "COLD") ? Condition.Cold : Condition.Invalid;
            var commandsToExecute = commands.Skip(1).Select(s => s);

            Console.WriteLine(commandsToExecute);

            // Note: We could created two Concrete Implmentation of IRuleEngine, one for Hot and other for Cold, 
            // May Creat the Rule Engine using Factory Pattern, 
            IRulesEngine<Person> rulesEngine = new RulesEngine(condition);

            // Create Person
            Person person = new Person(condition);

            // Execute the Command using Rule Engine, 
            var ss =  rulesEngine.ExecuteCommand(commandsToExecute, person);
            Console.WriteLine(String.Join(",", ss));
            
            Console.ReadLine();

        }
    }
}
