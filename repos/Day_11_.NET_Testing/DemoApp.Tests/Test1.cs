namespace DemoApp.Tests;

[TestClass]
public sealed class Test1
{
    [TestMethod]
    public void TestMethod1()
    {
        //Arrange
        var calculator = new Calcualtor();
        int a = 5;
        int b = 10;
        int expected = 50;

        //Act
        var result = calculator.Multiply(a, b);

        //Assert
        Assert.AreEqual(expected, result);
    }
}
