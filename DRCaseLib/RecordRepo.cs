using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;


namespace DRCaseLib
{
    public class RecordRepo
    {
        private int _nextId = 5;
        private List<Record> _records = new List<Record>()
        {
            new Record() { Id = 1, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Duration = 43.0, publicationYear = 1973 },
            new Record() { Id = 2, Title = "The Wall", Artist = "Pink Floyd", Duration = 81.0, publicationYear = 1979 },
            new Record() { Id = 3, Title = "Wish You Were Here", Artist = "Pink Floyd", Duration = 44.0, publicationYear = 1975 },
            new Record() { Id = 4, Title = "Animals", Artist = "Pink Floyd", Duration = 41.0, publicationYear = 1977 },
        };

        public RecordRepo()
        {

        }

        public List<Record> GetAllRecords()
        {
            return new List<Record>(_records);
        }

        public IEnumerable<Record> Get(string? title = null, string? artist = null, int? duration = null, int? publicationYear = null, string? orderBy = null)
        {
            IEnumerable<Record> result = new List<Record>(_records);

            // Filter by quality if it's provided
            if (!string.IsNullOrEmpty(title))
            {
                result = result.Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            }

            // Filter by brand if it's provided
            if (!string.IsNullOrEmpty(artist))
            {
                result = result.Where(m => m.Artist.Contains(artist, StringComparison.OrdinalIgnoreCase));
            }

            if (duration.HasValue)
            {
                result = result.Where(m => m.Duration == duration.Value);
            }
            if (publicationYear.HasValue)
            {
                result = result.Where(m => m.publicationYear == publicationYear.Value);
            }


            // Ordering the results
            if (!string.IsNullOrEmpty(orderBy))
            {
                orderBy = orderBy.ToLower();
                switch (orderBy)
                {
                    case "quality":
                    case "quality_asc":
                        result = result.OrderBy(m => m.Title);
                        break;
                    case "quality_desc":
                        result = result.OrderByDescending(m => m.Title);
                        break;
                        // You can add more order conditions here
                }
            }

            return result;
        }

        public Record? GetById(int id)
        {
            return _records.Find(record => record.Id == id);
        }

        public Record Add (Record record) {
            record.Validate();

            record.Id = _nextId++;
            _records.Add(record);
            return record;
        }

        public Record Update(Record record)
        {
            record.Validate();

            Record? existingRecord = GetById(record.Id);
            if (existingRecord != null)
            {
                existingRecord.Title = record.Title;
                existingRecord.Artist = record.Artist;
                existingRecord.Duration = record.Duration;
                existingRecord.publicationYear = record.publicationYear;
                return existingRecord;
            }
            return null;
        }


        

    }
}
