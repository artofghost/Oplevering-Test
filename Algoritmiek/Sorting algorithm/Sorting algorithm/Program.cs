using System;

class MyProgram
{
    
    
     static void countingsort(int[] Array)
    {
        int n = Array.Length;
        int max = 0;
        //hier zoek ik de grootste int in de array
        for (int i = 0; i < n; i++)
        {
            if (max < Array[i])
            {
                max = Array[i];
            }
        }

        // hier maak ik een array waar de nieuwe array aan waar alles 0 is
        int[] freq = new int[max + 1];
        for (int i = 0; i < max + 1; i++)
        {
            freq[i] = 0;
        }
        for (int i = 0; i < n; i++)
        {
            freq[Array[i]]++;
        }

        //hier sorteer ik de oude array in de nieuwe array
        for (int i = 0, j = 0; i <= max; i++)
        {
            while (freq[i] > 0)
            {
                Array[j] = i;
                j++;
                freq[i]--;
            }
        }
    }

    
     static void PrintArray(int[] Array)
    {
        int n = Array.Length;
        for (int i = 0; i < n; i++)
            Console.Write(Array[i] + " ");
        Console.Write("\n");
    }
    
   
     static void Main(string[] args)
    {
        int MaxArrayLength = 10;
        int Min = 0;
        int Max = 10;

       
        int[] test2 = new int[MaxArrayLength];

        Random randNum = new Random();
        for (int i = 0; i < test2.Length; i++)
        {
            test2[i] = randNum.Next(Min, Max);
        }
        Console.Write("Random created array\n");
        PrintArray(test2);

        int[] MyArray = test2;
       
           
        Console.Write("Original Array\n");
        PrintArray(MyArray);

        countingsort(MyArray);
        Console.Write("\nSorted Array\n");
        Console.Write($"this is the ammount of numbers: {MaxArrayLength}\n");

        PrintArray(MyArray);
    }
}