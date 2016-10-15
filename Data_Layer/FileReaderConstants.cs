namespace DTED.Data_Layer
{
    /* Class will store constants used by reader such as 
     * byte sizes of each value 
     */
    public static class FileReaderConstants
    {
        /* Size of sentinel for UHL */
        public const int SIZE_RECOGNITION_SENTINEL = 3;

        /* Size of longitude origin */
        public const int SIZE_LONGITUDE_ORIGIN = 8;

        /* Size of latitude origin */
        public const int SIZE_LATITUDE_ORIGIN = 8;

        /* Size of longitude data interval */
        public const int SIZE_LONGITUDE_INTERVAL = 4;

        /* Size of latitude data interval */
        public const int SIZE_LATITUDE_INTERVAL = 4;

        /* Size of Absolute Vertical Accuracy */
        public const int SIZE_ABSOLUTE_VERTICAL_ACC = 4;

        /* Size of Unclassified Security Code */
        public const int SIZE_UNCLASSIFIED_SECURITY = 3;

        /* Size of Unique Reference */
        public const int SIZE_UNIQUE_REFERENCE = 12;

        /* Size of Number of Longitude Lines */
        public const int SIZE_NUMBER_LONGITUDE = 4;

        /* Size of Number of Latitude Points Per Longitude Line */
        public const int SIZE_NUMBER_LATITUDE = 4;

        /* Size of Multiple Accuracy */
        public const int SIZE_MULTIPLE_ACC = 1;

        /* Size of Reserved space */
        public const int SIZE_RESERVED = 24;
    }
}
