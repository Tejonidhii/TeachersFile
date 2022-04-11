using System;
using System.IO;
using System.Text;



namespace TeachersFile
{
    internal class Teacher
    {
        string filename = "TeacherInfo.txt";
        public string[] readrecord(string searchTerm, int posst)
        {
            posst--;
            string[] record = File.ReadAllLines(filename);
            for (int i = 0; i < record.Length; i++)
            {
                string[] fields = record[i].Split();
                if (recordMatches(searchTerm, fields, posst))
                {
                    Console.WriteLine("record found");
                    Console.WriteLine("ID  NAME  CLASS  SEC");
                    Console.WriteLine(record[i]);

                }


            }
            return null;
        }
        public bool recordMatches(string searchTerm, string[] record, int posst)
        {
            if (record[posst].Equals(searchTerm))
            {
                return true;
            }
            else { return false; }
        }
        public void editercord(string searchTerm, int posst)
        {
            
            posst--;
            string[] record = File.ReadAllLines(filename);
            for (int i = 0; i < record.Length; i++)
            {
                string[] fields = record[i].Split();
                if (recordMatches(searchTerm, fields, posst))
                {
                    Console.WriteLine("record found");
                    Console.WriteLine(record[i]);
                    Console.WriteLine("enter new name,class and section:");
                    for (int j = 1; j < fields.Length; j++)
                    {
                        fields[j] = Console.ReadLine();

                    }
                    record[i] = string.Join(" ", fields);
                    Console.WriteLine(record[i]);



                    StreamWriter sw = new StreamWriter(filename);
                    for (int j = 0; j < record.Length; j++)
                    {
                        sw.WriteLine(record[j]);
                    }
                    sw.Close();

                    Console.WriteLine("\nrecord updated ");

                }



            }

        }
        public void deleteRecord(string searchTerm, int posst)
        {
            posst--;
            string[] record = File.ReadAllLines(filename);
            for (int i = 0; i < record.Length; i++)
            {
                Console.WriteLine(record[i]);
            }

            for (int i = 0; i < record.Length; i++)
            {
                string[] fields = record[i].Split();
                if (recordMatches(searchTerm, fields, posst))
                {

                    //Console.WriteLine(record[i]);
                    for (int j = i; j < record.Length - 1; j++)
                    {
                        if (j != record.Length - 1)
                        {
                            record[j] = record[j + 1];
                        }


                    }
                }
            }
            StreamWriter sw = new StreamWriter(filename);
            Console.WriteLine("after deletion");
            for (int k = 0; k < record.Length - 1; k++)
            {
                Console.WriteLine(record[k]);
                sw.WriteLine(record[k]);
            }
         
            sw.Close();

            Console.WriteLine("\nrecord deleted ");
        }

        public void WriteInfo(int Id, string name, string classs, string sec)
        {
            StreamWriter sw = new StreamWriter(filename, true);
            
            sw.WriteLine(Id + " " + name + " " + classs + " " + sec);
            sw.Close();
            Console.WriteLine("Write complete");
        }

        public void ReadInfo()
        {
            Console.WriteLine("choice-->  1.ReadRecord  2.Readall");
            int ch = int.Parse(Console.ReadLine());
            if (ch.Equals(1))
            {
                Console.WriteLine("enter the id ");
                string id = Console.ReadLine();
                
                readrecord(id,1);
            }
            else
            {
                StreamReader sr = new StreamReader(filename);
              
                string Infos = sr.ReadToEnd();
                Console.WriteLine("ID  NAME  CLASS  SECTION");
                Console.WriteLine(Infos);
                sr.Close();
            }
        }
        public bool idcheck(string searchTerm, int posst)
        {
            string[] record1 = File.ReadAllLines(filename);
            for (int i = 0; i < record1.Length; i++)
            {
                string[] fields = record1[i].Split();
                if (recordMatches(searchTerm, fields, posst))
                {
                  
                    Console.WriteLine("Id is used give something else");
                    return true;
                    break;

                }

            }
            return false;
        }

        static void Main(string[] args)
        {
            int Id, op, posst;
            String Ids, Ids1, name, classs, sec;
           
            Teacher Tm = new Teacher();
            Console.WriteLine("Welcome to Teachers database");
        Start: Console.WriteLine("1:Write 2:Read 3:Update 4:Delete 5:clear 6:exit");
            op = int.Parse(Console.ReadLine());
            switch (op)
            {
                case 1:
                    Console.WriteLine("enter Id name class sec of teacher:order--> ID  NAME  CLASS SECTION");
                    Console.Write("ID: ");
                    Id = int.Parse(Console.ReadLine());
                    Ids1 = Id.ToString();
                    if (Tm.idcheck(Ids1, 0))
                    {
                        
                        goto Start;
                    }
                    else
                    {
                        Console.Write("Name: ");
                        name = Console.ReadLine();
                        Console.Write("Class: ");
                        classs = Console.ReadLine();
                        Console.Write("Section: ");
                        sec = Console.ReadLine();
                    }
                    Tm.WriteInfo(Id, name, classs, sec);
                    Console.WriteLine("write successfull");
                    
                    goto Start;

                case 2:
                    Console.WriteLine("Teachers data:");

                    Tm.ReadInfo();
                   
                    goto Start;

                case 3:

                    Console.WriteLine("enter id to be edited");
                    Ids = Console.ReadLine();
                   
                    Tm.editercord(Ids, 1);
                    goto Start;

                case 4:
                    Console.WriteLine("enter id to be deleted");
                    Ids = Console.ReadLine();
                   
                    Tm.deleteRecord(Ids, 1);
                    goto Start;
                case 5:
                    Console.Clear();
                    goto Start;


            }


        }
    }
}
