# Bankers-algorithm
An interactive C# console application that simulates **Dijkstra's Banker's Algorithm** for deadlock avoidance in operating systems. The program determines whether a system is in a **Safe State** based on user-defined resource allocations and maximum process claims, outputting a valid execution sequence if one exists.

---

## How It Works

The program manages system safety by tracking three primary metrics across all active processes:
1. **Allocation Matrix:** The number of resources of each type currently held by each process.
2. **Claim (Max) Matrix:** The maximum resource limit a process can request during execution.
3. **Need Matrix:** Automatically calculated as `Claim - Allocation` to show remaining requirements.

When executed, the system runs a **Safety Algorithm Simulation**. It checks if there is a path where every process can claim its maximum need, run to completion, and return its held resources back to the available pool without causing a deadlock.

---

## How to Operate the Program

When you run the application, it will guide you through a series of interactive terminal prompts. Follow these steps to input your data:

### Step 1: Initialize System Dimensions
* **Enter number of processes:** Type an integer (e.g., `5`) and press Enter.
* **Enter number of resources:** Type an integer (e.g., `3`) representing resource types like R0, R1, R2.

### Step 2: Fill the Matrices
* **Allocation Matrix:** For each process, enter the current number of resource units it holds.
* **Claim Matrix:** For each process, enter the maximum resource units it will ever need at one time.

### Step 3: Input Total Resources
* **Total Resources:** Enter the absolute total capacity of your hardware/system for each resource type. 
* *Note: The application automatically subtracts all currently allocated resources from this Total to determine the `Available` resource vector.*

### Step 4: View the Evaluation Result
* **Safe State:** If the system is safe, the console text turns **green** and outputs a valid execution sequence (e.g., `Safe Sequence -> P1 -> P3 -> P4 -> P0 -> P2`).
* **Unsafe State:** If the system risks a deadlock, the console text turns **red** and displays a warning that the system is not safe.

   dotnet run
   ```
