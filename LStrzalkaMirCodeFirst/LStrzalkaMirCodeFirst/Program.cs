using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace LStrzalkaMirCodeFirst
{
    public class SimpleTabCF
    {
        public int id { get; set; }
        public int val { get; set; } 
    }
    public class CodeFirstDBLStrzalka : DbContext
    {
        public DbSet<SimpleTabCF> SimpleTabCFs { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new CodeFirstDBLStrzalka()) 
            { 
                while(true)
                {
                    Console.Write("Enter a val or type exit: ");
                    var val = Console.ReadLine(); 
                    if(val == "exit"){
                        break;
                    }
 
                    var blog = new SimpleTabCF { val = Int32.Parse(val) }; 
                    db.SimpleTabCFs.Add(blog); 
                    db.SaveChanges(); 
 
                    // Display all Blogs from the database 
                    var query = from b in db.SimpleTabCFs 
                                orderby b.val 
                                select b; 
 
                    Console.WriteLine("All vals in the database:"); 
                    foreach (var item in query) 
                    { 
                        Console.WriteLine(item.val); 
                    }
                }
            } 
        }
    }
}
