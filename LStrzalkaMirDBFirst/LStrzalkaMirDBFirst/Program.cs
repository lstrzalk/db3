using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LStrzalkaMirDBFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SimpleDBLStrzalka() ) 
                {

                    while (true)
                    {
                        Console.Write("Insert value or type exit to leave: ");
                        var exit = Console.ReadLine();
                        if (exit == "exit")
                        {
                            break;
                        }
                        else
                        {
                            var blog = new simpleTab { val = Int32.Parse(exit) };
                            db.simpleTab.Add(blog);
                            db.SaveChanges();
                            var query = from b in db.simpleTab
                                        orderby b.id
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
}
