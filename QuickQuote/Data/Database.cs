using System.Runtime.InteropServices;
using System.IO;

namespace QuickQuote.Data
{
    public class Database
    {
        public DatabaseEntry[] DatabaseEntries { get; set; }

        public Database(string dataString)
        {
            List<DatabaseEntry> entryList = new List<DatabaseEntry>();
            List<string> dataRows = dataString.Split("\n").ToList();

            foreach(string dataRow in dataRows)
            {
                if (!string.IsNullOrEmpty(dataRow)){
                    var values = dataRow.Split(',');
                    bool volumeDiscount = bool.Parse(values[4]);
                    double flatValue = double.Parse(values[7]);
                    DatabaseEntry newEntry = new DatabaseEntry(this, values[0], values[1], values[2], values[3], volumeDiscount, flatValue);
                    if (volumeDiscount)
                    {
                        newEntry.VolumeMax = int.Parse(values[6]);
                        newEntry.VolumeMin = int.Parse(values[5]);
                    }
                    try
                    {
                        newEntry.Bump = double.Parse(values[8]);
                    }
                    catch
                    {

                    }
                    entryList.Add(newEntry);
                }
                
            }

            this.DatabaseEntries = entryList.ToArray();
        }
    }
}
