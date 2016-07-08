using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractConsProject
{
    public class MainApp
    {
        ContractionsList CL;

        public MainApp() { CL = new ContractionsList(); }

        public void DoTimer() {


            bool onOff = true;
            int i = 0;
            Random r = new Random();
            int tick = 0;
            while (Console.ReadLine() != "0") {

                if (onOff)
                {
                    Console.WriteLine( "making");
                    ContractionObj co = new ContractionObj(CL.getlist().Count + 1, DateTime.Now, DateTime.Now, 0);
                    CL.addContractoin(co);

                }
                else
                {
                    
                    Console.WriteLine("sending");
                    ContractionObj lastco = CL.editContraCtion(CL.getlist().Count);
                    lastco.endTime = DateTime.Now;
                    i = r.Next(0, 10);
                    lastco.intensity = i;
                }
                onOff = !onOff;
            }
            Console.WriteLine("done");
            CL.DoALLListsGenerations();
            //  CL.PRINTALL();
            // CL.testregression();
            Console.WriteLine();
            CL.Print_REGRESS_intensity();
            Console.WriteLine();
            CL.Print_REGRESS_interval();
            Console.WriteLine();
            CL.Print_REGRESS_lengths();
        }
    }
}
