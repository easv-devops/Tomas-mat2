using System;
using System.Data;
using ConsoleApp1;
using Dapper;
using NUnit.Framework;
using Npgsql;

namespace NpgsqlTests
{
    [TestFixture]
    public class HelperTests
    
    
    {
        
        Helper helper = new Helper();
        
        [Test]
        public void HelperClass_Initializes_Successfully()
        {

            Helper helper = new Helper();
                
            Assert.DoesNotThrow(() => {
                var conn = helper.DataSource.OpenConnection();
                Assert.IsNotNull(conn);
                conn.Close();
            }, "Expected the Helper class to initialize and open a connection successfully, but it did not.");
        }
        
                
        
            [TestCase(3, 5, 8, "Remove Me")]
            [TestCase(4, 6, 10, "Remove Me")]
            // Add more test cases as needed
            public void ConnectToDatabase_InsertsData(double val1, double val2, double val3, string caltype)
            {
                // Arrange
                Helper helper = new Helper();
        
                
                // Assert
                
                using (var conn = helper.DataSource.OpenConnection())
                {
                    var result=conn.QueryFirst<string>("INSERT INTO calculation (val1, val2, val3, operator) VALUES (@val1, @val2, @val3, @operator) RETURNING *;",
                        new { val1 = val1, val2 = val2, val3 = val3, @operator = caltype });
                    
                    Assert.IsNotNull(result); // Ensure the row exists
                }
                
                using (var conn = helper.DataSource.OpenConnection())
                {
                    conn.Execute("DELETE FROM calculation WHERE val1 = @val1 AND val2 = @val2 AND val3 = @val3 AND operator = @operator;",
                        new { val1 = val1, val2 = val2, val3 = val3, @operator = caltype });
                }
                
                
            }
    }
       
}

        
        

    