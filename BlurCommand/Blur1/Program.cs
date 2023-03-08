using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
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

static void Print2DArray(int[] input, int width)
{
    for (int i = 1; i <= input.Length; i++)
    {
        if (i % width != 0)
        {
            if (input[i] <= 10)
            {
                Console.Write(input[i - 1] + "   ");
            }
            else
            {
                Console.Write(input[i - 1] + "  ");
            }
        }
        else
        {
            Console.Write(input[i - 1] + "\n");
        }
    }
    Console.WriteLine();
}

/*var result11 = TestArray(5);
PrintArray(result11);*/

/*var task1Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var result1 = Task1(task1Input);
Console.Write("TASK 1:\nInput:\n");
PrintArray(task1Input);
Console.WriteLine("Result:");
PrintArray(result1);

var task1ImprovedInput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
var result1Improved = Task1Improved(task1ImprovedInput);
Console.Write("TASK 1 with img size:\nInput:\n");
PrintArray(task1ImprovedInput);
Console.WriteLine("Result:");
PrintArray(result1Improved);

var task2Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
var result2 = Task2(task2Input, 2);
Console.Write("TASK 2:\nInput:\n");
PrintArray(task2Input);
Console.WriteLine("Result:");
PrintArray(result2);

var task2ImprovedInput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
var result2Improved = Task2Improved(task2ImprovedInput, 2);
Console.Write("TASK 2 with img size:\nInput:\n");
PrintArray(task2ImprovedInput);
Console.WriteLine("Result:");
PrintArray(result2Improved);*/

var task3Input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 };
int[] task3kernel = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
int kernelwidth = (int)Math.Sqrt(task3kernel.Length);
int imgwidth = 4;
var result3 = Task3(task3Input, task3kernel, kernelwidth, imgwidth);
Console.Write("TASK 3:\nInput:\n");
Print2DArray(task3Input, imgwidth);
Console.WriteLine("Result:");
Print2DArray(result3, imgwidth);

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
/*static int[] Task1(int[] img)
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
    int[] kernel = new int[] {1, 2, 3, 4, 5 };
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

//Одномерный вариант c блоками с размером картинки
static int[] Task2Improved(int[] img, int blockSize)
{
    int[] kernel = new int[] { 1, 2, 3, 4, 5, 6, 7 };
    int[] result = new int[img.Length];
    int difference = (img.Length - (img.Length - kernel.Length * blockSize + blockSize)) / 2;
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
    int blockCount = img.Length / blockSize;
    int numOfBlock = 0;
    for (int index = beginning; index < (img.Length - kernel.Length * blockSize + blockSize) + beginning; index++)
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
        result[index - beginning + difference] = sum;
        sum = 0;
        numOfBlock = 0;
    }
    return result;
}*/


//Двумерный вариант без блоков с размером картинки
static int[] Task3(int[] img, int[] kernel, int kernelwidth, int imgwidth)
{
    if (kernel.Length % 2 == 0 || kernel.Length < 9 || kernelwidth * kernelwidth != kernel.Length)
    {
        return Array.Empty<int>();
    }
    else
    {
        var result = new int[img.Length];
        int difference = imgwidth - kernelwidth;
        int sum = 0;
        int imgIndex = 0;
        int kernelIndex = 0;
        int beginningIndex = 0;
        int resultlength = (img.Length / imgwidth - (kernel.Length / kernelwidth - 1)) *
                           (img.Length / imgwidth - (kernel.Length / kernelwidth - 1));
        int startend = img.Length / 2 - resultlength / 2;
        for (int start = 0; start < startend; start++)
        {
            result[start] = img[start];
        }

        for (int end = img.Length - startend; end < result.Length; end++)
        {
            result[end] = img[end];
        }

        for (int resultIndex = 0; resultIndex < resultlength; resultIndex++)
        {
            for (int count = 0; count < kernelwidth; count++)
            {
                for (int i = 0; i < kernelwidth - 1; i++)
                {
                    sum += img[imgIndex] * kernel[kernelIndex];
                    imgIndex++;
                    kernelIndex++;
                }

                if (count != kernelwidth - 1)
                {
                    sum += img[imgIndex] * kernel[kernelIndex];
                    imgIndex += difference + 1;
                    kernelIndex++;
                }
            }

            sum += img[imgIndex] * kernel[kernelIndex];
            sum /= kernel.Length;
            result[resultIndex + startend] = sum;
            sum = 0;
            kernelIndex = 0;
            if ((beginningIndex + difference + 1) % imgwidth == 0)
            {
                imgIndex = 0;
                imgIndex += beginningIndex + kernelwidth;
                beginningIndex++;
            }
            else
            {
                imgIndex = 0;
                beginningIndex++;
                imgIndex += beginningIndex;
            }
        }
        return result;
    }
}






