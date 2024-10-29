using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

public static class EditString
{
    public static string RemovePunctuation(string input) =>
          Regex.Replace(input, @"[,.:;!?-]", "");

    public static string ToUpperCase(string input) =>
        input.ToUpper();

    public static string ToLowerCase(string input) =>
        input.ToLower();

    public static string RemoveSpaces(string input) =>
        Regex.Replace(input, @"(\s)+", " ");

    public static string AddExclamation(string input) =>
        input.Insert(input.Length, "!!!");
}