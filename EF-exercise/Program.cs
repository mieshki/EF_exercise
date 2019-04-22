using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_exercise
{
    class Program
    {
        static void Main()
        {
            PrintMenu();
        }

        static void PrintMenu()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("1. Add new user to db");
            Console.WriteLine("2. Print Users table");
            Console.WriteLine("3. Edit user by id");
            Console.WriteLine("4. Delete user by id");
            Console.WriteLine("9. Close application");
            Console.WriteLine("------------------------------------------------------------");
            string input = Console.ReadLine();
            WhichOptionChoosed(input);
        }

        static void WhichOptionChoosed(string target)
        {
            switch (target)
            {
                case "1":
                    DBoperations.AddUserToDb();
                    break;
                case "2":
                    DBoperations.PrintUsersTable();
                    break;
                case "3":
                    int id_edit = AskForId();
                    if(id_edit != -1)
                        DBoperations.EditUserById(id_edit);
                    break;
                case "4":
                    int id_delete = AskForId();
                    if (id_delete != -1)
                        DBoperations.DeleteUserById(id_delete);
                    break;
                case "9":
                    System.Environment.Exit(1);
                    break;
                default:
                    Console.WriteLine("Wrong input, please try again.");
                    break;
            }

            PrintMenu();
        }

        static int AskForId()
        {
            try
            {
                Console.Write("User id: ");
                string id = Console.ReadLine();
                return int.Parse(id);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.Message);
                Console.WriteLine("Enter proper id again...");
                return -1;
            }
        }   
    }
}
