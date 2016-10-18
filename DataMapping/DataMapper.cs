using DTED.Data_Layer;
using System;

namespace DTED.DataMapping
{
    /*
    * This class will take in 'DTED_Data' and use the 
    * corresponding information to parse and generate 
    * data that maps the elevation data to the 
    * latitude and longitude posts.
    */
    public class DataMapper
    {
        /* Data member represents file data that will be parsed and 
        * used to generate data */
        private DTED_Data fileData;

        /* Constructs 'DataMapper' with DTED file data */
        public DataMapper(DTED_Data data)
        {
            fileData = data;
        }

        /* 
        * Function uses 'fileData' data member to parse and generate
        * a 'MappedData' objects and place them in a 2D array
        */
        public MappedData[,] map()
        {
            // First, the latitude and longitude intervals must be listed!
            int numberLat;
            int latitudeInter;
            int numberLon;
            int longitudeInter;

            // Retrieve data from the header of DTED to create latitude/longitude grid
            numberLat = fileData.Header.NumberLatitudeLines;
            latitudeInter = (int) fileData.Header.LatitudeInterval; // Get interval of latitude in decimal value
            numberLon = fileData.Header.NumberLongitudeLines;
            longitudeInter = (int) fileData.Header.LongitudeInterval; // Get interval of longitude in decimal value

            // Get latitude/longitude origin
            Latitude currLatit = fileData.Header.LatitudeOrigin;
            Longitude currLongi = fileData.Header.LongitudeOrigin;

            Latitude[] latValues = new Latitude[numberLat];
            Longitude[] lonValues = new Longitude[numberLon];

            MappedData[,] mappedData = new MappedData[numberLat, numberLon];

            // Generate latitude values for grid based on interval from file
            for(int i = 0; i < numberLat; ++i)
            {
                latValues[i] = currLatit;
                currLatit = currLatit.addInterval(0, 0, latitudeInter);
            }

            // Generate longitude values for grid based on interval from file
            for(int i = 0; i < numberLon; ++i)
            {
                lonValues[i] = currLongi;
                currLongi = currLongi.addInterval(0, 0, longitudeInter);
            }

            int[][] elevData = fileData.ElevationGrid; // Get elevation data to map onto latitude and longitude posts
            int elev; // Hold particular elevation from the data
            Latitude lat; // Latitude at post
            Longitude lon; // Longitude at post

            // Generate latitude and longitude grid data mapped to elevation

            // Must go along longitude lines as outer loop
            for (int i = 0; i < numberLon; ++i)
            {
                // Starting with lowest latitude and work to the top
                for(int j = 0; j < numberLat; ++j)
                {
                    elev = elevData[i][j];
                    lat = new Latitude(latValues[j]);
                    lon = new Longitude(lonValues[i]);
                    mappedData[(numberLat - 1) - j,i] = new MappedData(lat, lon, elev);
                }
            }
            
            return mappedData;
        }
    }
}
