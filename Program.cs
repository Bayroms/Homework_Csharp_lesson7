Start();

void Start()
{
    while(true)
    {
        Console.ReadLine();
        Console.Clear();

        System.Console.WriteLine("Задача 47. Задайте двумерный массив размером m x n, заполненный случайными вещественными числами.");
        System.Console.WriteLine("Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.");
        System.Console.WriteLine("Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.");
        System.Console.WriteLine("Enter 0 to end");

        int NumTask = int.Parse(Console.ReadLine());
        switch (NumTask)
        {
            case 0: return; break;
            case 47: DoubleArr(); break;
            case 50: GetNumberIndex(); break;
            case 52: columnSum(); break;
            default: System.Console.WriteLine("Enter number of task or 0"); break; 
        }
    }
}

// Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.
// m = 3, n = 4.
// 0,5 7 -2 -0,2
// 1 -3,3 8 -9,9
// 8 7,8 -7,1 9

void DoubleArr()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    double[,] matrix = GetRandomDoubleMatrix(row, column);
    PrintDoubleMatrix(matrix);
}

// Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.
// Пользователь вводит число, мы должны вывести позицию числа в массиве, если есть.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 17 -> такого числа в массиве нет

void GetNumberIndex()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    int[,] matrix = GetRandomMatrix(row, column);
    PrintMatrix(matrix);
    int searchNumber = SetNumber("Enter searching number");
    SearchNumber(matrix,searchNumber);
}

// Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

void columnSum()
{
    int row = SetNumber("Enter number of rows");
    int column = SetNumber("Enter number of colums");
    int[,] matrix = GetRandomMatrix(row, column, 0, 10);
    PrintMatrix(matrix);
    ColumnSum(matrix);
}






int SetNumber(string name)
{
    string[] arr = name.Split(" ");
    System.Console.WriteLine(name);
    int num = int.Parse(Console.ReadLine());
    return num;
}
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i,j] + " ");
        }
    System.Console.WriteLine();
    }
}
void PrintDoubleMatrix(double[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            System.Console.Write(matrix[i,j] + " ");
        }
    System.Console.WriteLine();
    }
}
int[,] GetRandomMatrix(int rows, int colums, int MinValue = -100, int MaxValue = 100)
{
    int[,] matrix = new int[rows, colums];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < colums; j++)
        {
            matrix[i,j] = random.Next(MinValue, MaxValue + 1);
        }
    }
    return matrix;
}
double[,] GetRandomDoubleMatrix(int rows, int colums)
{
    double[,] matrix = new double[rows, colums];
    var random = new Random();
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < colums; j++)
        {
            matrix[i,j] = Math.Round(random.NextDouble()* 10, 1);
        }
    }
    return matrix;
}
void SearchNumber(int[,] matrix, int searchNumber)
{
    bool Check = false;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if (matrix[i,j] == searchNumber)
            {
                System.Console.WriteLine($"Number {searchNumber} is in position row = {i} column = {j}");
                Check = true;
            }
        }
    }
    if (Check == false)
    {
        System.Console.WriteLine($"There is no {searchNumber} in this array");
    }
}
void ColumnSum(int[,] matrix)
{   
    int l = 1;
    for (int i = 0; i < matrix.GetLength(1); i++)
    {   
        double sum = 0;
        for (int j = 0; j < matrix.GetLength(0); j++)
        {
            sum += matrix[j,i];
        }
        sum = sum / matrix.GetLength(0);
        System.Console.WriteLine($"Sum of {l} column = " + Math.Round(sum, 2));
        l++;
    }
}