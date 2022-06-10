using NuGet.Frameworks;
using IndianState;

namespace IndianState
{
    public class Tests
    {
        string folderPath = @"E:\BridgelabPracticeProblems\IndianState\CsvFile\";
        string validStateCensusFileState = "IndiaStateCensusData.csv";
        string validFileStateCode = "IndiaStateCode.csv";
        string invalideExtensionFileState = "IndiaStateCode.txt";
        string invalidDelimiterFileState = "DelimiterIndiaStateCensusData.csv";
        string invalidDelimiterFileStateCode = "DelimiterIndiaStateCensusDataCode.csv";
        string invalidHeaderState = "WrongIndiaStateCensusData.csv";
        string invalidHeaderStateCode = "WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
        }

        /// <summary>
        /// TC 1.1 - Check to ensure the Number of Record matches or not
        /// </summary>
        [Test]
        public void Given_CSVFile_EnsureThe_NumberOfRecordAreMatch()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC 1.2- Check Given File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validStateCensusFileState + "Txt", "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_EXIST, exception.type);
        }
        /// <summary>
        /// TC1.3- Check given File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectFileExtension_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalideExtensionFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.IMPROPER_EXTENSION, exception.type);

        }
        /// <summary>
        /// TC1.4- Check the Proper delimiter is used or not
        /// </summary> 
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_NOT_FOUND, exception.type);
        }
        /// <summary>
        /// TC1.5- Check in CSV file the Header is correct or not
        /// </summary>
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderState, "State,Population,AreaInSqKm,DensityPerSqKm"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, exception.type);
        }
        /// <summary>
        /// TC 2.1 - Check to ensure the Number of Record matches or not
        /// </summary>
        [Test]
        public void Given_CSVFile_EnsureThe_NumberOfRecordAreMatch_Code()
        {
            censusAnalyser.datamap = censusAnalyser.LoadCensusData(folderPath + validFileStateCode, "SerialNumber,StateName,Tin,StateCode");
            Assert.AreEqual(37, censusAnalyser.datamap.Count);
        }
        /// <summary>
        /// TC 2.2- Check Given File is Exist or Not
        /// </summary>
        [Test]
        public void Given_IncorrectCSVFileName_ReturnCustomException_Code()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + validFileStateCode + "Txt", "SerialNumber,StateName,Tin,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_EXIST, exception.type);
        }
        /// <summary>
        /// TC 2.3- Check given File is Contains Proper extension or not
        /// </summary>
        [Test]
        public void Given_IncorrectFileExtension_ReturnCustomException_Code()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalideExtensionFileState, "SerialNumber,StateName,Tin,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.IMPROPER_EXTENSION, exception.type);

        }
        /// <summary>
        /// TC 2.4- Check the Proper delimiter is used or not
        /// </summary> 
        [Test]
        public void Given_IncorrectDelimiter_ReturnCustomException_Code()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidDelimiterFileStateCode, "SerialNumber,StateName,Tin,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.DELIMITER_NOT_FOUND, exception.type);
        }
        /// <summary>
        /// TC 2.5- Check in CSV file the Header is correct or not
        /// </summary>
        [Test]
        public void Given_IncorrectHeader_ReturnCustomException_Code()
        {
            CensusAnalyserException exception = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(folderPath + invalidHeaderStateCode, "SerialNumber,StateName,Tin,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, exception.type);
        }

    }
}