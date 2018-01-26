using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Specifications;

namespace ConsoleApp1
{
    // Note: We could created two Concrete Implmentation of IRuleEngine, one for Hot and other for Cold, 
    // and Created the Rule Engine using Factory Pattern, 
    class RulesEngine : IRulesEngine<Person>
    {
        private readonly Footware _footware;
        private readonly Pj _pj;
        private readonly Headwear _headwear;
        private readonly Socks _socks;
        private readonly Shirt _shirt;
        private readonly Jacket _jacket;
        private readonly Pants _pants;
        private readonly LeaveTheHouse _leaveTheHouse;

        public RulesEngine(Condition condition)
        {
            Condition = condition;
            _footware= new Footware(condition);
            _pj = new Pj(condition);
            _headwear = new Headwear(condition);
            _socks = new Socks(condition);
            _shirt = new Shirt(condition);
            _jacket = new Jacket(condition);
            _pants = new Pants(condition);
            _leaveTheHouse = new LeaveTheHouse(condition);
        }

        // Note: This functial approach to the problem, 
        // This is a Diplicate of HasItAlready(typeof(Pj)).Satisfies(person)
        private static readonly Func<Person, bool> HasPj = (person) =>
        {
            return person.Items.Select(s => s.GetType() == typeof(Pj)).Any();
        };

        private static readonly Func<Person, bool> RemovePj = person =>
        {
            if (HasPj(person))
            {
                person.Remove(typeof(Pj));
                return true;
            }
            else
            {
                return false;
            }
        };

        public Condition Condition { get; }

    
        public IEnumerable<string> ExecuteCommand(IEnumerable<string> commands, Person t)
        {
            List<string> toReturn = new List<string>();
            
            foreach (string command in commands)
            {
                bool commandExecuted = false;
                switch (command)
                {
                    case "8":
                        if (_pj.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_pj.GetItemDescription());
                            RemovePj(t);
                        }

                        break;
                    case "1":
                        if (_footware.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_footware.GetItemDescription());
                            t.Puton(_footware);
                        }

                        break;
                    case "2":
                        if (_headwear.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_headwear.GetItemDescription());
                            t.Puton(_headwear);
                        }

                        break;
                    case "3":
                        if (_socks.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_socks.GetItemDescription());
                            t.Puton(_socks);
                        }

                        break;
                    case "4":
                        if (_shirt.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_shirt.GetItemDescription());
                            t.Puton(_shirt);
                        }

                        break;
                    case "5":
                        if (_jacket.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_jacket.GetItemDescription());
                            t.Puton(_jacket);
                        }

                        break;
                    case "6":
                        if (_pants.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_pants.GetItemDescription());
                            t.Puton(_pants);
                        }

                        break;
                    case "7":
                        if (_leaveTheHouse.Satisfies(t))
                        {
                            commandExecuted = true;
                            toReturn.Add(_leaveTheHouse.GetItemDescription());
                            t.Puton(_leaveTheHouse);
                        }

                        break;
                }

                if (!commandExecuted)
                {
                    toReturn.Add("fail");
                    break;
                }
            }

            return toReturn;
        }
    }
}