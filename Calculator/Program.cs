using System;
using System.Collections.Generic;

namespace LearningProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            //Required declarations
            char[] symbols = { '+', '-', '/', '*' };
            double result = 0;
            bool notValid = false;

            while (!notValid)
            {
                //Insert an expression
                Console.WriteLine("Please insert an expression: ");
                string toCalc = Console.ReadLine();
                //string toCalc = "10*10/5+50--";

                //Check that the input doesn't contain parenthesis
                for (int i = 0; i < toCalc.Length; i++)
                {

                    if (toCalc[i].Equals(')') || toCalc[i].Equals('('))
                    {
                        notValid = true;
                        break;
                    }
                }
                if (notValid)
                {
                    Console.WriteLine("Input can't contain parenthesis. Try again!");
                    notValid = false;
                    break;
                }

                //Check that the input doesn't contain more than one math operations next to each other
                int trackIndex = -1; //"10*10/5+50"
                for (int i = 0; i < toCalc.Length; i++)
                {
                    if (toCalc[i].Equals('+') || toCalc[i].Equals('-') || toCalc[i].Equals('/') || toCalc[i].Equals('*'))
                    {
                        if (i == trackIndex + 1)
                        {
                            notValid = true;
                            break;
                        }
                        else
                        {
                            trackIndex = i;
                        }
                    }
                }
                if (notValid)
                {
                    Console.WriteLine("Invalid mathematical operations. Try again!");
                    notValid = false;
                    break;
                }

                //spliting the inserted string
                string[] splitted = toCalc.Split(symbols);

                //parsing string array into the array of doubles
                double[] parseSplitted = new double[splitted.Length];

                for (int i = 0; i < parseSplitted.Length; i++)
                {
                    parseSplitted[i] = double.Parse(splitted[i]);
                }

                //Calculation part
                int j = 0;
                for (int i = 0; i < toCalc.Length; i++)
                {
                    switch (toCalc[i])
                    {
                        case '+':
                            parseSplitted[j + 1] = parseSplitted[j] + parseSplitted[j + 1];
                            j++;
                            break;

                        case '-':
                            parseSplitted[j + 1] = parseSplitted[j] - parseSplitted[j + 1];
                            j++;
                            break;

                        case '*':
                            parseSplitted[j + 1] = parseSplitted[j] * parseSplitted[j + 1];
                            j++;
                            break;

                        case '/':
                            parseSplitted[j + 1] = parseSplitted[j] / parseSplitted[j + 1];
                            j++;
                            break;
                    }
                }
                result = parseSplitted[j];
                Console.WriteLine("The result is - " + result);
                notValid = true;
            }

        }
    }
}
