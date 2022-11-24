using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DoAnCuoiKiOOP_v2
{
    public class XuLyCSV<T> where T : class, new()
    {
        public static void Write(List<T> inputList, string fileName)
        {
            CsvFileDescription csvFileConfig = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
            };

            CsvContext csvContext = new CsvContext();

            csvContext.Write(inputList, fileName, csvFileConfig);
        }

        public static void Write(List<T> inputList, T inputItem, string fileName)
        {
            CsvFileDescription csvFileConfig = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
            };

            inputList.Add(inputItem);

            CsvContext csvContext = new CsvContext();

            csvContext.Write(inputList, fileName, csvFileConfig);
        }

        public static List<T> Read(string fileName)
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
                IgnoreUnknownColumns = true,
                UseFieldIndexForReadingData = false,
            };

            CsvContext csvContext = new CsvContext();

            List<T> outputList = csvContext.Read<T>(fileName, inputFileDescription).ToList<T>();
            return outputList;
        }
    }
}
