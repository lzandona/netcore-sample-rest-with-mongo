using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRest.Model
{
    public class Movie
    {
        [BsonId]
        public long Id { get; set; }

        [BsonRequired]
        public string Title { get; set; }

        [BsonRequired]
        public int Year { get; set; }

        [BsonRequired]
        public string Genre { get; set; }

    }
}
