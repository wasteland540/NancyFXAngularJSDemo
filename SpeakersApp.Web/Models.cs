using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SpeakersApp.Web
{
    public class Speaker
    {
        public Speaker()
        {
        }

        public Speaker(string firstname, string lastname, string session, string image)
        {
            Firstname = firstname;
            Lastname = lastname;
            Image = image;
            Session = session;
        }

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Image { get; set; }
        public string Session { get; set; }
    }
}