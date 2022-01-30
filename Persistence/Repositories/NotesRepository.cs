using Persistence.Models;

namespace Persistence.Repositories
{
    public class NotesRepository : INotesRepository
    {
        //private const string FileName = "notes.txt";

        private const string TableName = "notes";

        //private readonly IFileClient _fileClient;

        private readonly ISqlClient _sqlClient;

        //public NotesRepository(IFileClient fileClient)
        //{
        //    _fileClient = fileClient;
        //}

        public NotesRepository(ISqlClient sqlClient)
        {
            _sqlClient = sqlClient;
        }
        //CRUD
        //Create - execute
        //Read - query
        //Update - execute
        //Delete - execute
        public int Delete(int id)
        {
            //var allNotes = _fileClient.ReadAll<Note>(FileName).ToList();
            //var updateNotes = allNotes.Where(note => note.Id != id);

            //_fileClient.WriteAll(FileName, updateNotes);

            var sql = $"DELETE FROM {TableName} WHERE Id = @Id";

            return _sqlClient.Execute(sql, new { Id = id });
        }

        public int DeleteAll()
        {
            var sql = $"DELETE FROM {TableName}";

            return _sqlClient.Execute(sql);
        }

        public int Edit(int id, string title, string text)
        {
            //var allNotes = _fileClient.ReadAll<Note>(FileName).ToList();
            //var noteToUpdate = allNotes.First(note => note.Id == id);

            //noteToUpdate.Title = title;
            //noteToUpdate.Text = text;

            //_fileClient.WriteAll(FileName, allNotes);

            var sql = @$"UPDATE {TableName} SET
                        Title = @Title,
                        Text = @Text
                        WHERE Id = @Id";

            return _sqlClient.Execute(sql, new
            {
                Title = title,
                Text = text,
                Id = id
            });
        }

        public IEnumerable<Note> GetAll()
        {
            //return _fileClient.ReadAll<Note>(FileName);

            var sql = $"SELECT * FROM {TableName}";

            return _sqlClient.Query<Note>(sql);
        }

        public int Save(Note note)
        {
            //_fileClient.Append(FileName, note);

            var sql = $"INSERT INTO {TableName} (Title, Text, DateCreated) VALUES (@Title, @Text, @DateCreated)";

            return _sqlClient.Execute(sql, note);
        }
    }
}
