/*
    A playlist is considered a repeating playlist if any of the songs contain a reference to a previous song in the playlist.
    Otherwise, the playlist will end with the last song which points to null.

    Implement a function IsRepeatingPlaylist that, efficiently with respect to time used, 
        returns true if a playlist is repeating or false if it is not.

    For example, the following code prints "True" as both songs point to each other.
 */

using System;

public class Song
{
    private readonly string name; // made 'readonly' since this field is initialized in the constructor only
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsRepeatingPlaylist()
    {
        var slow = NextSong; // object 'slow' points to "second = new Song("Eye of the tiger")"

        //null propagation operator (?.) is used to check whether object 'slow' is null or not
        var fast = slow?.NextSong; // object 'fast' points to "var first = new Song("Hello")"

        while (fast != null)
        {
            if (slow == this || slow == fast) // first iteration will be false, second iteration 'slow' and 'fast' will have "Hello" as value in their name field
                return true;

            //swapping the objects: slow becomes fast and fast becomes slow
            slow = slow.NextSong; //becomes "hello"
            fast = fast.NextSong; //becomes "Eye of the tiger"

            if (fast != null)
                fast = fast.NextSong; // fast's name value is now "hello"
        }

        return false;
    }

    public static void Main(string[] args)
    {
        var first = new Song("Hello");
        var second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}