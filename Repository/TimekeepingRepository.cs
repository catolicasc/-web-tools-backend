using wickedbotz_web_api.Model;

namespace wickedbotz_web_api.Repository;

using Microsoft.Extensions.Options;
using MongoDB.Driver;


public class TimekeepingRepository
{
    private readonly IMongoCollection<Timekeeping> _timerKeepingCollection;

    public TimekeepingRepository(
        IOptions<MongoStoreDatabaseSettings> mongoStoreDatabaseSettings)
    {
        
        var mongoClient = new MongoClient(
            mongoStoreDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mongoStoreDatabaseSettings.Value.DatabaseName);

        _timerKeepingCollection = mongoDatabase.GetCollection<Timekeeping>(
            mongoStoreDatabaseSettings.Value.MongoCollectionName);
    }

    public async Task<List<Timekeeping>> GetAsync() =>
        await _timerKeepingCollection.Find(_ => true).ToListAsync();

    public async Task<Timekeeping?> GetAsync(string id) =>
        await _timerKeepingCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Timekeeping newBook) =>
        await _timerKeepingCollection.InsertOneAsync(newBook);

    public async Task UpdateAsync(string id, Timekeeping updatedBook) =>
        await _timerKeepingCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

    public async Task RemoveAsync(string id) =>
        await _timerKeepingCollection.DeleteOneAsync(x => x.Id == id);
}