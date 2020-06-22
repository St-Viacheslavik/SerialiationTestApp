using System;

namespace SerializationTest
{
    [Serializable] //serialization
    public class WorkPlace
    {
        public int WorkGroup { get; set; }

        public string Name { get; set; }

        public WorkPlace() { }

        public WorkPlace(int workGroup, string name)
        {
            WorkGroup = workGroup;
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
