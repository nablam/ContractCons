using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractConsProject
{
    class Program
    {
        static void Main(string[] args)
        {
             MainApp ma = new MainApp();
             ma.DoTimer();

            //ContractionsList cl = new ContractionsList();

            //cl.addContractoin(new ContractionObj(1, DateTime.Now, DateTime.Now.AddMilliseconds(10), 1));
            //cl.addContractoin(new ContractionObj(2, DateTime.Now, DateTime.Now.AddMilliseconds(20), 2));
            //cl.addContractoin(new ContractionObj(3, DateTime.Now, DateTime.Now.AddMilliseconds(30), 3));

            //cl.printAll();

            //ContractionObj co=  cl.editContraCtion(2);
            //co.intensity = 999;
            //cl.printAll();
        }
    }
}
