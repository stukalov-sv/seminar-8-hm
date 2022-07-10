/*
Сформируйте трёхмерный массив из неповторяющихся двухзначных чисел. 
Напишите программу, которая будет построчно выводить массив,
добавляя индексы каждого элемента
*/

int GetDimension(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine());
}

int[,,] InitThreeDimensionArray(int firstDimension, int secondDimension, int thirdDimension)
{
    int[,,] array = new int[firstDimension, secondDimension, thirdDimension];
    int tempNumber = 9;
    int tempJ = 0;
    int tempK = 0;

    for (int i = 0; i < firstDimension; i++)
    {
        for (int j = 0; j < secondDimension; j++)
        {
            for (int k = 0; k < thirdDimension; k++)
            {
                tempNumber++;
                array[i, j, k] = tempNumber;
                tempK = k;
            }

            tempNumber = array[i, j, tempK];
            tempJ = j;
        }

        tempNumber = array[i, tempJ, tempK];
    }

    return array;
}

void PrintArray(int[,,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                Console.Write($"({i},{j},{k}) = {array[i, j, k]};");
                Console.WriteLine();
            }
        }
    }
}

int firstDimension = GetDimension("Enter length of 1 dimension: ");
int secondDimension = GetDimension("Enter length of 2 dimension: ");
int thirdDimension = GetDimension("Enter length of 3 dimension: ");
Console.WriteLine();

if (firstDimension + secondDimension + thirdDimension < 14)
{
    int[,,] array = InitThreeDimensionArray(firstDimension, secondDimension, thirdDimension);
    Console.WriteLine("Elements of array:");
    PrintArray(array);
}
else
    Console.WriteLine("Incorrect array, some numbers will be more than double digit");