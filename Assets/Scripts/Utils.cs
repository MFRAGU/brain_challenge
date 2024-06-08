
using System;
using System.Collections.Generic;

public class Utils
{
   public static string[] stringToArray(char separator, string str)
    {
        return str.Split(separator);
    }

    public static void Shuffle<T>(List<T> list)
    {
        Random rand = new();
        int sizeList = list.Count;
        for (int i = 0; i < sizeList; i++)
        {
            int j = i + rand.Next(sizeList - i);
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
