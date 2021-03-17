using System.Collections.Generic;

namespace Database
{
    public static class InMemory
    {
        public static List<Student> Students = new List<Student> {
            new Student {
                Id = 1,
                StudentID = "48631",
                EmailAddress = "mike_@test.com"
            },
            new Student {
                Id = 2,
                StudentID = "54613",
                EmailAddress = "jane_@test.com"
            }
        };

         public static List<Instrutor> Instrutors = new List<Instrutor> {
            new Instrutor {
                Id = 1,
                FirstName = "Aaron",
                MiddleInitial = "W.",
                LastName = "Whistler"
            },
            new Instrutor {
                FirstName = "Jake",
                MiddleInitial = "B.",
                LastName = "Vandargeer"
            }
        };
    }
}