using AppDemo.Server.Domain;
namespace AppDemo.UnitTesting.Domain;
public class CalcTest
{
        [Fact]
        public void TestAdd()
        {
            // Act
            var result = Calc.Add(1, 2);
            // Assert
            Assert.Equal(3, result);
        }
}
