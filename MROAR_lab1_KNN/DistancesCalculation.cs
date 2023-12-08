using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MROAR_lab1_KNN
{
    internal class DistancesCalculation
    {
        public static double EuclideanDistance(double[] x , double[] y) 
        {
            if (x.Length != y.Length) throw new ArgumentException("Invalid lenght of vectors");
            double sumOfSquares = 0.0;
            for (int i = 0; i < x.Length; i++) 
            {
                sumOfSquares += Math.Pow(x[i] - y[i], 2);
            }
            return Math.Sqrt(sumOfSquares);        
        }

        public static double ManhattanDistance(double[] x, double[] y)
        {
            if (x.Length != y.Length) throw new ArgumentException("Invalid lenght of vectors");
            double sumManhattan = 0.0;
            for (int i = 0; i < x.Length; i++)
            {
                sumManhattan += Math.Abs(x[i] - y[i]);
            }
           return Math.Sqrt(sumManhattan);
        }
    }
}
