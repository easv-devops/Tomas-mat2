

using ConsoleApp1;
using DefaultNamespace.MatCalculations;

public class Tests
{
    
    [TestCase]
    public void Add()
    {
        MatTypes addition = new MatTypes(new Addition());
        Assert.AreEqual(31, addition.getValue(20, 11));
    }
    
    [TestCase]
    public void Sub()
    {
        MatTypes substraction = new MatTypes(new Substraction());
        Assert.AreEqual(9, substraction.getValue(20, 11));
        
    }
    
    [TestCase]
    public void Multiplication()
    {
        MatTypes multiplication = new MatTypes(new Multiplication());
        Assert.AreEqual(20, multiplication.getValue(2, 10));
        
    }
    
    [TestCase]
    public void Divide()
    {
        MatTypes division = new MatTypes(new Division());
        Assert.AreEqual(10, division.getValue(20, 2));
        
    }
    
    [TestCase]
    public void Divide1()
    {
        MatTypes division = new MatTypes(new Division());
        Assert.AreEqual(Double.NaN, division.getValue(20, 0));
        
    }
    
    [Test]
    public void SecondPartOfLoop_Addition()
    {
        
        CalClass calClass = new CalClass();
       
        Assert.That(calClass.secondPartOfLoop("end"), Is.EqualTo(double.NaN));
    }

    // [Test]
    // public void FirstPartOfLoop_Addition()
    // {
    //     
    //     CalClass calClass = new CalClass();
    //  
    //     
    //     double result = calClass.firstPartOfLoop("end");
    //     
    //     Assert.AreEqual(1,result);
    // }
    //
}