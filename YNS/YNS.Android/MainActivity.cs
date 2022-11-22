using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using MongoDB.Driver;
using MongoDB.Bson;

namespace YNS.Droid
{
    [Activity(Label = "YNS", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class MongoDB
    {
        public MongoDB()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://NovaFoxy:<Kyuubi99>@maincluster.jtr1q.mongodb.net/?retryWrites=true&w=majority");
            settings.ServerApi = new ServerApi(ServerApiVersion.V1);
            var client = new MongoClient(settings);
            var database = client.GetDatabase("FoxFinder");

            var collection = database.GetCollection<BsonDocument>("Media");

            Console.WriteLine("Data from MongoDB Database");
            collection.Find(new BsonDocument()).ForEachAsync(X => Console.WriteLine(X));

            Console.Read();
        }
    }
}