
namespace TC_Kimlik_Dogrulama.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            TCIdentity tCIdentity = TcValidator.ValidateIdentity("12345678912");
            Console.WriteLine(tCIdentity.IsValid);
            Console.WriteLine(tCIdentity.Gender);
        }
    }
}