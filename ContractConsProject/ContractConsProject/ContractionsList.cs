using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContractConsProject
{
    public class ContractionsList
    {

        //TODO 
        // clean list if the last entry is not complete
        //
        List<ContractionObj> _listOfContractions;
        List<double> _contractionsLengths;
        List<double> _contractionsIntervals;
        List<double> _contractionsIntensities;


        public List<ContractionObj> getlist() { return this._listOfContractions; }
        public void addContractoin(ContractionObj co) { _listOfContractions.Add(co); }
  
        Predicate<ContractionObj> ContractionByID(int id)
        {
            return delegate (ContractionObj co)
            {
                return co.contractionID ==id;
            };
        }
        public ContractionObj editContraCtion(int i)
        {
            return _listOfContractions.Find(x => x.contractionID == i);
        } 
     

        public ContractionsList() {
            _listOfContractions = new List<ContractionObj>();
            _contractionsIntensities = new List<double>();
            _contractionsIntervals = new List<double>();
            _contractionsLengths = new List<double>();
        }

        public void DoALLListsGenerations() { generateListIntensities(); generateListLengths(); generateListIntervals(); }

        private void generateListIntensities(){ foreach (ContractionObj co in _listOfContractions) { _contractionsIntensities.Add(co.intensity); } }
        private void generateListLengths() { foreach (ContractionObj co in _listOfContractions) { double l = calculateMiliseconds(co.startTime, co.endTime);_contractionsLengths.Add(l); } }
        private void generateListIntervals() {
            if (_listOfContractions.Count > 2)
            {
                for (int i = 0; i < _listOfContractions.Count-1; i++)
                {
                    int j = i + 1;
                    double interval = calculateMiliseconds(_listOfContractions.ElementAt(i).startTime, _listOfContractions.ElementAt(j).startTime);
                    _contractionsIntervals.Add(interval);
                }
            }
            else
                _contractionsIntervals.Add(-1);
        }
        private double calculateMiliseconds(DateTime a, DateTime b) {
            TimeSpan span =  b-a;
            double ms = (double)span.TotalMilliseconds;
            return ms;
        }

        public void printContractions() {
            Console.WriteLine("there are "+ _listOfContractions.Count + "contractionOBJ");
            foreach (ContractionObj co in _listOfContractions) {
                Console.WriteLine(co.contractionID+ " " + co.intensity + " "+ co.startTime + " " + co.endTime);
            }
            Console.WriteLine();
        }

        public void printLengths() { Console.WriteLine("there are " + _contractionsLengths.Count + "lengths"); foreach (double i in _contractionsLengths) Console.Write(i + " "); Console.WriteLine(); }
        public void printIntensities() { Console.WriteLine("there are " + _contractionsIntensities.Count + "intensities"); foreach (double i in _contractionsIntensities) Console.Write(i + " "); Console.WriteLine(); }
        public void printIntervals() { Console.WriteLine("there are " + _contractionsIntervals.Count + "intervals"); foreach (double i in _contractionsIntervals) Console.Write(i + " "); Console.WriteLine(); }

        public void PRINTALL() {

            printContractions(); printLengths(); printIntensities(); printIntervals();

        }

        public void testregression() { LineraRegression(_contractionsIntensities); }
        public void Print_REGRESS_intensity() { Console.WriteLine(LineraRegression(_contractionsIntensities)); }
        public void Print_REGRESS_interval() { Console.WriteLine(LineraRegression(_contractionsIntervals)); }
        public void Print_REGRESS_lengths() { Console.WriteLine(LineraRegression(_contractionsLengths)); }

        private double LineraRegression(List<double> LX)
        {

            List<double> LY = new List<double>();
            for (int i = 1; i <= LX.Count; i++) {
                LY.Add(i);
            }

            Console.WriteLine(LY.Count);

            //double[] x = { 1, 3, 10, 16, 26, 36 };
            //double[] y = { 42, 50, 75, 100, 150, 200 };

            double n = LY.Count;

            double Ex = 0;
            for (int i = 0; i < n; i++) { Ex += LX.ElementAt(i); }
            double Ey = 0;
            for (int i = 0; i < n; i++) { Ey += LY.ElementAt(i); }
            double Ex2 = 0;
            for (int i = 0; i < n; i++) { Ex2 += LX.ElementAt(i) * LX.ElementAt(i); }
            double Ey2 = 0;
            for (int i = 0; i < n; i++) { Ey2 += LY.ElementAt(i) * LY.ElementAt(i); }
            double Exy = 0;
            for (int i = 0; i < n; i++) { Exy += LX.ElementAt(i) * LY.ElementAt(i); }
            ////y=a+bx
            ////   n*Exy -  Ex Ey 
            ////B=---------------
            ////   n Ex2 - Ex^2

            double B = ((n * Exy) - (Ex * Ey)) / ((n * Ex2) - (Ex * Ex));
            //Console.WriteLine("B=" + B);

            ////    _      _
            //// A= Y  - b X    (Y bar is the mean of Y or Ey/n
            //double Ybar = Ey / n;
            //Console.WriteLine("Ybar=" + Ybar);
            //double Xbar = Ex / n;
            //Console.WriteLine("Xbar=" + Xbar);

            //double A = Ybar - (B * Xbar);
            //Console.WriteLine("A=" + A);

            //basically if B is negative the slope goes down

            return B;
        }
    }
}
