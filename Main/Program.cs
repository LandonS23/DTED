﻿using DTED.Data_Layer;
using DTED.DTED_Reader;
using DTED.DataMapping;

/*
* Entry point for project for testing...
*/
namespace DTED
{
    public class Program
    {
        static string testFileName = "N59.dt1"; // File path (just to test)

        static void Main(string[] args)
        {
            DTED_Data fileData; // Declare 'DTED_Data' object
            FileReader reader = new FileReader(testFileName);
            reader.read(out fileData); // Pass 'fileData' by reference to be manipulated
            DataMapper mapper = new DataMapper(fileData);
            MappedData[,] data = mapper.map();
        }
    }
}
