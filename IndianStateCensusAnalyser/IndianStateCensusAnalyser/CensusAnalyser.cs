using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianState
{
    public class CensusAnalyser
    {
        public Dictionary<string, StateCensusData> datamap;

        ///<summary>
        ///Loads the census data
        ///</summary>
        ///<param name="csvFilePath">The CSV file path.</param>
        ///<param name="dataHeaders">The data Headers.</param>
        ///<returns></returns>
        ///<exception cref="Dictionary<string, StateCensusData>"></exception>
        public Dictionary<string, StateCensusData> LoadCensusData(string csvFilePath, string dataHeaders)
        {
            datamap = new Dictionary<string, StateCensusData>();
            //Check file is exist or not
            if (!File.Exists(csvFilePath))
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.FILE_NOT_EXIST, "File dose not exist");
            }
            //Check file extension is proper or not
            if (Path.GetExtension(csvFilePath) != ".csv")
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.IMPROPER_EXTENSION, "Improper Extension of a file");
            }
            //check data header correct or not
            string[] censusdata = File.ReadAllLines(csvFilePath);
            if (censusdata[0] != dataHeaders)
            {
                throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, "Incorrect Header");
            }
            //Check for delimiter is available or not for this skippinh header chck all the data
            foreach (string row in censusdata.Skip(1))
            {
                if (!row.Contains(","))
                {
                    throw new CensusAnalyserException(CensusAnalyserException.ExceptionType.DELIMITER_NOT_FOUND, "Delimmiter not found");
                }
                string[] column = row.Split(',');
                if (csvFilePath.Contains("IndiaStateCode"))
                    datamap.Add(column[0], new StateCensusData(new CensusCode(column[0], column[1], column[2], column[3])));
                else
                    datamap.Add(column[0], new StateCensusData(column[0], column[1], column[2], column[3]));
            }
            return datamap;

        }

    }
}
