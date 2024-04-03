﻿using System;
using ConsoleApp1;
using NUnit.Framework;
using Npgsql;

namespace NpgsqlTests
{
    [TestFixture]
    public class HelperTests
    {
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
        
                
        }

       
    }
