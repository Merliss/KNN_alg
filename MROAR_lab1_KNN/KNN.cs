using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MROAR_lab1_KNN
{
    internal class KNN
    {
        public static void KNNFun(string method, int k, double[,] training_data, double[,] testing_data, double[,] testing_data_only)
        {
            int[,] confusion_matrix = new int[10, 10];
            double accuracy = 0;

            for (int i = 0; i < testing_data_only.GetLength(0); i++)
            {
                double predictedClass = 0;
                if (method == "euclidean")
                {
                    predictedClass = KNNCalc.KnnEuclides(FileOperations.GetRow(testing_data_only, i), training_data, k);
                }
                if (method == "manhattan")
                {
                    predictedClass = KNNCalc.KnnManhattan(FileOperations.GetRow(testing_data_only, i), training_data, k);
                }
                double realClass = testing_data[i, 0];
                
                confusion_matrix[(int)realClass - 1, (int)predictedClass - 1] += 1;

                if (predictedClass == realClass)
                {
                    accuracy = accuracy + 1.0;
                }

            }
            
            Console.WriteLine($"Accuracy: {(accuracy / testing_data_only.GetLength(0)) * 100}% when k = {k}");

            for (int i = 0; i <= 10 - 1; i++)
            {
                for (int j = 0; j <= 10 - 1; j++)
                {
                    Console.Write($"{confusion_matrix[i, j]}\t");
                }
                Console.WriteLine();
            }

        }

    }
}
