using ModelBindingsAndDataAnnotations.Models;

namespace ModelBindingsAndDataAnnotations.Database
{
    public static class StaticDb
    {
        public static List<Student> Students { get; set; }

        static StaticDb()
        {
            Students = new List<Student>()
            {
                new Student()
                {
                    Id = 1,
                    Firstname = "Petko",
                    Lastname = "Petkovski",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    Email = "p.petko@test.com",
                    PhoneNumber = "070123456",
                },
                new Student()
                {
                    Id = 2,
                    Firstname = "Trajko",
                    Lastname = "Trajkovski",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    Email = "t.trajkovski@test.com",
                    PhoneNumber = "070456789",
                },
                new Student()
                {
                    Id = 3,
                    Firstname = "Nikola",
                    Lastname = "Nikolovski",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    Email = "n.nikola@test.com",
                    PhoneNumber = "071789654",
                },

                new Student()
                {
                    Id = 4,
                    Firstname = "Stefan",
                    Lastname = "Stefanovski",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    Email = "s.stefan@test.com",
                    PhoneNumber = "071894561",
                },
            };
        }
    }
}
