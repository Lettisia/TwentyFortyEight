using System;
using System.Collections.Generic;
using System.Text;

namespace TwentyFortyEight
{
    public static class ExtensionMethods
    {
        
        public static string PrintAsString(this int[,] array)
        {
            var sb = new StringBuilder();
            for (var i = 0; i < array.GetLength(0); i++)
            {
                sb.Append("{ ");
                for (var j = 0; j < array.GetLength(0); j++)
                {
                    sb.Append(array[i, j] + " ");
                }
                sb.AppendLine("} ");
            }
            sb.AppendLine();
            return sb.ToString();
        }
    }
}
