using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankers_Algorithm
{
    internal class Program
    {
        static int[,] Allocation;
        static int[,] Claim;
        static int[,] Need;
        static int[] Available;
        static int processCount;
        static int resourceCount;
        static void Main(string[] args)
        {
            Console.Write("Enter number of processes: ");
            processCount = int.Parse(Console.ReadLine());
            Console.Write("Enter number of resources: ");
            resourceCount = int.Parse(Console.ReadLine());

            Console.WriteLine("****************************************");

            Allocation = new int[processCount, resourceCount];
            Claim = new int[processCount, resourceCount];
            Need = new int[processCount, resourceCount];
            Available = new int[resourceCount];

            Console.WriteLine("Enter Allocation matrix:");
            for (int i = 0; i < processCount; i++)
            {
                Console.WriteLine($"Process {i}:");
                for (int j = 0; j < resourceCount; j++)
                {
                    Console.Write($"R{j}: ");
                    Allocation[i, j] = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("****************************************");

            Console.WriteLine("Enter Claim matrix:");
            for (int i = 0; i < processCount; i++)
            {
                Console.WriteLine($"Process {i}:");
                for (int j = 0; j < resourceCount; j++)
                {
                    Console.Write($"R{j}: ");
                    Claim[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("****************************************");

            Console.WriteLine("Enter Total resources:");
            int[] TotalResources = new int[resourceCount];
            for (int i = 0; i < resourceCount; i++)
            {
                Console.Write($"R{i}: ");
                TotalResources[i] = int.Parse(Console.ReadLine());
            }

            for (int i = 0; i < resourceCount; i++)
            {
                int allocatedSum = 0;
                for (int j = 0; j < processCount; j++)
                {
                    allocatedSum += Allocation[j, i];
                }
                Available[i] = TotalResources[i] - allocatedSum;
            }

            for (int i = 0; i < processCount; i++)
            {
                for (int j = 0; j < resourceCount; j++)
                {
                    Need[i, j] = Claim[i, j] - Allocation[i, j];
                }
            }

            Console.WriteLine("****************************************");

            if (isSafeState())
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("The system is in a safe state.");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The system is NOT in a safe state.");
                Console.ResetColor();
            }
            Console.ReadKey();
        }

        static bool isSafeState()
        {
            bool[] Finish = new bool[processCount];
            int[] Work = new int[resourceCount];
            Array.Copy(Available, Work, resourceCount);

            int[] SafeSequence = new int[processCount];
            int index = 0;

            while (index < processCount)
            {
                bool found = false;

                for (int i = 0; i < processCount; i++)
                {
                    if (!Finish[i])
                    {
                        bool canAllocate = true;

                        for (int j = 0; j < resourceCount; j++)
                        {
                            if (Need[i, j] > Work[j])
                            {
                                canAllocate = false;
                                break;
                            }
                        }

                        if (canAllocate)
                        {
                            for (int j = 0; j < resourceCount; j++)
                            {
                                Work[j] += Allocation[i, j];
                            }

                            SafeSequence[index++] = i;
                            Finish[i] = true;
                            found = true;

                        }
                    }
                }

                if (!found)
                {
                    return false;
                }
            }

            Console.Write("Safe Sequence");
            foreach (int process in SafeSequence)
            {
                Console.Write($" -> P{process}");
            }
            Console.WriteLine();
            return true;
        }
    }
}