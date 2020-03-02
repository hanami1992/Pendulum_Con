using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pendulum_Console
{
    
    class Program
    {       
        static void Main(string[] args)
        {         

            StreamReader sr = new StreamReader("amaranthe.txt");
            StreamWriter sw = new StreamWriter("Amaranthe_Adatok.sql");        

            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                var db = sr.ReadLine().Split(';');
                if (db[0].Contains("https:")) continue;
                else if (!db.Contains("[tracks]"))
                {                    
                    if (!db.Contains("[tracks]") && !db[1].Contains(":"))
                    {
                        sw.WriteLine("INSERT INTO Albums(id,artist,title,release) VALUES ('{0}','{1}','{2}','{3}');",
                        db[0], db[1], db[2], db[3]);
                        
                    }
                    if (db.Contains("[tracks]")) continue;                

                    if (!db.Contains("[track]") && db[1].Contains(":"))
                    {
                        sw.WriteLine("INSERT INTO Tracks(title,length,album,url) VALUES ('{0}','{1}','{2}','{3}');", db[0], TimeSpan.Parse(db[1]), db[2], db[3]);
                    }

                }
            }
            sw.Close();
        }
    
    }      
 } 
