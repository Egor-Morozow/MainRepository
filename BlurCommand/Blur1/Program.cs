﻿using System.Collections.Immutable;
using System.Globalization;
using System.Runtime.InteropServices;

static void PrintArray(int[] input)
{
    for (int i = 0; i < input.Length; i++)
    {
        Console.Write(input[i] + " ");
    }
    Console.WriteLine();
}

/*var result11 = TestArray(5);
PrintArray(result11);*/

var task1Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var result1 = Task1(task1Input);
Console.Write("TASK 1:\nInput:\n");
PrintArray(task1Input);
Console.WriteLine("Result:");
PrintArray(result1);

var task1ImprovedInput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var result1Improved = Task1Improved(task1ImprovedInput);
Console.Write("TASK 1 with img size:\nInput:\n");
PrintArray(task1ImprovedInput);
Console.WriteLine("Result:");
PrintArray(result1Improved);

var task2Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
var result2 = Task2(task2Input, 5);
Console.Write("TASK 2:\nInput:\n");
PrintArray(task2Input);
Console.WriteLine("Result:");
PrintArray(result2);

/*var task3Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var result3 = Task3(task3Input);
Console.Write("TASK 3:\nInput:\n");
PrintArray(task3Input);
Console.WriteLine("Result:");
PrintArray(result3);*/

/*static int[] TestArray(int size)
{
    int[] result = new int[size];
    int beginning = -size / 2;
    for (int i = 0; i < result.Length; i++)
    {
        result[i] = beginning++;
    }
    return result;
}*/

//Просто одномерный вариант без блоков
static int[] Task1(int[] img)
{
    int[] kernel = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    int[] result = new int[img.Length - kernel.Length + 1];
    int beginning = kernel.Length / 2;
    int sum = 0;
    for (int index =  beginning; index < img.Length - beginning; index++)
    { 
        for (int i = -beginning; i < beginning + 1; i++)
        {
                sum += img[index + i] * kernel[beginning + i];
        } 
        sum /= kernel.Length;
        result[index - (img.Length - result.Length - beginning)] = sum;
        sum = 0;
    }
    return result;
}

//Одномерный вариант без блоков с размером картинки
static int[] Task1Improved(int[] img)
{
    int[] kernel = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    int[] result = new int[img.Length];
    int difference = (img.Length - (img.Length - kernel.Length + 1)) / 2;
    for (int start = 0; start < difference; start++)
    {
        result[start] = img[start];
    }
    for (int end = img.Length - difference; end < result.Length; end++)
    {
        result[end] = img[end];
    }
    int beginning = kernel.Length / 2;
    int sum = 0;
    for (int index = beginning; index < img.Length - beginning; index++)
    {
        for (int i = -beginning; i < beginning + 1; i++)
        {
            sum += img[index + i] * kernel[beginning + i];
        }
        sum /= kernel.Length;
        result[index] = sum;
        sum = 0;
    }
    return result;
}

//Одномерный вариант с блоками
static int[] Task2(int[] img, int blockSize)
{
    int[] kernel = new int[] {1, 2, 3 };
    int[] result = new int[img.Length - kernel.Length * blockSize + blockSize];
    int beginning = kernel.Length / 2;
    int sum = 0;
    int blockCount = img.Length / blockSize;
    int numOfBlock = 0;
    for (int index = beginning; index < result.Length + beginning; index++)
    {
        for (int i = -beginning; i < beginning + 1; i++)
        {
            sum += img[index - beginning + numOfBlock] * kernel[beginning + i];
            if (numOfBlock <= blockCount + 1)
            {
                numOfBlock += blockSize;
            }
        }
        sum /= kernel.Length;
        result[index - beginning] = sum;
        sum = 0;
        numOfBlock = 0;
    }
    return result;
}

/*static int[] Task3(int[] img)
{
    int[] kernel = new int[] { 1, 2, 3, 4 };
    int imgwidth = (int) Math.Sqrt(img.Length);
    int kernelwidth = (int) Math.Sqrt(kernel.Length);
    var result = new int[(img.Length / imgwidth - (kernel.Length / kernelwidth - 1)) * (img.Length / imgwidth - (kernel.Length / kernelwidth - 1))];
    for (int index = imgwidth; index < img.Length - imgwidth; index++)
    {
        for (int x = kernelwidth; x < kernel.Length - 1; x++)
        {
            result[index - (img.Length - result.Length - kernelwidth)] =
            (img[index - imgwidth] * kernel[x - kernelwidth] + img[index - 1 + kernelwidth] * kernel[x] + img[index + 1 + kernelwidth] * kernel[x + 1]) / kernel.Length;
        }
    }
    return result;
}*///Не доделал






