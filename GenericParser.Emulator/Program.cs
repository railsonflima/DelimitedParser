using System;
using GenericParser.DelimitedParser.Parser;
using GenericParser.Parser;

namespace GenericParser.Emulator
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseWithHeader();
            ParseWithoutHeader();
        }

        private static void ParseWithoutHeader()
        {
            var filePath = @"C:\FileWithoutHeaderTesting.csv";

            var delimitedParser = new DelimitedWithoutHeaderParser<TestingModel>(filePath)
            {
                Delimitator = ';',
                HeaderFile = "TESTING_01;TESTING_02;TESTING_03"
            };

            var model = delimitedParser.Parse();
        }

        private static void ParseWithHeader()
        {
            var filePath = @"C:\FileWithHeaderTesting.csv";

            var delimitedParser = new DelimitedParser<TestingModel>(filePath)
            {
                Delimitator = ';'
            };

            var model = delimitedParser.Parse();
        }
    }
}
