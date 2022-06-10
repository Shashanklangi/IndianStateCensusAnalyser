using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianState
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType type;
        public enum ExceptionType
        {
            FILE_NOT_EXIST, IMPROPER_EXTENSION, DELIMITER_NOT_FOUND, INCORRECT_HEADER
        }
        ///<summary>
        ///Initializes a new instance of the <see cref="CensusAnalyserException"/> class
        ///</summary>
        ///<param name="type">The type.</param>
        ///<param name="name">The name.</param>
        public CensusAnalyserException(ExceptionType type, string name) : base(name)
        {
            this.type = type;
        }
    }
}
