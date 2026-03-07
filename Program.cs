using System;
using IcalDemo;
var parser = new IcalParser();
var events = parser.Parse("sample.ics");

foreach (var e in events)
{
    Console.WriteLine($"Event: {e.Summary}");
    Console.WriteLine($"Start: {e.Start}");
    Console.WriteLine($"End: {e.End}");
    Console.WriteLine();
}