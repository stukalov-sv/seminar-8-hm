/*
Задайте две матрицы. Напишите программу,
которая будет находить произведение двух матриц.
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
            matrix[i, j] = rnd.Next(0, 10);
    }

    return matrix;
}

int[,] GetTwoMatrixProduct(int[,] matrix1, int[,] matrix2)
{
    int[,] resultMatrix = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

    for (int i = 0; i < resultMatrix.GetLength(0); i++)
    {
        for (int j = 0; j < resultMatrix.GetLength(1); j++)
        {
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {              
                resultMatrix[i,j] += matrix1[i,k] * matrix2[k,j];
            }
        }
    }

    return resultMatrix;
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

int firstDimension1 = GetDimension("Enter first matrix length of columns: ");
int secondDimension1 = GetDimension("Enter first matrix length of rows: ");
int[,] matrix1 = InitMatrix(firstDimension1, secondDimension1);
PrintMatrix(matrix1);
Console.WriteLine();

int firstDimension2 = GetDimension("Enter second matrix length of columns: ");
int secondDimension2 = GetDimension("Enter second matrix length of rows: ");
int[,] matrix2 = InitMatrix(firstDimension2, secondDimension2);
PrintMatrix(matrix2);
Console.WriteLine();

if (matrix1.GetLength(1) == matrix2.GetLength(0))
{
int[,] result = GetTwoMatrixProduct(matrix1, matrix2);
PrintMatrix(result);
}
else
    Console.WriteLine("Product of matrix doesn't exist");