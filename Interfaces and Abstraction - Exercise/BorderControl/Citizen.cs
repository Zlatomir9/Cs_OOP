namespace BorderControl
{
    public class Citizen : Robot, ICitizen 
    {
        public Citizen(string name, int age, string id, string birthdate) 
            : base(name, id)
        {
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public int Age { get; }

        public string Birthdate { get; }
    }
}
