using SQLite;
using TeacherKnowledgeHub.Models;

namespace TeacherKnowledgeHub.Services
{
    public class ClassService
    {
        private readonly SQLiteAsyncConnection _db;

        public ClassService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<ClassModel>().Wait();
        }

        public Task<List<ClassModel>> GetAllAsync()
        {
            return _db.Table<ClassModel>().ToListAsync();
        }

        public Task<ClassModel> GetAsync(int id)
        {
            return _db.Table<ClassModel>().Where(k => k.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> AddAsync(ClassModel classModel)
        {
            return _db.InsertAsync(classModel);
        }

        public Task<int> UpdateAsync(ClassModel classModel)
        {
            return _db.UpdateAsync(classModel);
        }

        public Task<int> DeleteAsync(ClassModel classModel)
        {
            return _db.DeleteAsync(classModel);
        }
    }
}
