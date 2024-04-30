using Business.Concrete;
using ConsoleUI;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Concrete;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;





ReCarContext context = new ReCarContext();
try
{
    var result = context.Car.ToList();
    
}
catch (Exception e)
{


    throw new Exception(e.Message);

}
