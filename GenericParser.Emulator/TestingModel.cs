using GenericParser.Attribute;

namespace GenericParser.Emulator
{
    public class TestingModel
    {
        [DelimitedHeader("TESTING_01")]
        public string TestingPropString { get; set; }

        [DelimitedHeader("TESTING_02")]
        public int TestingPropStringInt { get; set; }

        [DelimitedHeader("TESTING_03")]
        public bool TestingPropStringBool { get; set; }
    }
}
