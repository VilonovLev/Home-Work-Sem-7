// Задача 47: Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

int countLine = Input("Введите кол-во строк: ");
int countColumn = Input("Введите кол-во столбцов: ");
PrintArrayDouble(CreateRanArrDouble(countLine,countColumn));

// Задача 50: Напишите программу, которая на вход принимает 
// позиции элемента в двумерном массиве, и возвращает значение этого элемента 
// или же указание, что такого элемента нет.
// Например, задан массив:

int[,] array = CreateRanArrInt(4,6);
PrintArrayInt(array);
SearchArrayElement(array);

// Задача 52: Задайте двумерный массив из целых чисел. 
// Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int[,] arrayInt = CreateRanArrInt(5,6);
PrintArrayInt(arrayInt);
ArithmeticMeanColumn(arrayInt);

// Методы

int Input(string output)
{
    Console.Write(output);
    return Convert.ToInt32(Console.ReadLine());
}

void PrintArrayInt(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i, j] > -1)
            {
                Console.Write($" {array[i, j]}  ");
            }
            else 
            {
            Console.Write($"{array[i, j]}  ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("--------------------");
}

void PrintArrayDouble(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            if(array[i, j] > 0)
            {
                Console.Write($" {array[i, j]}  ");
            }
            else 
            {
            Console.Write($"{array[i, j]}  ");
            }
        }
        Console.WriteLine();
    }
    Console.WriteLine("--------------------");
}

int[,] CreateRanArrInt(int line, int column)
{
    int[,] array = new int[line,column];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = new Random().Next(-99,100);
        }
    }
    return array;
}

double[,] CreateRanArrDouble(int line, int column)
{
    double[,] array = new double[line,column];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for(int j = 0; j < array.GetLength(1); j++)
        {
            array[i,j] = Math.Round(Convert.ToDouble(new Random().Next(-1000,1000)) 
                                                    / (new Random().Next(1,100)),2);
        }
    }
    return array;
}

void SearchArrayElement(int[,] arr)
{
    int maxElemPosition = arr.GetLength(0)*10 + arr.GetLength(1);
    int elemPosition = Input("Введите позицию элемента массива в виде двузначного числа\n" +
                             $"min = 11 max = {maxElemPosition}: " );
    int ferst = elemPosition / 10 - 1;
    int second = elemPosition % 10 - 1;
    
    if(elemPosition < 11 || elemPosition > maxElemPosition)
    {
        Console.WriteLine("Такого элемента нет.");
    }
    else
    {
        Console.WriteLine("Ваш элемент: " + arr[ferst,second] + "\n");
    }
}

void ArithmeticMeanColumn(int[,] arr)
{
    double arithmeticMean = 0; 
    string result = string.Empty;
    for (int i = 0; i < arr.GetLength(1); i++)
    {
        for(int j = 0; j < arr.GetLength(0); j++ )
        {
            arithmeticMean += arr[j,i];
        }
        result += arithmeticMean / arr.GetLength(0) + "; ";
        arithmeticMean = 0;
    }
    Console.WriteLine("Среднее арифметическое каждого столбца: " + result);
}