using DRCaseLib;

namespace RecordTesdt
{
    [TestClass]
    public class UnitTest
    {
        private Record recordTrue = new Record { Id = 1, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Duration = 43.0, publicationYear = 1973 };
        private Record recordTitleNull = new Record { Id = 2, Title = null, Artist = "Pink Floyd", Duration = 43.0, publicationYear = 1973 };
        private Record recordArtistNull = new Record { Id = 3, Title = "The Dark Side of the Moon", Artist = null, Duration = 43.0, publicationYear = 1973 };
        private Record recordDurationZero = new Record { Id = 4, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Duration = 0, publicationYear = 1973 };
        private Record recordPublicationYear2025 = new Record { Id = 5, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Duration = 43.0, publicationYear = 2025 };

        [TestMethod]
        public void TestValidateNullTitle()
        {
            recordTrue.ValidateNullTitle();
            Assert.ThrowsException<System.ArgumentNullException>(() => recordTitleNull.ValidateNullTitle());
        }

        [TestMethod]
        public void TestValidateNullArtist()
        {
            recordTrue.ValidateNullArtist();
            Assert.ThrowsException<System.ArgumentNullException>(() => recordArtistNull.ValidateNullArtist());
        }

        [TestMethod]
        public void TestValidateDuration()
        {
            recordTrue.ValidateDuration();
            Assert.ThrowsException<System.ArgumentException>(() => recordDurationZero.ValidateDuration());
        }

        [TestMethod]
        public void TestValidatePublicationYear()
        {
            recordTrue.ValidatePublicationYear();
            Assert.ThrowsException<System.ArgumentException>(() => recordPublicationYear2025.ValidatePublicationYear());
        }


    }
}