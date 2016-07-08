using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractConsProject
{
    public class MainApp
    {

        public MainApp() { }

        public void DoTimer() {

            while (Console.ReadLine() != "0") {
                Console.WriteLine("boom");
            }
            Console.WriteLine("done");

        }
    }
}
