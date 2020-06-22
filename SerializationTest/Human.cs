using System.Runtime.Serialization;

namespace SerializationTest
{
    [DataContract] //JSON serialization
    public class Human
    {
        [DataMember]
        public string Name { get; set; }
        
        [DataMember]
        public int Salary { get; set; }

        [DataMember]
        public  WorkPlace WorkPlace { get; set; }

        public Human() { }

        public Human(string name, int salary)
        {
            Name = name;
            Salary = salary;
        }

        public override string ToString()
        {
            return Name + " " + Salary.ToString() + " " + WorkPlace.Name;
        }
    }
}
