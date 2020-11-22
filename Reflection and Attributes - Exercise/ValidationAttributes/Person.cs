namespace ValidationAttributes
{
    public class Person
    {
        public Person(string fullName, int age)
        {
            this.FullName = fullName;
            this.Age = age;
        }

        [MyRangeAttribute(12, 90)]
        public int Age { get; set; }
        [MyRequiredAttribute]
        public string FullName { get; set; }
    }
}
