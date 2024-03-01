using Dapper;
using DefaultNamespace.MatCalculations;
using Npgsql;
using Tests;

namespace ConsoleApp1;


	


public class CalClass()
{
	public  double val1,val2;
	 public bool running=true, number=false,notTestMode=true;
	 public string value;

	 
	 
	 
    public  void getCalnumbers()
    	{
    		Console.WriteLine("-----Calculater----------------------------------- ");
    		Console.WriteLine("-----Number 1------------------------------------- ");
    		 val1= double.Parse( Console.ReadLine());
    
    		Console.WriteLine("-----Number 2-------------------------------------- ");
    		 val2= double.Parse(Console.ReadLine());
		     
		     if (notTestMode)
		     Loop();	
    	}
    
    	public void Loop()
	    {
		    do
		    {
			    if (number)
				    firstPartOfLoop();
			    else
			    {
				    Console.WriteLine("-----Calculation type: +-*/ or end------------");
				    value = Console.ReadLine();
				    if (notTestMode)
				    secondPartOfLoop(value);
			    }

		    } while (running);
	    }
    
    	public void firstPartOfLoop()
	    {
	
    		Console.WriteLine("-----number or end--------------------------");
		    
		    value = Console.ReadLine();
			   
		    
    		if (value.ToLower().Contains("end"))
    		{
    			Console.WriteLine("-----Bye---------------------------------");
    			running = false;
			     
		    }
    		else
    		{
    			val2 = double.Parse(value);
    			number = false;
    			
    		}
    
    		
    	}
    
    	
    	public  void secondPartOfLoop(string caltype)
	    {
		    double val3 = val1;
    		
		    //Importens messages
    		switch (caltype.ToLower())
    		{
    			case "+":
    				MatTypes addition = new MatTypes(new Addition());
    				val1 = addition.getValue(val1, val2);
    
    				break;
    
    			case "-":
    				MatTypes substract = new MatTypes(new Substraction());
    				val1 = substract.getValue(val1, val2);
    
    				break;
    
    			case "*":
    				MatTypes multiplication = new MatTypes(new Multiplication());
    				val1 = multiplication.getValue(val1, val2);
    
    				break;
    
    			case "/":
    				MatTypes division = new MatTypes(new Division());
    				val1 = division.getValue(val1, val2);
    
    				break;
    			case "end":
    				running = false;
    				val1 = Double.NaN; //Det her repræsentere et ikke tal. Håber den kan bruges til test.
    				Console.WriteLine("-----Bye---------------------------");
    				break;
    		}
    
		    if (notTestMode)
		    connectToDatabase(val3,caltype);
		    
    		Console.WriteLine(val1);
    		number = true;
    	
    	
    	}

	    public void connectToDatabase(double val3, string caltype)
	    {
		    using (var conn = Helper.DataSource.OpenConnection())
		    {
			    conn.QueryFirst<string>("INSERT INTO calculation (val1, val2, val3, operator) VALUES (@val1, @val2, @val3, @operator) RETURNING *;",
				    new { val1 = val1, val2 = val2, val3 = val3, @operator = caltype });
		    }

	    }
	    
}