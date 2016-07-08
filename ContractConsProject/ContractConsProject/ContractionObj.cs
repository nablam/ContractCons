using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractConsProject
{
    public class ContractionObj
    {
        public int contractionID;
        public DateTime startTime;
        public DateTime endTime;
        public int intensity;

        public ContractionObj() { }

        public ContractionObj(int id, DateTime s, DateTime e, int i ) { startTime = s; endTime = e; intensity = i; contractionID = id; }
    }
}
