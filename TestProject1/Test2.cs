using ConsoleApp1;

namespace TestProject1;

public class Test2
{
   
    [Test]
    public void GetCalnumbers_Method_test()
    {
        // Arrange
        double expectedVal1 = 10.1;
        double expectedVal2 = 20.7;
        string input = $"{expectedVal1}\n{expectedVal2}";

        using (StringReader inputReader = new StringReader(input))
        {
            Console.SetIn(inputReader);

            // Act
            CalClass calClass = new CalClass();
            calClass.getCalnumbers();

            // Assert
            
            Assert.AreEqual(expectedVal1, calClass.val1);
            Assert.AreEqual(expectedVal2, calClass.val2);
        }
    }
    
    
    [Test]
    public void firstPartOfLoop_test()
    {
        // Arrange
        string expectedVal1 = "end";
       
        string input = $"{expectedVal1}";

        using (StringReader inputReader = new StringReader(input))
        {
            Console.SetIn(inputReader);

            // Act
            CalClass calClass = new CalClass();
            calClass.firstPartOfLoop();

            // Assert
            
            Assert.AreEqual(expectedVal1, calClass.value2);
            
        }
    }
    
}