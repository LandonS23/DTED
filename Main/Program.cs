using System;

using DTED.Data_Layer;
using DTED.DTED_Reader;

/*
* Would like to eliminate multiple calls to 
* 'Array.Resize(...)' as it could create potenial bugs later...
*/
namespace DTED
{
    public class Program
    {
        static string testFileName = "n59.dt1"; // File path (just to test)

        static void Main(string[] args)
        {
            DTED_Data fileData; // Declare 'DTED_Data' object
            FileReader reader = new FileReader(testFileName);
            reader.read(out fileData); // Pass 'fileData' by reference to be manipulated
        }
    }
}
