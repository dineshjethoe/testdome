/*
    Implement a function FolderNames, which accepts a string containing an XML file that specifies folder structure and returns all folder names that start with startingLetter. The XML format is given in the example below.

    For example, for the letter 'u' and XML file:

    <?xml version="1.0" encoding="UTF-8"?>
    <folder name="c">
        <folder name="program files">
            <folder name="uninstall information" />
        </folder>
        <folder name="users" />
    </folder>
    the function should return "uninstall information" and "users" (in any order). 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

public class Folders
{
    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        var doc = XDocument.Parse(xml);
        var names = from p in doc.Descendants("folder")
                    where ((string)p.Attribute("name")).StartsWith(startingLetter.ToString())
                    select (string)p.Attribute("name");
        foreach (string s in names)
        {
            yield return s;
        }
    }

    public static void Main(string[] args)
    {
        string xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<folder name=\"c\">" +
                "<folder name=\"program files\">" +
                    "<folder name=\"uninstall information\" />" +
                "</folder>" +
                "<folder name=\"users\" />" +
            "</folder>";

        //foreach (string name in FolderNames(xml, 'u')) Console.WriteLine(name);
        // OR ↓
        FolderNames(xml, 'u').ToList().ForEach(n => Console.WriteLine(n));
    }
}