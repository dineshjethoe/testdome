/*
    Implement the UniqueNames method. 
    When passed two arrays of names, it will return an array containing the names that appear in either or both arrays.
    The returned array should have no duplicates.

    For example, calling MergeNames.UniqueNames(new string[]{'Ava', 'Emma', 'Olivia'}, new string[]{'Olivia', 'Sophia', 'Emma'}) 
        should return an array containing Ava, Emma, Olivia, and Sophia in any order.
 */

using System;
using System.Collections.Generic;
using System.Linq;

public class MergeNames
{
    public static string[] UniqueNames(string[] names1, string[] names2)
    {
        var list = new List<string>();
        list.AddRange(names1);
        list.AddRange(names2);

        return list
                .Distinct() //The returned array should have no duplicates.
                .ToArray(); //should return an array
    }

    public static void Main(string[] args)
    {
        var names1 = new string[] { "Ava", "Emma", "Olivia" };
        var names2 = new string[] { "Olivia", "Sophia", "Emma" };
        Console.WriteLine(string.Join(", ", UniqueNames(names1, names2))); // should print Ava, Emma, Olivia, Sophia
    }
}