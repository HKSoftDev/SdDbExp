// -------------------------------------------------------------------------------------------------------------------------------
// <copyright file="Bizz.Update.cs" company="Haderslev Kommune" author="Daniel Giversen" year="2022" reserved="All Rights" />
// <license file="License.txt" "type=Proprietary License" />
// -------------------------------------------------------------------------------------------------------------------------------
using MongoDB.Driver;

namespace Repository;

/// <remarks/>
public interface ITaskItemRepository
{
	/// <remarks/>
	Task<List<TaskItem>> GetTaskItemsAsync();

	/// <remarks/>
	Task<TaskItem> GetTaskItemAsync(string id);

	/// <remarks/>
	Task<TaskItem> InsertTaskAsync(TaskItem task);

	/// <remarks/>
	Task<TaskItem> UpdateTaskItemAsync(string id, TaskItem taskItemIn);

	/// <remarks/>
	Task DeleteAsync(string id);

}


/// <summary>This is a repository that has responsibility to handle CRUD operations no any flow logic here</summary>

public class TaskItemRepository : ITaskItemRepository
{
	private readonly IMongoCollection<TaskItem> _taskItems;

	/// <remarks/>
	public TaskItemRepository(IMongoDatabaseSettings mongoDatabaseSettings) { MongoClient? client = new MongoClient(mongoDatabaseSettings.ConnectionString);
		IMongoDatabase? database = client.GetDatabase(mongoDatabaseSettings.DatabaseName); _taskItems = database.GetCollection<TaskItem>(mongoDatabaseSettings.CollectionName); }

	/// <remarks/>
	public async Task<List<TaskItem>> GetTaskItemsAsync() => await _taskItems.Find(x=> true).ToListAsync();

	/// <remarks/>
	public async Task<TaskItem> GetTaskItemAsync(string id) => await _taskItems.Find(x => x.Id == id).FirstOrDefaultAsync();

	/// <remarks/>
	public async Task<TaskItem> InsertTaskAsync(TaskItem task) { await _taskItems.InsertOneAsync(task); return task; }

	/// <remarks/>
	public async Task<TaskItem> UpdateTaskItemAsync(string id, TaskItem taskItemIn) { await _taskItems.ReplaceOneAsync(x=>x.Id == id, taskItemIn); return taskItemIn; }

	/// <remarks/>
	public async Task DeleteAsync(string id) => await _taskItems.DeleteOneAsync(id);

}