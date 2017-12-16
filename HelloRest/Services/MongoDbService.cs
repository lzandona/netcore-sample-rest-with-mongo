using HelloRest.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloRest.Services
{
    public class MongoDbService
    {
        private IMongoCollection<Movie> MovieCollection { get; }

        public MongoDbService(string databaseName, string collectionName, string databaseUrl)
        {
            var mongoClient = new MongoClient(databaseUrl);
            var mongoDatabase = mongoClient.GetDatabase(databaseName);

            MovieCollection = mongoDatabase.GetCollection<Movie>(collectionName);
        }

        public async Task insertMovie(Movie movie) => await MovieCollection.InsertOneAsync(movie);

        public async Task<List<Movie>> GetAllMovies()
        {
            var movies = new List<Movie>();

            var allDocuments = await MovieCollection.FindAsync(new BsonDocument());
            await allDocuments.ForEachAsync(doc => movies.Add(doc));

            return movies;
        }

    }
}
