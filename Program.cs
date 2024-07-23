using System.Configuration;
using System.Text.Json;
using System.Xml;
using SerializationDeserializationOfList.Models;

namespace SerializationDeserializationOfList
{
    internal class Program
    {   
        public static string filePath = ConfigurationManager.AppSettings["filePath"].ToString();
        static void Main(string[] args)
        {
            List<Person> persons;

            if (File.Exists(filePath))
            {
                persons = DeserializePersons();
                Console.WriteLine($"Deserialize Person count : {persons.Count}");
    
            }
            else
            {
                persons = CreateDefaultPersons();
                SerializePersons(persons);
                Console.WriteLine("Serialized 5 default persons");
               
            }
            PrintDetails(persons);

        }

        static void PrintDetails(List<Person> persons)
        {
            foreach (var person in persons)
            {
                Console.WriteLine($"Id: {person.Id}, Name: {person.Name}, Email: {person.Email}");
            }
        }

        static List<Person> DeserializePersons()
        {

            string deserialized = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Person>>(deserialized)!;
        }

        static void SerializePersons(List<Person> persons)
        {
            
            string serialized = JsonSerializer.Serialize(persons);
            File.WriteAllText(filePath, serialized);
        }

        static List<Person> CreateDefaultPersons()
        {
            return new List<Person>
            {
                new Person { Id = 1, Name = "Samuel ", Email = "samuel@gmail.com" },
                new Person { Id = 2, Name = "Halo", Email = "halo@gmail.com" },
                new Person { Id = 3, Name = "Saroj", Email = "saroj@gmail.com" },
                new Person { Id = 4, Name = "Arjun",Email = "arjun@gmail.com" },
                new Person { Id = 5, Name = "Nimith", Email = "nimith@gmail.com" }
            };
        }
    }   
}
