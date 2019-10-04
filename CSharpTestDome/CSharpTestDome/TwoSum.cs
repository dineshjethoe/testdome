/*
    Write a function that, when passed a list and a target sum, returns, 
        efficiently with respect to time used, two distinct zero-based indices of any two of the numbers, 
        whose sum is equal to the target sum. 
        If there are no two numbers, the function should return null.

    For example, FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10) should return a Tuple<int, int> containing any of the following pairs of indices:
    0 and 3 (or 3 and 0) as 3 + 7 = 10
    1 and 5 (or 5 and 1) as 1 + 9 = 10
    2 and 4 (or 4 and 2) as 5 + 5 = 10
*/

using System;
using System.Collections.Generic;

class TwoSum
{
    public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
    {
        if (list == null || list.Count < 2 || sum < 1) return null;

        var indexMap = new Dictionary<int, int>();

        for (int i = 0; i < list.Count; i++)
        {
            var secondOperand = sum - list[i]; //first iteration: 10 - 3 = 7, so 7 is the second operand's value and 3 is the value in the array with index 0 (I = 0)
            if (indexMap.ContainsKey(secondOperand))
            {
                // in case the second operand is already found then return it to the caller
                return new Tuple<int, int>(i, indexMap[secondOperand]);
            }

            // map values to indices: e.g. (first iteration: index = 0 and value = 3)
            indexMap[list[i]] = i;
        }

        //none found
        return null;
    }

    public static void Main(string[] args)
    {
        var indices = FindTwoSum(new List<int>() { 3, 1, 5, 7, 5, 9 }, 10);
        if (indices != null)
        {
            Console.WriteLine(indices.Item1 + " " + indices.Item2); //will be printed 3 0 on console, this is the first combination/pair
        }
    }
}