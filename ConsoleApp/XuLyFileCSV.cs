using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using FileHelpers;
using System.Formats.Asn1;
using System.Globalization;

namespace DoAnCuoiKiOOP_v2
{
    public class XuLyFileCSV<T> where T : class, new()
    {
        public static void Write(List<T> inputList, string fileName)
        {
            CsvFileDescription csvFileConfig = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
                //TextEncoding = System.Text.Encoding.Unicode,
            };
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
                //TextEncoding = System.Text.Encoding.Unicode,
            };
            CsvContext csvContext = new CsvContext();
            List<T> outputList = csvContext.Read<T>(fileName, inputFileDescription).ToList();
            return outputList;
        }
    }
}
