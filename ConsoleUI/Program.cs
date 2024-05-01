using Business.Concrete;
using ConsoleUI;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;





TestContext context = new TestContext();
context.Car.ToList().ForEach(c => Console.WriteLine(c.Description));