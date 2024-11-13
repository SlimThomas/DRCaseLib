


namespace DRCaseLib
{
    public class Record
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public double Duration { get; set; }
        public int publicationYear { get; set; }



        public Record()
        {

        }


        public void ValidateNullTitle()
        {
            if (Title == null)
            {
                throw new System.ArgumentNullException("Title cannot be null");
            }
        }

        public void ValidateNullArtist()
        {
            if (Artist == null)
            {
                throw new System.ArgumentNullException("Artist cannot be null");
            }
        }

        public void ValidateDuration()
        {
            if (Duration == null)
            {
                throw new ArgumentNullException("Duration cannot be null");
            }
            if (Duration <= 0)
            {
                throw new System.ArgumentException("Duration cannot be 0");
            }
        }

        public void ValidatePublicationYear()
        {
            if (publicationYear == null)
            {
                throw new System.ArgumentNullException("Publication year cannot be 0");
            }
            if (publicationYear > 2024)
            {
                throw new System.ArgumentException("Publication year cannot be above 2024");
            }
        }


        public void Validate()
        {
            ValidateNullTitle();
            ValidateNullArtist();
            ValidateDuration();
            ValidatePublicationYear();
        }

        public override bool Equals(object? obj)
        {
            return obj is Record record &&
                   Id == record.Id &&
                   Title == record.Title &&
                   Artist == record.Artist &&
                   Duration == record.Duration &&
                   publicationYear == record.publicationYear;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Title, Artist, Duration, publicationYear);
        }
    }
}
