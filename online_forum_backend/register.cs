using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace online_forum_backend
{
    class register
    {
        public register(string userName, string passwd)
        {
            Console.Write("Enter your userName:");
            userName = Console.ReadLine();
            if (userName == null)
            {
                Console.Write("Enter your password:");
                passwd = Console.ReadLine();

                Console.Write("Enter your password again:");
                string passwd2 = Console.ReadLine();

                if (passwd == passwd2)
                    Console.Write("Register success!");
                else
                    Console.Write("Incorrect password!");
            }
            else
                Console.Write("The account already exist!");
        }
    }
}
