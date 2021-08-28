using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static Demo.Sync.OfficeContext;

namespace Demo.Sync
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new OfficeContext()){
                try
                {
                    var a = context.Students.FirstOrDefault(x => x.Id == 1); 
                    a.Name = "1234";
                    var c = context.SaveChanges();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
         
            }
        }
    }
}
