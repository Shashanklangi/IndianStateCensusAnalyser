using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndianState
{
    /// <summary>
    /// Adding all dataheader in Indian state census Data and state code data
    /// </summary>
    public class StateCensusData
    {
        string state;
        int population;
        int area;
        int density;
        public int serialNumber;
        public string stateName;
        public int tin;
        public string stateCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="StateCensusData"/> class.
        /// </summary>

        public StateCensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = Convert.ToInt32(population);
            this.area = Convert.ToInt32(area);
            this.density = Convert.ToInt32(density);
        }
    }
}
