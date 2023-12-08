using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MROAR_lab1_KNN
{
    internal class FileOperations
    {
        public static double[,] LoadToMatrix(double[,] matrix,string path)
        {
            var file = File.ReadLines(path);

            int j = 0;
            foreach (var line in file)
            {
                List<string> stringList = new List<string>();
                List<double> doubleValues = new List<double>();
                string[] stringValues = line.Split(' ');

                for (int i = 0; i < stringValues.Length; i++)
                {
                    if (stringValues[i] != String.Empty)
                    {

                        stringList.Add(stringValues[i]);
                    }
                }

                doubleValues = stringList.ConvertAll(double.Parse);
                for (int i = 0; i < doubleValues.ToArray().Length; i++)
                {
                    matrix[j, i] = doubleValues[i];
                    
                }
                j++;
            }
            return matrix;
        }

        public static double[,] DataOnly(double[,] matrix)
        {
            int numRows = matrix.GetLength(0);
            int numCols = matrix.GetLength(1);
            double[,] resultMatrix = new double[numRows, numCols - 1];

            for (int i = 0; i < numRows; i++)
            {
                for (int j = 1; j < numCols; j++) 
                {
                    resultMatrix[i, j - 1] = matrix[i, j];
                }
            }

            return resultMatrix;
        }

        public static double[] GetRow(double[,] array, int row)
        {
            int columns = array.GetLength(1);
            double[] result = new double[columns];

            for (int i = 0; i < columns; i++)
            {
                result[i] = array[row, i];
            }

            return result;
        }




    }

}