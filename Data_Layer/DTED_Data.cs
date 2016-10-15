namespace DTED.Data_Layer
{
    /* Abstraction of UHL in DTED file */
    public struct UHL_Header
    {
        /* The longitude of origin */
        public Longitude longitudeOrigin;

        /* Property */
        public Longitude LongitudeOrigin
        {
            get
            {
                return longitudeOrigin;
            }
        }

        /* The latitude of origin */
        public Latitude latitudeOrigin;

        /* Property */
        public Latitude LatitudeOrigin
        {
            get
            {
                return latitudeOrigin;
            }
        }

        /* The longitude interval */
        public double longitudeInterval;

        /* Property */
        public double LongitudeInterval
        {
            get
            {
                return longitudeInterval;
            }
        }

        /* The latitude interval */
        public double latitudeInterval;

        /* Property */
        public double LatitudeInterval
        {
            get
            {
                return latitudeInterval;
            }
        }

        /* Number of longitude lines */
        public string numberLongitudeLines;

        /* Property */
        public string NumberLongitudeLines
        {
            get
            {
                return numberLongitudeLines;
            }
        }

        /* Number of latitude points per longitude line */
        public string numberLatitudeLines;

        /* Property */
        public string NumberLatitudeLines
        {
            get
            {
                return numberLatitudeLines;
            }
        }

        /* Constructor for UHL */
        public UHL_Header(Longitude lonOrigin, Latitude latOrigin, string lonInterval, string latInterval,
            string numLatLines, string numLonLines)
        {
            longitudeOrigin = lonOrigin;
            latitudeOrigin = latOrigin;
            longitudeInterval = double.Parse(lonInterval);
            latitudeInterval = double.Parse(latInterval);
            numberLongitudeLines = numLonLines;
            numberLatitudeLines = numLatLines;
        }

        /*
        * Returns human readable representation of UHL part of the file
        */
        public string toString()
        {
            string value = "";
            value += "Longitude Origin: " + longitudeOrigin.toString() + "\n"
                + "Latitude Origin: " + latitudeOrigin.toString() + "\n"
                + "Longitude Interval: " + longitudeInterval + "\n"
                + "Latitude Interval: " + latitudeInterval + "\n"
                + "Number of Longitude Lines: " + numberLongitudeLines + "\n"
                + "Number of Latitude Lines (per longitude): " + numberLatitudeLines + "\n";

            return value; 
        }
    }

    /* Abstracting DTED file data format */
    public class DTED_Data
    {
        /* Header of DTED file */
        public UHL_Header header;

        /* Array of arrays consisting of elevation records, where each column is a data record list of elevations along longitude */
        public int[][] elevationGrid;

        /* Initialize object with passed data*/
        public DTED_Data(UHL_Header head, int[][] elevGrid)
        {
            header = head;
        }

        /* Returns human readable representation of 'DTED_DATA' */
        public string toString()
        {
            string value = "";
            value += "UHL Header\n" + header.toString();
            return value;
        }
    }
}
