using System;
using System.Collections.Generic;

namespace CymaticLabs.InfluxDB.Data
{
    /// <summary>
    /// Represents the result of an InfluxDB query.
    /// </summary>
    public class InfluxDbMeasurement
    {
        #region Fields

        // Internal look-up of a column's index given its name
        Dictionary<string, int> columnIndexByName;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets the name of the resulting series.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the tag results for the query.
        /// </summary>
        public IDictionary<string, string> Tags { get; private set; }

         

        #endregion Properties

        #region Constructors

        public InfluxDbMeasurement(string name, IDictionary<string, string> tags)
        {
            //if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException("name");
        
            if (tags == null) throw new ArgumentNullException("tags");
            Name = name;
            Tags = tags;
        

       

           
        }

        #endregion Constructors

       
    }
}
