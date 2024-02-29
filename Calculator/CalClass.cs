using Dapper;
using DefaultNamespace.MatCalculations;
using Npgsql;
using Tests;

namespace ConsoleApp1;


	


public class CalClass()
{
	public  double val1,val2;
	 bool running=true;
	 bool number=false;
	 string value1,value2;

	 
	 
	 
    public  void getCalnumbers()
    	{
    		Console.WriteLine("-----Calculater----------------------------------- ");
    		Console.WriteLine("-----Number 1------------------------------------- ");
    		 val1= double.Parse( Console.ReadLine());
    
    		Console.WriteLine("-----Number 2-------------------------------------- ");
    		 val2= double.Parse(Console.ReadLine());
    
    	}
    
    	public void Loop()
    	{
    		while (running)
    		{
    			if (number)
    				firstPartOfLoop(value2);
    			else
    			{
				    Console.WriteLine("-----Calculation type: +-*/ or end------------");
					secondPartOfLoop(Console.ReadLine());
    			}
    		
    		}
    	}
    
    	public double firstPartOfLoop(string value2)
	    {
		    double val4;
    
    		Console.WriteLine("-----number or end--------------------------");
		    {
			    value2 = Console.ReadLine();
			    val4 = 0;
		    }
		     
    
    		if (value2.ToLower().Contains("end"))
    		{
    			Console.WriteLine("-----Bye---------------------------------");
    			running = false;
			     val4 = 1;
		    }
    		else
    		{
    			val2 = double.Parse(value2);
    			number = false;
    			
    		}
    
    		return val4 ; 
    	}
    
    	
    	public  double secondPartOfLoop(string caltype)
	    {
		    double val3 = val1;
    		
		    
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
    
		    using (var conn = Helper.DataSource.OpenConnection())
		    {
			    conn.QueryFirst<string>("INSERT INTO calculation (val1, val2, val3, operator) VALUES (@val1, @val2, @val3, @operator) RETURNING *;",
			                 new { val1 = val1, val2 = val2, val3 = val3, @operator = caltype });
		    }
		  
		    
		    
    		Console.WriteLine(val1);
    		number = true;
    		
    		return val1; //decimaltal returnes til test og ikke andet
    	}
	    
	    
	    
}