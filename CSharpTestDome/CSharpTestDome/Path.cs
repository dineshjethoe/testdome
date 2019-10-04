/*
    Write a function that provides change directory (cd) function for an abstract file system.

    Notes:
    Root path is '/'.
    Path separator is '/'.
    Parent directory is addressable as "..".
    Directory names consist only of English alphabet letters (A-Z and a-z).
    The function should support both relative and absolute paths.
    The function will not be passed any invalid paths.
    Do not use built-in path-related functions.

    For example:
    Path path = new Path("/a/b/c/d");
    path.Cd("../x");
    Console.WriteLine(path.CurrentPath);
    should display '/a/b/c/x'. 
*/

using System;
using System.Collections.Generic;

public class Path
{
    public string CurrentPath { get; private set; }

    public Path(string path)
    {
        this.CurrentPath = path;
    }

    public void Cd(string newPath)
    {
        if (newPath.StartsWith("/"))
        {
            CurrentPath = newPath;
        }
        else if (newPath.Contains(".."))
        {
            var pathList = new LinkedList<string>(CurrentPath.Split('/')); // will get 5 elements, the first element is empty string
            var newPathList = newPath.Split('/'); // will get two elements namely '..' and 'x'
            foreach (var item in newPathList)
            {
                if (item == "..") // go one step back, so remove the last folder
                {
                    if (pathList.Count > 0)
                        pathList.RemoveLast();
                }
                else
                {
                    // 'd' will be replaced by 'x', 'd' was the last element which was removed in the first iteration, 
                    // now 'x' is added as the last element
                    pathList.AddLast(item);
                }
            }

            CurrentPath = string.Join("/", pathList); // set all items in the list to one string delimited by '/' ("/a/b/c/x")
            if (!CurrentPath.StartsWith("/"))
                CurrentPath = "/" + CurrentPath; // if the string does not start with '/' then add a '/' in the beginning of the string
        }
        else
        {
            CurrentPath += "/" + newPath;
        }
    }

    public static void Main(string[] args)
    {
        var path = new Path("/a/b/c/d");
        path.Cd("../x");
        Console.WriteLine(path.CurrentPath); // result is "/a/b/c/x", if path.Cd("../../x") then result will be "/a/b/x"
    }
}