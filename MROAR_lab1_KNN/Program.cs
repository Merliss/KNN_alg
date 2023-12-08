// See https://aka.ms/new-console-template for more information
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using MROAR_lab1_KNN;

CultureInfo.CurrentCulture = new CultureInfo("en-US", false);



double[,] training_data = new double[800, 40];
double[,] testing_data = new double[400, 40];
double[,] training_data_only = new double[800, 40];
double[,] testing_data_only = new double[400, 40];



FileOperations.LoadToMatrix(training_data, "training.dat");
FileOperations.LoadToMatrix(testing_data, "testing.dat");

training_data_only = FileOperations.DataOnly(training_data);
testing_data_only = FileOperations.DataOnly(testing_data);





for (int k=1; k<=15; k+=2)
{
KNN.KNNFun("manhattan", k, training_data, testing_data, testing_data_only);

}





