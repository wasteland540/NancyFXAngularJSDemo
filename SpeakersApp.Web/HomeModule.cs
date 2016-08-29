using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using Nancy;
using Nancy.ModelBinding;

namespace SpeakersApp.Web
{
    public class HomeModule : NancyModule
    {
        private readonly IMongoCollection<Speaker> _speakersCollection;

        public HomeModule(IMongoCollection<Speaker> speakersCollection) : base("/api")
        {
            _speakersCollection = speakersCollection;

            Get["/"] = Index;

            Get["/speakers"] = GetSpeakers;

            Post["/speakers/"] = PostSpeaker;
        }

        private dynamic Index(dynamic parameters)
        {
            return "Hello CodeCampers!";
        }


        private dynamic GetSpeakers(dynamic parameters)
        {
            IList<Speaker> speakers = _speakersCollection.AsQueryable().ToList();

            return Response.AsJson(speakers);
        }

        private dynamic PostSpeaker(dynamic parameters)
        {
            var speaker = this.Bind<Speaker>();
            _speakersCollection.InsertOne(speaker);

            return speaker;
        }
    }
}