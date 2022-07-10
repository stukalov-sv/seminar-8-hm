/*
Задайте двумерный массив. Напишите программу, которая 
упорядочит по убыванию элементы каждой строки двумерного массива
*/

int GetDimension(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,] InitMatrix(int firstDimension, int secondDimension)
{
    int[,] matrix = new int[firstDimension, secondDimension];
    Random rnd = new Random();

    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
            matrix[i, j] = rnd.Next(1, 20);
    }

    return matrix;
}

void RowElementsOrdering(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix.GetLength(1) - 1 - j; k++)
            {
                int tempNumber = 0;

                if (matrix[i, k] > matrix[i, k + 1])
                {
                    tempNumber = matrix[i, k];
                    matrix[i, k] = matrix[i, k + 1];
                    matrix[i, k + 1] = tempNumber;
                }
            }
        }
    }
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

int firstDimension = GetDimension("Enter length of columns: ");
int secondDimension = GetDimension("Enter length of rows: ");
int[,] matrix = InitMatrix(firstDimension, secondDimension);
PrintMatrix(matrix);
Console.WriteLine();

RowElementsOrdering(matrix);
PrintMatrix(matrix);