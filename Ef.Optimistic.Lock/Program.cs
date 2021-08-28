using System;
using System.Linq;

namespace Ef.Optimistic.Lock
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
