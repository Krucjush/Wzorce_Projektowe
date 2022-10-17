using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace WzorzecAdapter
{
    //KOD Z ZEWNĘTRZNEJ BIBLIOTEKI
    public class UsersApi
    {
        public async Task<string> GetUsersXmlAsync()
        {
            var apiResponse = "<?xml version= \"1.0\" encoding= \"UTF-8\"?><users><user name=\"John\" surname=\"Doe\"/><user name=\"John\" surname=\"Wayne\"/><user name=\"John\" surname=\"Rambo\"/></users>";

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(apiResponse);

            return await Task.FromResult(doc.InnerXml);
        }
    }


    public class UsersCsv
    {
        public async Task<string> GetUsersCsvAsync()
        {
            string path = @"C:\Users\hiewi\Downloads\users.csv";
            string[] lines = File.ReadAllLines(path);
            string output = "";
            foreach (var line in lines)
            {
                string[] columns = line.Split(',');
                var i = 1;
                foreach (var column in columns)
                {
                    output += column;
                    if (i == 1)
                    {
                        output += " ";
                        i = 2;
                    }
                    else
                    {
                        output += "\n";
                        i = 1;
                    }
                }

            }

            return await Task.FromResult(output.Remove(output.Length-1));
        }
        
    }

    //
    // tu trzeba dopisać klasę zwracającą zawartość pliku csv w postaci stringa
    // (jednego długiego, rozdzielanego znakami nowego wiersza)
    //


    public interface IUserRepository
    {
        List<List<string>> GetUserNames();
    }

    public class UsersApiAdapter : IUserRepository
    {
        private UsersApi _adaptee = null;

        public UsersApiAdapter(UsersApi adaptee)
        {
            _adaptee = adaptee;
        }

        public List<List<string>> GetUserNames()
        {
            string incompatibleApiResponse = this._adaptee
              .GetUsersXmlAsync()
              .GetAwaiter()
              .GetResult();

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(incompatibleApiResponse);

            var rootEl = doc.LastChild;

            List<List<string>> users = new List<List<string>>();

            if (rootEl.HasChildNodes)
            {
                List<string> user = new List<string> { };
                foreach (XmlNode node in rootEl.ChildNodes)
                {
                    user = new List<string> { node.Attributes["name"].InnerText, node.Attributes["surname"].InnerText };
                    users.Add(user);
                }
            }
            return users;
        }

    }

    public class UsersCsvAdapter : IUserRepository
    {
        private UsersCsv _adaptee = null;

        public UsersCsvAdapter(UsersCsv adaptee)
        {
            _adaptee = adaptee;
        }

        public List<List<string>> GetUserNames()
        {
            string incompatibleCsvResponse = _adaptee
                .GetUsersCsvAsync()
                .GetAwaiter()
                .GetResult();

            List<List<string>> users = new List<List<string>>();

            var user = incompatibleCsvResponse.Split("\n").ToList();

            user.ForEach(q =>
            {
                users.Add(user);
            });

            return users;
        }
    }

    //
    // tu trzeba dopisać własny adapter implementujący odpowiedni interfejs
    //

    public class Program
    {

        static void Main(string[] args)
        {

            UsersApi usersRepository = new UsersApi();
            IUserRepository adapter = new UsersApiAdapter(usersRepository);

            Console.WriteLine("Użytkownicy z API:");
            List<List<string>> users = adapter.GetUserNames();
            int i = 1;
            users.ForEach(user => {
                Console.WriteLine($"{i.ToString("0#")}. {user[0]} {user[1]}");
                i++;
            });

            Console.WriteLine();

            // TODO: wyświetl w konsoli wynik działania obu adapterów

            UsersCsv usersRepositoryCsv = new UsersCsv();
            IUserRepository adapterCsv = new UsersCsvAdapter(usersRepositoryCsv);

            Console.WriteLine("Użytkownicy z CSV:");

            List<List<string>> usersCsv = adapterCsv.GetUserNames();
            int j = 0;
            usersCsv.ForEach(user =>
            {
                Console.WriteLine($"{(j+1).ToString("0#")}. {user[j]}");
                j++;
            });

        }

    }
}