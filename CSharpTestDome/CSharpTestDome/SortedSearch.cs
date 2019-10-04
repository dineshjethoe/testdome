/*
    Implement function CountNumbers that accepts a sorted array of unique integers and, 
        efficiently with respect to time used, 
        counts the number of array elements that are less than the parameter lessThan.

    For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2 because there are two array elements less than 4. 
*/

using System;

public class SortedSearch
{
    // Runs recursively
    private static int FindMid(int[] sortedArray, int left, int right, int lessThan)
    {
        var middle = left + (right - left) / 2; // = 0 + 1.5, since it's of type integer it will be 1

        if (sortedArray[middle] == lessThan) // 3 < 4
        {
            // If duplicates are present it returns the position of the first element
            while (middle - 1 > 0 && sortedArray[middle - 1] == lessThan) --middle;

            return middle;
        }

        if (middle <= left)
        {
            // It happens if lessThan is not present in the array
            while (middle <= right && sortedArray[middle] < lessThan) ++middle;

            return middle;
        }

        if (sortedArray[middle] < lessThan)
        {
            left = middle;  // ignore left half
        }
        else
        {
            right = middle;  // ignore right half
        }

        return FindMid(sortedArray, left, right, lessThan);
    }

    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        var left = 0;
        var right = sortedArray.Length - 1; // = 3

        return FindMid(sortedArray, left, right, lessThan);
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(CountNumbers(new int[] { 1, 3, 5, 7 }, 4)); // the first two indices are less than 4, so result will be 2
    }
}