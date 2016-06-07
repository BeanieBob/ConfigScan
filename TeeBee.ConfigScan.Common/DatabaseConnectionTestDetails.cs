using System;
using System.Collections.Generic;
using System.Configuration;

namespace TeeBee.ConfigScan.Common
{
    /// <summary>
    /// Stores connection details and associated connection test results for a single database connection.
    /// </summary>
    public class DatabaseConnectionTestDetails
    {
        /// <summary>
        /// The ordinal position of this Connection Test in a list.
        /// </summary>
        private int ordinalIndex;

        /// <summary>
        /// The connectionString settings to be tested.
        /// </summary>
        private readonly ConnectionStringSettings connectionStringSettings;

        /// <summary>
        /// True if the connection test was run.
        /// </summary>
        private bool wasTestRun;

        /// <summary>
        /// True if the connection test was successful.
        /// </summary>
        private bool wasTestSuccessful;

        /// <summary>
        /// The connection error, if any.
        /// </summary>
        private Exception connectionError;

        /// <summary>
        /// The connection error text, if relevant.
        /// </summary>
        private string connectionErrorText = string.Empty;

        /// <summary>
        /// Contructor for the DatabaseConnectionTestDetails class.
        /// </summary>
        /// <param name="connectionStringSettings">
        /// The connectionString settings for a single database connection.
        /// </param>
        public DatabaseConnectionTestDetails(ConnectionStringSettings connectionStringSettings)
        {
            this.connectionStringSettings = connectionStringSettings;
        }

        /// <summary>
        /// Gets or sets the ordinal position of this Connection Test in a list.
        /// </summary>
        public int OrdinalIndex
        {
            get { return this.ordinalIndex; }
            set { this.ordinalIndex = value; }
        }

        /// <summary>
        /// Gets the connection name.
        /// </summary>
        public string ConnectionName
        {
            get
            {
                return this.connectionStringSettings.Name;
            }
        }

        /// <summary>
        /// Gets the connection string.
        /// </summary>
        public string ConnectionString
        {
            get
            {
                return this.connectionStringSettings.ConnectionString;
            }
        }

        /// <summary>
        /// Gets the provider name.
        /// </summary>
        public string ProviderName
        {
            get
            {
                return this.connectionStringSettings.ProviderName;
            }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether the test was run.
        /// </summary>
        public bool WasTestRun
        {
            get { return this.wasTestRun; }
            set { this.wasTestRun = value; }
        }

        /// <summary>
        /// Gets or sets a flag indicating whether test was successful.
        /// </summary>
        public bool WasTestSuccessful
        {
            get { return this.wasTestSuccessful; }
            set { this.wasTestSuccessful = value; }
        }

        /// <summary>
        /// Gets or sets the connection error, if any.
        /// </summary>
        public Exception ConnectionError
        {
            get { return this.connectionError; }
            set { this.connectionError = value; }
        }

        /// <summary>
        /// Gets or sets the text of the connection error, if any.
        /// </summary>
        public string ConnectionErrorText
        {
            get { return this.connectionErrorText; }
            set { this.connectionErrorText = value; }
        }

        /// <summary>
        /// Gets a simple text description of the status of the database connection test.
        /// </summary>
        public string TestStatusDescription
        {
            get
            {
                if (!this.wasTestRun)
                    return "TESTING";
                if (this.wasTestSuccessful)
                    return "SUCCESS";
                return "FAILED";
            }
        }
        
        /// <summary>
        /// Converts a list of DatabaseConnectionTestDetails into a striongly typed DataSet.
        /// </summary>
        /// <param name="connectionTestList">The list of DatabaseConnectionTestDetails to convert</param>
        /// <returns>A strongly typed DataSet containing data from the DatabaseConnectionTestDetails</returns>
        public static DatabaseConnectionTestDetailsDataSet ConvertToDataSet(
            IList<DatabaseConnectionTestDetails> connectionTestList)
        {
            DatabaseConnectionTestDetailsDataSet dataSet = new DatabaseConnectionTestDetailsDataSet();
            var ordinalIndex = 1;
            foreach (DatabaseConnectionTestDetails connectionTest in connectionTestList)
            {
                string source = connectionTest.connectionStringSettings.ElementInformation.Source;               
                dataSet.DatabaseConnectionTestDetails.AddDatabaseConnectionTestDetailsRow(
                    connectionTest.ConnectionName, ordinalIndex++, connectionTest.ConnectionString,
                    connectionTest.ProviderName, connectionTest.WasTestRun, connectionTest.WasTestSuccessful,
                    connectionTest.connectionErrorText, connectionTest.TestStatusDescription,
                    source);
            }
            return dataSet;
        }       
    }

}
