/*
Задайте прямоугольный двумерный массив. Напишите программу,
Которая будет находить строку с наименьшей суммой элементов.
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

int[] GetMinSumRow(int[,] matrix)
{
    int[] sumRowArray = new int[matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        int tempRowSum = 0;

        for (int j = 0; j < matrix.GetLength(1); j++)
            tempRowSum += matrix[i, j];

        sumRowArray[i] = tempRowSum;
        Console.WriteLine(sumRowArray[i]); // для проверки сумм строк
    }

    int maxSumRow = sumRowArray[0];
    int maxRowIndex = 0;

    for (int i = 0; i < sumRowArray.Length; i++)
    {
        if (sumRowArray[i] > maxSumRow)
            maxRowIndex = i;
    }

    Console.WriteLine($"Max row index: {maxRowIndex}"); // для удобства проверки
    Console.WriteLine();

    int[] resultArray = new int[matrix.GetLength(1)];
    
    for (int i = 0; i < resultArray.Length; i++)
        resultArray[i] = matrix[maxRowIndex, i];

    return resultArray;
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

int[] result = GetMinSumRow(matrix);

Console.WriteLine("Row with elements max amount: ");
for (int i = 0; i < result.Length; i++)
{
    Console.Write(result[i] + " ");
}