using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
namespace MROAR_lab1_KNN
{
    internal class KNNCalc
    {

        public static double KnnEuclides(double[] oneGestureVector, double[,] trainingDataOnly, int k)
        {
            List<(double, double)> distances = new List<(double, double)>();

            // Obliczanie odległości euklidesowej
            int numRows = trainingDataOnly.GetLength(0);
            int numCols = trainingDataOnly.GetLength(1) - 1;

            for (int i = 0; i < numRows; i++)
            {
                double[] trainingVector = new double[numCols];
                for (int j = 0; j < numCols; j++)
                {
                    trainingVector[j] = trainingDataOnly[i, j+1];
                }

                double label = trainingDataOnly[i, 0];
                double distance = DistancesCalculation.EuclideanDistance(oneGestureVector, trainingVector);
                distances.Add((label, distance));
            }

            // Sortowanie odległości
            
            distances.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            // Wybieranie k najbliższych sąsiadów
            List<double> nearestNeighboursLabels = distances.Take(k).Select(x => x.Item1).ToList();

            // Wybieranie etykiety na podstawie głosowania większościowego
            double nearestNeighboursLabel = nearestNeighboursLabels.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;

            return nearestNeighboursLabel;
        }

        public static double KnnManhattan(double[] oneGestureVector, double[,] trainingDataOnly, int k)
        {
            List<(double, double)> distances = new List<(double, double)>();

            // Obliczanie odległości euklidesowej
            int numRows = trainingDataOnly.GetLength(0);
            int numCols = trainingDataOnly.GetLength(1) - 1;

            for (int i = 0; i < numRows; i++)
            {
                double[] trainingVector = new double[numCols];
                for (int j = 0; j < numCols; j++)
                {
                    trainingVector[j] = trainingDataOnly[i, j + 1];
                }

                double label = trainingDataOnly[i, 0];
                double distance = DistancesCalculation.ManhattanDistance(oneGestureVector, trainingVector);
                distances.Add((label, distance));
            }

            // Sortowanie odległości

            distances.Sort((x, y) => x.Item2.CompareTo(y.Item2));

            // Wybieranie k najbliższych sąsiadów
            List<double> nearestNeighboursLabels = distances.Take(k).Select(x => x.Item1).ToList();

            // Wybieranie etykiety na podstawie głosowania większościowego
            double nearestNeighboursLabel = nearestNeighboursLabels.GroupBy(x => x).OrderByDescending(g => g.Count()).First().Key;

            return nearestNeighboursLabel;
        }





    }
}
