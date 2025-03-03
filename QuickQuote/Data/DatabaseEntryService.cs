namespace QuickQuote.Data
{
    public class DatabaseEntryService
    {
        public Task<DatabaseEntry> GetDatabaseEntryAsync(int EntryNumber, Database database)
        {
            return Task.FromResult(Database[EntryNumber]);
        }
    }
}
