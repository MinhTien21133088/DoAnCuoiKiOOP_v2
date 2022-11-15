using LINQtoCSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FileGeneric
{
    public class DocGhi<F> where F : class, new()
    {
        public static void Write(List<F> inputList, string fileName)
        {
            var csvFileConfig = new CsvFileDescription
            {
                FirstLineHasColumnNames = true,
                SeparatorChar = ',',
            };

            var csvContext = new CsvContext();
            csvContext.Write(inputList, fileName, csvFileConfig);
        }

        public static List<F> Read(string fileName)
        {
            CsvFileDescription inputFileDescription = new CsvFileDescription
            {
                SeparatorChar = ',',
                FirstLineHasColumnNames = true
            };

            CsvContext ctx = new CsvContext();
            var outputList = ctx.Read<F>(fileName, inputFileDescription);

            return outputList.ToList<F>();
        }
    }
}