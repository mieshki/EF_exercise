using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_exercise
{
    public static class DBoperations
    {
        public static void AddUserToDb()
        {
            using (var ctx = new UsersContext())
            {
                Console.Write("Nickname: ");
                string nickname = Console.ReadLine();
                Console.Write("E-mail: ");
                string email = Console.ReadLine();

                var user = new User() { Nickname = nickname, Email = email };

                ctx.Users.Add(user);
                ctx.SaveChanges();

                Console.WriteLine("User added successfuly!");
            }
        }

        public static void PrintUsersTable()
        {
            using (var ctx = new UsersContext())
            {
                Console.WriteLine("ID | NICKNAME | EMAIL | CREATED_ON | EDITED_ON");
                var users = ctx.Users;

                if (users.Count() == 0)
                    Console.WriteLine("Table is empty");
                else
                {
                    users.ToList().ForEach(u =>
                        Console.WriteLine(u.Id + " | " + u.Nickname + " | " + u.Email + " | " + u.CreatedOn + " | " + u.EditedOn)
                    );
                }
            }
        }

        public static void EditUserById(int id)
        {
            using (var ctx = new UsersContext())
            {
                User user = ctx.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    Console.WriteLine($"User with id {id} wasn't found");
                    return;
                }

                Console.Write("New nickname: ");
                string newNickname = Console.ReadLine();
                Console.Write("New e-mail: ");
                string newEmail = Console.ReadLine();

                user.Nickname = newNickname;
                user.Email = newEmail;
                user.EditedOn = DateTime.Now;

                ctx.SaveChanges();
                Console.WriteLine("User updated successfuly!");
            }
        }

        public static void DeleteUserById(int id)
        {
            using (var ctx = new UsersContext())
            {
                User user = ctx.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    Console.WriteLine($"User with id {id} wasn't found");
                    return;
                }

                ctx.Users.Remove(user);
                ctx.SaveChanges();

                Console.WriteLine("User deleted successfuly!");
            }
        }
    }
}
