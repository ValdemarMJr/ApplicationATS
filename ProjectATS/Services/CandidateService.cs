using MongoDB.Driver;
using ProjectATS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectATS.Services
{
    public class CandidateService
    {
        private readonly IMongoCollection<Candidate> _candidates;

        public CandidateService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _candidates = database.GetCollection<Candidate>("Candidates");
        }

        public Candidate Create(Candidate candidate)
        {
            _candidates.InsertOne(candidate);
            return candidate;
        }

        public IList<Candidate> Read() =>
            _candidates.Find(sub => true).ToList();

        public Candidate Find(string id) =>
            _candidates.Find(sub => sub.Id == id).SingleOrDefault();

        public void Update(Candidate candidate) =>
            _candidates.ReplaceOne(cand => cand.Id == candidate.Id, candidate);

        public void Delete(string id) =>
            _candidates.DeleteOne(sub => sub.Id == id);
    }
}
