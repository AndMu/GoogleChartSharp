using System;
using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    internal class ChartData
    {
        public static string Encode(int[] data)
        {
            var maxValue = FindMaxValue(data);
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }

            if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        public static string Encode(ICollection<int[]> data)
        {
            var maxValue = FindMaxValue(data);
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }

            if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        public static string Encode(float[] data)
        {
            return TextEncoding(data);
        }

        public static string Encode(ICollection<float[]> data)
        {
            return TextEncoding(data);
        }

        public static string Encode(long[] data)
        {
            return TextEncoding(data);
        }

        public static string Encode(ICollection<long[]> data)
        {
            return TextEncoding(data);
        }

        public static string SimpleEncoding(int[] data)
        {
            return "chd=s:" + SimpleEncode(data);
        }

        public static string SimpleEncoding(ICollection<int[]> data)
        {
            var chartData = "chd=s:";

            foreach (var objectArray in data)
            {
                chartData += SimpleEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string SimpleEncode(int[] data)
        {
            var simpleEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var chartData = string.Empty;

            foreach (var value in data)
            {
                if (value == -1)
                {
                    chartData += "_";
                }
                else
                {
                    var c = simpleEncoding[value];
                    chartData += c.ToString();
                }
            }

            return chartData;
        }

        public static string TextEncoding(float[] data)
        {
            return "chd=t:" + TextEncode(data);
        }

        public static string TextEncoding(ICollection<float[]> data)
        {
            var chartData = "chd=t:";

            foreach (var objectArray in data)
            {
                chartData += TextEncode(objectArray) + "|";
            }

            return chartData.TrimEnd("|".ToCharArray());
        }

        private static string TextEncode(float[] data)
        {
            var chartData = string.Empty;

            foreach (var value in data)
            {
                if (value == -1)
                {
                    chartData += "-1,";
                }
                else
                {
                    chartData += value.ToString("F") + ",";
                }
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        public static string TextEncoding(long[] data)
        {
            return "chd=t:" + TextEncode(data);
        }

        public static string TextEncoding(ICollection<long[]> data)
        {
            var chartData = "chd=t:";

            foreach (var objectArray in data)
            {
                chartData += TextEncode(objectArray) + "|";
            }

            return chartData.TrimEnd("|".ToCharArray());
        }

        private static string TextEncode(long[] data)
        {
            var chartData = string.Empty;

            foreach (var value in data)
            {
                if (value == -1)
                {
                    chartData += "-1,";
                }
                else
                {
                    chartData += value + ",";
                }
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        public static string ExtendedEncoding(int[] data)
        {
            return "chd=e:" + ExtendedEncode(data);
        }

        public static string ExtendedEncoding(ICollection<int[]> data)
        {
            var chartData = "chd=e:";

            foreach (var objectArray in data)
            {
                chartData += ExtendedEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string ExtendedEncode(int[] data)
        {
            var extendedEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            var chartData = string.Empty;

            foreach (var value in data)
            {
                if (value == -1)
                {
                    chartData += "__";
                }
                else
                {
                    var firstCharPos = Convert.ToInt32(Math.Floor((double)(value / extendedEncoding.Length)));
                    var secondCharPos = Convert.ToInt32(Math.Floor((double)(value % extendedEncoding.Length)));

                    chartData += extendedEncoding[firstCharPos];
                    chartData += extendedEncoding[secondCharPos];
                }
            }

            return chartData;
        }

        private static int FindMaxValue(int[] data)
        {
            var maxValue = -1;
            foreach (var value in data)
            {
                if (value > maxValue)
                {
                    maxValue = value;
                }
            }

            return maxValue;
        }

        private static int FindMaxValue(ICollection<int[]> data)
        {
            var maxValuesList = new List<int>();

            foreach (var objectArray in data)
            {
                maxValuesList.Add(FindMaxValue(objectArray));
            }

            var maxValues = maxValuesList.ToArray();
            Array.Sort(maxValues);
            return maxValues[maxValues.Length - 1];
        }
    }
}