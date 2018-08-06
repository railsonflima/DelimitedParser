using GenericParser.DelimitedParser.Parser;

namespace GenericParser.Emulator
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = @"C:\FileWithoutHeaderTesting.csv";

            var delimitedParser = new DelimitedWithoutHeaderParser<TestingModel>(filePath)
            {
                Delimitator = ';',
                HeaderFile = "TESTING_01;TESTING_02;TESTING_03"
            };

            var model = delimitedParser.Parse();
        }
    }
}
