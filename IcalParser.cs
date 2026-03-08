using System;
using System.Collections.Generic;
using System.IO;

namespace IcalDemo
{
    public class IcalParser
    {
        public List<Event> Parse(string filePath)
        {
            var events = new List<Event>();
            Event current = null;

            // Здесь просматриваются каждые строки и по началу определяется, какой это отсек файла
            foreach (var line in File.ReadLines(filePath))
            {
                if (line.StartsWith("BEGIN:VEVENT"))
                    current = new Event();

                else if (line.StartsWith("SUMMARY:"))
                    current.Summary = line.Replace("SUMMARY:", "");

                else if (line.StartsWith("DTSTART:"))
                    current.Start = ParseDate(line.Replace("DTSTART:", ""));

                else if (line.StartsWith("DTEND:"))
                    current.End = ParseDate(line.Replace("DTEND:", ""));

                else if (line.StartsWith("END:VEVENT"))
                    events.Add(current);
            }

            return events;
        }

        private DateTime ParseDate(string value)
        {
            return DateTime.ParseExact(value, "yyyyMMdd'T'HHmmss", null);
        }
    }
}
