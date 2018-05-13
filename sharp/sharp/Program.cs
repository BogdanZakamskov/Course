using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sharp
{
    class Program
    {
        static bool Validation(int i, int j, ref int[,] arr, ref int count)
        {
            if (i == j)
            {
                for(int k = 0; k < count - 1; k++)
                {
                    if(arr[k, k] == -1 || arr[k, k] != arr[k + 1, k + 1])
                        break;
                    if (k == count - 2 && arr[k, k] == arr[k + 1, k + 1])
                        return true;
                }
            }
            if(i == count - 1 - j)
            {
                for (int k = 0; k < count - 1; k++)
                {
                    if (arr[k, count - 1 - k] == -1 || arr[k, count - 1 - k] != arr[k + 1, count - 2 - k])
                        break;
                    if (k == count - 2 && arr[k, count - 1 - k] == arr[k + 1, count - 2 - k])
                        return true;
                }
            }
            for (int k = 0; k < count - 1; k++)
            {
                if (arr[k, j] == -1 || arr[k, j] != arr[k + 1, j])
                    break;
                if (k == count - 2 && arr[k, j] == arr[k + 1, j])
                    return true;
            }
            for (int k = 0; k < count - 1; k++)
            {
                if (arr[i, k] == -1 || arr[i, k] != arr[i, k + 1])
                    break;
                if (k == count - 2 && arr[i, k] == arr[i, k + 1])
                    return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            System.Console.Write("Введите размер матрицы: ");
            int n = int.Parse(System.Console.ReadLine());
            int[,] array = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    array[i, j] = -1;
                }
            }
            System.Console.WriteLine("Вводите по 2 индекса в каждой строке, пока условие не выполниться");
            int odd = 0;
            while (true)
            {
                string str = System.Console.ReadLine();
                string[] index = str.Split(' ');
                if (index.Length != 2)
                {
                    System.Console.WriteLine("Неверное количество индексов! Попробуй еще раз.");
                    continue;
                }
                int indexI = int.Parse(index[0]);
                int indexJ = int.Parse(index[1]);
                if (indexI >= n || indexJ >= n)
                {
                    System.Console.WriteLine("Клетка за пределами матрицы! Попробуй еще раз.");
                    continue;
                }
                if (array[indexI, indexJ] != -1)
                {
                    System.Console.WriteLine("Клетка уже занята! Попробуй еще раз.");
                    continue;
                }
                array[int.Parse(index[0]), int.Parse(index[1])] = odd % 2;
                if (Validation(indexI, indexJ, ref array, ref n))
                {
                    System.Console.WriteLine("Найдена линия одинаковых значений.");
                    break;
                }
                if (odd == n * n)
                {
                    System.Console.WriteLine("Матрица полностью заполнена.");
                    break;
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        System.Console.Write(array[i,j] + " ");
                    }
                    System.Console.Write("\n");
                }
                odd++;
            }
            System.Console.WriteLine("Программа завершена");
            System.Console.ReadKey();
        }
    }
}
