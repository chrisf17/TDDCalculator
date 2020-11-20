using System.Diagnostics;
using Calc.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace CalcTests
{
    [TestClass]
    public class CalculatorTests
    {
        static TestContext _ctx;

        Mock<ICalculationEngine> _engine ;
        Calculator _calculator;

        #region Standard Test Setup and Init routines

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            _ctx = context;
            // Executes once before the test run. (Optional)
            Debug.WriteLine("Init for assembly");
        }

        
        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            // Executes once after the test run. (Optional)
            Debug.WriteLine("Cleanup for assembly");
        }

        [ClassCleanup]
        public static void TestFixtureTearDown()
        {
             // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
            Debug.WriteLine("Cleanup for Class");
        }

        [TestCleanup]
        public void TearDown()
        {
            // Runs after each test. (Optional)
            Debug.WriteLine("Cleanup for Test");
        }
        #endregion

        Calculator calculator;
        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {

            _ctx = context;
            // Executes once for the test class. (Optional)
            Debug.WriteLine("Init for class - " + _ctx.TestName);
            
        }
        [TestInitialize]
        public void Setup()
        {
            // Per Test
            Debug.WriteLine("Init for Test - " + _ctx.TestName);

        }
        [TestMethod]
        public void Add_ShouldReturnZero_When_EmptyStringPassed()
        {
            var calc = new Calculator(new DecimalEngine());
            string expected = "0";
            string actual = calc.Add("");

            Assert.AreEqual<string>(expected, actual);

        }
        [TestMethod]
        public void Add_ShouldReturnValue_When_ValuePassed()
        {
            var calc = new Calculator(new DecimalEngine());
            string expected = "5";
            string actual = calc.Add("5");

            Assert.AreEqual<string>(expected, actual);

        }
        [TestMethod]
        public void Add_ShouldReturnSum_When_CommaSeparatedValuesPassed()
        {
            var calc = new Calculator(new DecimalEngine());
            string testValue = "7,8";
            string expected = "15";
            string actual = calc.Add(testValue);

            Assert.AreEqual<string>(expected, actual);

        }

        [TestMethod]
        public void Add_ShouldReturnHExSum_When_CommaSeparatedValuesPassed()
        {
            var calc = new Calculator(new HexEngine());
            string testValue = "7,8,F0";
            string expected = "FF";
            string actual = calc.Add(testValue);

            Assert.AreEqual<string>(expected, actual);

        }
        [DataRow("7", "7")]
        [DataRow("", "0")]
        [DataRow("7,8,5", "20")]
        [DataTestMethod]
        public void Add_ShouldReturnSum_When_All_ValuesPassed(string testValue, string expected)
        {
            var calc = new Calculator(new DecimalEngine());
            string actual = calc.Add(testValue);

            Assert.AreEqual<string>(expected, actual);

        }

        [TestMethod]
        public void Add_ShouldReturnSum_When_CommaSeparatedValuesPassed_Mock()
        {
            var mock = new Mock<ICalculationEngine>();
            mock.Setup(x=>x.Add("0", "7")).Returns("7");
            mock.Setup(x => x.Add("7", "8")).Returns("15");

            var calc = new Calculator(mock.Object);
            string testValue = "7,8";
            string expected = "15";

            string actual = calc.Add(testValue);

            Assert.AreEqual<string>(expected, actual);

        }
    }
}
