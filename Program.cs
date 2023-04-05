﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter the number of how many normal distributed random number or pairs you would like to have: ");
            Int32 Count = Convert.ToInt32(Console.ReadLine());
            Console.Write("What kind of method you would like to use (sum12, BoxMueller, Polor, CorrNormPair): ");
            string Choice = Console.ReadLine();
            double [] GetArray =  {};
            if (Choice == "sum12")
            {   
                Console.WriteLine("Sum 12 Method.");
                GetArray = Sum12(Count);
                foreach (var item in GetArray)
                {
                    Console.WriteLine(item);
                }

            }
            else if (Choice == "BoxMuller")
            {   
                Console.WriteLine("Box Muller Method.");
                GetArray = BoxMueller(Count);
                foreach (var item in GetArray)
                {
                    Console.WriteLine(item);
                }

            }
            else if (Choice == "Polor")
            {   
                Console.WriteLine("Polor Method.");
                GetArray = Polor(Count);
                foreach (var item in GetArray)
                {
                    Console.WriteLine(item);
                }
            }
            else if (Choice == "CorrNormPair")
            {   
                double [,] Arrays = new  double [Count, 2];
                Console.WriteLine("Corration Normal Distribution pairs");
                Console.Write("Please enter the corrlation you would like to have: ");
                double correlation = Convert.ToDouble(Console.ReadLine());
                Arrays = CorrNormPairs(Count, correlation); 

                foreach (var item in Arrays)
                {
                    Console.WriteLine(item);
                }
            }



        }

        static double [] Sum12(int sampleSize)
        {
            double [] Sum12Norm = new double[sampleSize];
            Random r1 = new Random();
            for(int i= 0; i < sampleSize; i++)
            {
                double result = 0;
                for (int j = 0; j < 12; j++)
                {
                    result = result + r1.NextDouble();
                }
                result = result - 6.0;
                Sum12Norm[i] = result;
    
            }
            return Sum12Norm;

        }

        static double[] BoxMueller(int sampleSize)
        {
            double [ ] BoxMuellerNorms = new double[sampleSize];
            Random r2_1 = new Random();
            Random r2_2 = new Random();
            for(int i= 0; i < sampleSize; i++)
            {
                double x1 = r2_1.NextDouble();
                double x2 = r2_2.NextDouble();
                double z1 = Math.Sqrt(-2 * Math.Log(x1))*Math.Cos(2*Math.PI*x2);
                double z2 = Math.Sqrt(-2 * Math.Log(x1))*Math.Sin(2*Math.PI*x2);
                BoxMuellerNorms[i] = z1;
            }
            return BoxMuellerNorms;
        }

        static double [] Polor(int sampleSize)
        {
            List <double> PolorNormList = new List<double>();

            Random r3_1 = new Random();
            Random r3_2 = new Random();
            int Counter = sampleSize;

            while(Counter > 0)
            {   
                double x1 = r3_1.NextDouble();
                double x2 = r3_2.NextDouble();
                if ((x1 * x1 + x2 * x2) <= 1 )
                {
                    Counter --;
                    double w = x1 * x1 + x2 * x2;
                    double c = Math.Sqrt(-2*Math.Log(w)/w);
                    double z1 = c*x1;
                    double z2 = c*x2;
                    PolorNormList.Add(z1);
                
                }
            }
            double[] PolorNorm = PolorNormList.ToArray();
            return PolorNorm;
        }

        static double [,] CorrNormPairs(int sampleSize, double corr)
        {
            double [ ,] CorrNormPairsArray = new double[sampleSize, 2];

            Random r4_1 = new Random();
            Random r4_2 = new Random();

            if (corr >= -1 && corr <= 1)
            {
                for(int i = 0; i < sampleSize; i++)
                {
                    double e1 = r4_1.NextDouble();
                    double e2 = r4_2.NextDouble();
                    double z1 = e1;
                    double z2 = corr * e1 + Math.Sqrt(1 - corr * corr) * e2;
                    CorrNormPairsArray[i,0] = z1;
                    CorrNormPairsArray[i,1] = z2;
                }
            }
            return CorrNormPairsArray;
        }



    }
}
