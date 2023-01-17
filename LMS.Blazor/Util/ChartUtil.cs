using System;
using System.Collections.Generic;
using System.Drawing;

namespace LMS.Blazor.Util
{
    public class ChartUtil
    {
        private static Random rnd = new Random();
        public static string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public static int RandomScalingFactor()
        {
            return rnd.Next() * 70;
        }

        public static List<int> RandomScalingFactor(int count)
        {
            var nums = new List<int>();
            Random rnd = new Random();
            return nums;
        }

        public static Color GetRandomColor()
        {
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}