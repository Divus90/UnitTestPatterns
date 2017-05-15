namespace BaseProject.People
{
    public class PersonDto
    {
        public PersonDto(string name, string surname, int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

        public int Age { get; set; }
        public string Name { get; set; }

        public string Surname { get; set; }
    }
}