using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ef.Optimistic.Lock
{
    class Program
    {
        static void Main(string[] args)
        {
            using var context = new OfficeContext();
            try
            {
                var a = context.Students.FirstOrDefault(x => x.Id == 1);
                if (a is not null)
                {
                    context.Entry(a).State = EntityState.Modified;
                    a.Name = "1234";
                    var c = context.SaveChanges();
                }
              
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
