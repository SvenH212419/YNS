using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using MongoDB.Driver;
using MongoDB.Bson;


namespace YNS.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamarin-quickstart"));

        }
        public class MongoDB
        {

            public MongoDB()
            {   
                var settings = MongoClientSettings.FromConnectionString("mongodb+srv://NovaFoxy:<Kyuubi99>@maincluster.jtr1q.mongodb.net/?retryWrites=true&w=majority");
                settings.ServerApi = new ServerApi(ServerApiVersion.V1);
                var client = new MongoClient(settings);
                var database = client.GetDatabase("test");

                var collection = database.GetCollection<BsonDocument>("test");

                Console.WriteLine("Data from MongoDB Database");
                collection.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X));

                Console.Read();

                OpenConsole = Console.ReadLine();
            }

            public string OpenConsole { get; }
        }

        public ICommand OpenWebCommand { get; }
    }
}