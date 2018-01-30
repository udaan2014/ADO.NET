using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframework
{
    class Program
    {
        static void Main(string[] args)
        {

            int ch = 0, id = 0;
            string desc = string.Empty;
            NORTHWNDEntities entityObj = new NORTHWNDEntities();
            Region regionObj = new Region();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n**********Menu**********\n1.View\n2.Updation\n3.Insertion\n4.Deletion\n5.Exit");
                    Console.Write("Enter your Choice:");
                    ch = int.Parse(Console.ReadLine());                    
                    switch (ch)
                    {
                        case 1:
                            //Using Store Procedure
                            //var result1=entityObj.USP_ViewRegion();
                            //Using Query to DB
                            var result1 = from u in entityObj.Regions select new { RegionID = u.RegionID, RegionDescription = u.RegionDescription };
                            foreach (var item in result1)
                            {
                                Console.WriteLine("RegionID: "+item.RegionID+" RegionDescription: "+item.RegionDescription);
                            }
                            break;
                        case 2:
                            Console.Write("\nEnter the Region ID for Updation:");
                            id = int.Parse(Console.ReadLine());
                            List<Region> result2= (from u in entityObj.Regions where u.RegionID==id select u).ToList();
                            
                            Console.Write("\nEnter the value for Updated Region Description:");
                            desc = Console.ReadLine();
                            foreach(Region item in result2)
                            {
                                item.RegionDescription = desc;                            
                            }
                            entityObj.SaveChanges();
                            //entityObj.USP_UpdateRegion(id, desc);
                            break;
                        case 3:                            
                            Console.Write("\nEnter the Region ID:");
                            id = int.Parse(Console.ReadLine());
                            Console.Write("\nEnter the Region Description:");
                            desc = Console.ReadLine();
                            
                            regionObj.RegionDescription = desc;
                            regionObj.RegionID = id;
                            entityObj.Regions.Add(regionObj);
                            entityObj.SaveChanges();
                            //entityObj.Database.ExecuteSqlCommand("insert into Region values ({0},{1})",id,desc);
                            Console.WriteLine("Insertion Successful");
                            break;;
                        case 4:
                            Console.Write("\nEnter the Region ID for Deletion:");
                            id = int.Parse(Console.ReadLine());

                            regionObj = entityObj.Regions.Single(r => r.RegionID == id);
                            entityObj.Regions.Remove(regionObj);
                            entityObj.SaveChanges();

                            //entityObj.Database.ExecuteSqlCommand("delete from Region where RegionID={0}",id);
                            Console.WriteLine("Deletion Successful");
                            break;
                        case 5:
                            return;
                        default:
                            Console.Write("Please enter a valid choice::");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
        }
    }
}
