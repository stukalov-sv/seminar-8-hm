/*
Заполните спирально массив 4 х 4
*/

int GetDimension(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] SpiralFillMatrix(int firstDimension, int secondDimension)
{
    int[,] matrix = new int[firstDimension, secondDimension];
    int tempNumber = 1;
    int tempTurn = firstDimension;
    int tempCountCycle = 0;

    while (tempTurn > tempCountCycle)
    {
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < tempTurn; j++)
            {
                if (i == 0 && j < tempTurn - tempCountCycle)
                    matrix[i + tempCountCycle, j + tempCountCycle] = tempNumber;
                else if (j != 0)
                {
                    if (i == 1 && j < tempTurn - tempCountCycle)
                        matrix[j + tempCountCycle, tempTurn - 1] = tempNumber;
                    else if (i == 2 && j < tempTurn - tempCountCycle)
                        matrix[tempTurn - 1, tempTurn - (j + 1)] = tempNumber;
                    else if (i == 3 && j < tempTurn - (tempCountCycle + 1))
                        matrix[tempTurn - (j + 1), tempCountCycle] = tempNumber;
                }

                tempNumber++;
            }

            tempNumber = tempNumber - tempCountCycle - 1;
        }

        tempCountCycle++;
        tempTurn--;
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    Console.WriteLine("Matrix: ");

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}   ");
        }

        Console.WriteLine();
    }
}

int firstDimension = GetDimension("Enter square matrix length: ");
int secondDimension = firstDimension;

int[,] matrix = SpiralFillMatrix(firstDimension, secondDimension);
PrintMatrix(matrix);
Console.WriteLine();