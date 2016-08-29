using MongoDB.Driver;
using Nancy;
using Nancy.TinyIoc;

namespace SpeakersApp.Web
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            #region Configure MongoDB

            const string connectionString = "mongodb://localhost:27017";
            const string databaseName = "NancyDemo";

            var client = new MongoClient(connectionString);
            IMongoDatabase database = client.GetDatabase(databaseName);

            IMongoCollection<Speaker> collection = database.GetCollection<Speaker>("Speakers");

            container.Register<IMongoClient>(client);
            container.Register(database);
            container.Register(collection);

            #endregion Configure MongoDB
        }
    }
}