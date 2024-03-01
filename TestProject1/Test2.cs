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
            calClass.notTestMode = false;

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
       
       string input = "end";

        using (StringReader inputReader = new StringReader(input))
        {
            Console.SetIn(inputReader);

            // Act
            CalClass calClass = new CalClass();
            calClass.firstPartOfLoop();

            // Assert
          
            Assert.AreEqual(input, calClass.value);
            
        }
    }
    [Test]
    public void firstPartOfLoop_test1()
    {
        // Arrange
       
        double input1 = 5.3;
        String input = 5.3+"";

        using (StringReader inputReader = new StringReader(input))
        {
            Console.SetIn(inputReader);

            // Act
            CalClass calClass = new CalClass();
            calClass.firstPartOfLoop();

            // Assert
          
            Assert.AreEqual(input, calClass.value);
            
        }
    }
    
    [Test]
    public void Loop_Test()
    {
       
        string input = "+";

        using (StringReader inputReader = new StringReader(input))
        {
            Console.SetIn(inputReader);
            
            
            // Act
            CalClass calClass = new CalClass();
            calClass.number=false;
            calClass.running = false;
            calClass.running = false;
            calClass.notTestMode = false;
            
            calClass.Loop();

            // Assert
        
            Assert.AreEqual(input, calClass.value);

            
        }
        
    }
  }
