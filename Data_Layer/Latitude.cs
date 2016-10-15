using System;

namespace DTED.Data_Layer
{
    /* The class abstracts the latitude data that will be
     * read from the file. The data members will consist
     * of the components of the latitude such as 'minutes'.
     * A heading data member will also be included to show 
     * if it is 'North' or 'South' of the equator. 
     *
     * NOTE: Might need to throw errors for bad values
     */
    public class Latitude : GeographicCoordinate
    {
        /* Property */
        public int Degrees
        {
            get
            {
                return degrees;
            }
            set
            {
                // Ensure value is within bounds for latitude coordinate
                if (value >= MIN_LATITUDE && value <= MAX_LATITUDE)
                {
                    degrees = value;
                }
            }
        }

        /* Property */
        public int Minutes
        {
            get
            {
                return minutes;
            }
            set
            {
                // Ensure value is within bounds for minutes coordinate
                if ((value >= MIN_MINUTES && value <= MAX_MINUTES) && degrees != MAX_LATITUDE)
                {
                    minutes = value;
                }
            }
        }

        /* Property */
        public int Seconds
        {
            get
            {
                return seconds;
            }
            set
            {
                // Ensure value is within bounds for seconds coordinate
                if ((value >= MIN_SECONDS && value <= MAX_SECONDS) && degrees != MAX_LATITUDE)
                {
                    seconds = value;
                }
            }
        }

        public char Heading
        {
            get
            {
                return heading;
            }
            set
            {
                // Check if heading is valid. NOTE: Do we care about capitalization?
                if('N'.Equals(value) || 'S'.Equals(value))
                {
                    heading = value;
                }
            }
        }

        /* Constructor will initialize and create object
         * that is valid. It will convert 'string' paramaters
         * into the proper values and the class will check if
         * such values are valid.
         */
        public Latitude(string deg, string min, string sec, string heading)
        {
            Degrees = int.Parse(deg);
            Minutes = int.Parse(min);
            Seconds = int.Parse(sec);
            Heading = char.Parse(heading);
        }

        /* Constructor creates latitude from decimal 
        * degree representation */
        public Latitude(double decimalDeg)
        {
            Degrees = (int)decimalDeg; // Truncate decimal and set to degree value
            Minutes = (int)((decimalDeg * MINUTES_PER_DEG) % MINUTES_PER_DEG);
            Seconds = (int)((Math.Abs(decimalDeg) * SECONDS_PER_DEG) % SECONDS_PER_DEG);
        }

        /* Returns a human readable representation of latitude */
        public string toString()
        {
            return degrees + DEGREE_SYMBOL + " " + minutes + "'" 
                + " " + seconds + "\"" 
                + " " + heading;
        }
    }
}