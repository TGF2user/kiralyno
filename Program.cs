using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace N_QueenProblem
{
    public struct uniquePositionStruct
    {
        public int valueOfX,valueOfY;
    }
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch stopwatchThatMeasuresTimeAndShit = new Stopwatch();
            stopwatchThatMeasuresTimeAndShit.Start();

            Console.CursorVisible = false;

            int sizeOfMatrixPerSide = 8;
            decimal numberOfSteps = 0;

            bool[,] isThereA_QueenThere = new bool[sizeOfMatrixPerSide, sizeOfMatrixPerSide];
            bool[,] isThereFreeSpaceAtPoint = new bool[sizeOfMatrixPerSide, sizeOfMatrixPerSide];

            List<uniquePositionStruct> placedQueenAtPosition = new List<uniquePositionStruct>();

            bool[] isThereQueenYet = new bool[sizeOfMatrixPerSide];

            #region change the value of every element in matrix
            for (int outerLoopVariable = 0; outerLoopVariable < isThereFreeSpaceAtPoint.GetLength(0); outerLoopVariable++)
            {

                for (int innerLoopVariable = 0; innerLoopVariable < isThereFreeSpaceAtPoint.GetLength(1); innerLoopVariable++)
                {
                    isThereFreeSpaceAtPoint[outerLoopVariable, innerLoopVariable] = true;
                }

            }
            #endregion

            #region Solving the N-Queen problem with the Backtrack algorythm method because just.

            for (int outerLoopVariable = 0; outerLoopVariable < isThereFreeSpaceAtPoint.GetLength(0); outerLoopVariable++)
            {
                for (int innerLoopVariable = 0; innerLoopVariable < isThereFreeSpaceAtPoint.GetLength(1); innerLoopVariable++)
                {
                    uniquePositionStruct Temp = new uniquePositionStruct();

                    if (isThereFreeSpaceAtPoint[outerLoopVariable, innerLoopVariable])
                    {
                        putQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(innerLoopVariable, outerLoopVariable, isThereFreeSpaceAtPoint, isThereA_QueenThere);

                        Temp.valueOfX = innerLoopVariable;
                        Temp.valueOfY = outerLoopVariable;
                        placedQueenAtPosition.Add(Temp);
                        isThereQueenYet[outerLoopVariable] = true;

                        numberOfSteps++;
                    }
                    else if (!isThereQueenYet[outerLoopVariable] && isThereQueenYet[outerLoopVariable - 1] && !isThereFreeSpaceAtPoint[outerLoopVariable, innerLoopVariable] && innerLoopVariable == isThereFreeSpaceAtPoint.GetLength(1) - 1 && outerLoopVariable > 0 && placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX < isThereFreeSpaceAtPoint.GetLength(1) - 1)
                    {
                        removesQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX, placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfY, isThereFreeSpaceAtPoint, isThereA_QueenThere);

                        isThereQueenYet[outerLoopVariable - 1] = false;

                        innerLoopVariable = placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX;
                        outerLoopVariable = placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfY;

                        placedQueenAtPosition.RemoveAt(placedQueenAtPosition.Count - 1);

                        numberOfSteps++;
                    }
                    else if (placedQueenAtPosition.Count > 1 && !isThereQueenYet[outerLoopVariable] && isThereQueenYet[outerLoopVariable - 1] && isThereQueenYet[outerLoopVariable - 2] && !isThereFreeSpaceAtPoint[outerLoopVariable, innerLoopVariable] && innerLoopVariable == isThereFreeSpaceAtPoint.GetLength(1) - 1 && outerLoopVariable > 1 && placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX == isThereFreeSpaceAtPoint.GetLength(1) - 1)
                    {
                        removesQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX, placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfY, isThereFreeSpaceAtPoint, isThereA_QueenThere);
                        placedQueenAtPosition.RemoveAt(placedQueenAtPosition.Count - 1);
                        removesQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX, placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfY, isThereFreeSpaceAtPoint, isThereA_QueenThere);
                        
                        isThereQueenYet[outerLoopVariable - 1] = false;
                        isThereQueenYet[outerLoopVariable - 2] = false;

                        innerLoopVariable = placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfX;
                        outerLoopVariable = placedQueenAtPosition[placedQueenAtPosition.Count - 1].valueOfY;

                        placedQueenAtPosition.RemoveAt(placedQueenAtPosition.Count - 1);

                        numberOfSteps++;
                    }
                }

                #endregion
            
            }
            drawSpecifiedBoolMatrixOnScreen(isThereA_QueenThere);
            Console.WriteLine("\nEltelt idő: {0}\nLépések száma: {1}", stopwatchThatMeasuresTimeAndShit.Elapsed.ToString(),numberOfSteps);
            Console.ReadLine();
        }

        static void drawSpecifiedBoolMatrixOnScreen(bool[,] referredBoolMatrix)
        {
            for (int outerLoopVariable = 0; outerLoopVariable < referredBoolMatrix.GetLength(0); outerLoopVariable++)
            {

                for (int innerLoopVariable = 0; innerLoopVariable < referredBoolMatrix.GetLength(1); innerLoopVariable++)
                {
                    

                    if (referredBoolMatrix[outerLoopVariable, innerLoopVariable])
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.Write(" ");
                    }
                    else if ((innerLoopVariable % 2 == 0 && outerLoopVariable % 2 == 0) || (innerLoopVariable % 2 != 0 && outerLoopVariable % 2 != 0))
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.Write(" ");
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.Write(" ");
                    }
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }
        }
        static void putQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(int position_X, int position_Y, bool[,] referenceToFreeSpaceMatrix, bool[,] referenceToQueenMatrix)
        {
            

            referenceToQueenMatrix[position_Y, position_X] = true;

            for (int loopVariable = 0; loopVariable < referenceToFreeSpaceMatrix.GetLength(0); loopVariable++)
            {
                referenceToFreeSpaceMatrix[loopVariable, position_X] = false;
            }

            for (int loopVariable = 0; loopVariable < referenceToFreeSpaceMatrix.GetLength(1); loopVariable++)
            {
                referenceToFreeSpaceMatrix[position_Y, loopVariable] = false;
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable < referenceToFreeSpaceMatrix.GetLength(0); outerLoopVariable++)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable < referenceToFreeSpaceMatrix.GetLength(1); innerLoopVariable++)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = false;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable >= 0; outerLoopVariable--)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable >= 0; innerLoopVariable--)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = false;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable >= 0; outerLoopVariable--)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable < referenceToFreeSpaceMatrix.GetLength(1); innerLoopVariable++)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = false;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable < referenceToFreeSpaceMatrix.GetLength(0); outerLoopVariable++)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable >= 0; innerLoopVariable--)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = false;
                    }
                }
            }
            
        }
        static void removesQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(int position_X, int position_Y, bool[,] referenceToFreeSpaceMatrix, bool[,] referenceToQueenMatrix)
        {
            referenceToQueenMatrix[position_Y, position_X] = false;

            for (int loopVariable = 0; loopVariable < referenceToFreeSpaceMatrix.GetLength(0); loopVariable++)
            {
                referenceToFreeSpaceMatrix[loopVariable, position_X] = true;
            }

            for (int loopVariable = 0; loopVariable < referenceToFreeSpaceMatrix.GetLength(1); loopVariable++)
            {
                referenceToFreeSpaceMatrix[position_Y, loopVariable] = true;
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable < referenceToFreeSpaceMatrix.GetLength(0); outerLoopVariable++)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable < referenceToFreeSpaceMatrix.GetLength(1); innerLoopVariable++)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = true;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable >= 0; outerLoopVariable--)
            {
                for (int j = position_X; j >= 0; j--)
                {
                    if (Math.Abs(position_X - j) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, j] = true;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable >= 0; outerLoopVariable--)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable < referenceToFreeSpaceMatrix.GetLength(1); innerLoopVariable++)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = true;
                    }
                }
            }

            for (int outerLoopVariable = position_Y; outerLoopVariable < referenceToFreeSpaceMatrix.GetLength(0); outerLoopVariable++)
            {
                for (int innerLoopVariable = position_X; innerLoopVariable >= 0; innerLoopVariable--)
                {
                    if (Math.Abs(position_X - innerLoopVariable) == Math.Abs(position_Y - outerLoopVariable))
                    {
                        referenceToFreeSpaceMatrix[outerLoopVariable, innerLoopVariable] = true;
                    }
                }
            }

            for (int outerLoopVariable = 0; outerLoopVariable < referenceToQueenMatrix.GetLength(0); outerLoopVariable++)
            {

                for (int innerLoopVariable = 0; innerLoopVariable < referenceToQueenMatrix.GetLength(1); innerLoopVariable++)
                {

                    if (referenceToQueenMatrix[outerLoopVariable, innerLoopVariable])
                    {
                        putQueenAtPositionInBoolMatrixAndSpecifiesFreeSpaces(innerLoopVariable, outerLoopVariable, referenceToFreeSpaceMatrix, referenceToQueenMatrix);
                    }
                }
            }

        }
    }
    
}
