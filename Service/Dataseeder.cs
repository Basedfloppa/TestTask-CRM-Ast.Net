using TestTask.db;
using System.Web;
public class DataSeeder
{
    public static void SeedData()
    {
        var context = new ClientsContext();
        context.Database.EnsureCreated();
        if (!context.Users.Any())
        {
            var users = new List<User> {};
            for(int i = 0; i < 10; i++)
            {
                var user = new User { Fio = Faker.Name.FullName(), Password = Guid.NewGuid().ToString("d").Substring(0,7), Login = Faker.Internet.UserName() };
                users.Add(user);
            }

            var clients = new List<Client> {} ;
            for(int i = 0; i < 10; i++)
            {
                var client = new Client { AccountNumber = Faker.Phone.Number(),
                                        BirthDate = DateOnly.FromDateTime(Faker.Identification.DateOfBirth()),
                                        FirstName = Faker.Name.First(), 
                                        LastName = Faker.Name.Last(),
                                        SurName = Faker.Name.Middle(), 
                                        Inn = Faker.RandomNumber.Next(10000000000000000,99999999999999999).ToString(), 
                                        Responsible = users[Faker.RandomNumber.Next(0,9)].Fio
                                        };
                clients.Add(client);
            } 

            context.AddRange(clients);
            context.AddRange(users);
            context.SaveChanges();
        }
    }
}