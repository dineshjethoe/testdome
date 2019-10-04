/*
    Each account on a website has a set of access flags that represent a users access.

    Update and extend the enum so that it contains three new access flags:

    A Writer access flag that is made up of the Submit and Modify flags.
    An Editor access flag that is made up of the Delete, Publish and Comment flags.
    An Owner access that is made up of the Writer and Editor flags.
    For example, the code below should print "False" as the Writer flag does not contain the Delete flag.

    Console.WriteLine(Access.Writer.HasFlag(Access.Delete)) 
*/

using System;

public class Account
{
    [Flags]
    public enum Access
    {
        None = 0, // for explanation check → https://stackoverflow.com/questions/8447/what-does-the-flags-enum-attribute-mean-in-c
        Delete = 1,
        Publish = 2,
        Submit = 4,
        Comment = 8,
        Modify = 16,
        Writer = Submit | Modify,
        Editor = Delete | Publish | Comment,
        Owner = Writer | Editor
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(Access.Writer.HasFlag(Access.Delete)); //Should print: "False"
    }
}