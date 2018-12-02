using System;
using System.Collections.Generic;

namespace Wikiled.Google.Chart
{
    internal class ChartData
    {
        public static string Encode(int[] data)
        {
            int maxValue = FindMaxValue(data);
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }
            else if (maxValue <= 4095)
            {
                return ExtendedEncoding(data);
            }

            return null;
        }

        public static string Encode(ICollection<int[]> data)
        {
            int maxValue = FindMaxValue(data);
            if (maxValue <= 61)
            {
                return SimpleEncoding(data);
            }
            else if (maxValue <= 4095)
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
            string chartData = "chd=s:";

            foreach (int[] objectArray in data)
            {
                chartData += SimpleEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string SimpleEncode(int[] data)
        {
            string simpleEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    chartData += "_";
                }
                else
                {
                    char c = simpleEncoding[value];
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
            string chartData = "chd=t:";

            foreach (float[] objectArray in data)
            {
				chartData += TextEncode (objectArray) + "|";
            }

            return chartData.TrimEnd("|".ToCharArray());
        }

        private static string TextEncode(float[] data)
        {
            string chartData = string.Empty;

            foreach (float value in data)
            {
                if (value == -1)
                {
                    chartData += "-1,";
                }
                else
                {
					chartData += value.ToString ("F") + ",";
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
			string chartData = "chd=t:";

			foreach (long[] objectArray in data)
			{
				chartData += TextEncode (objectArray) + "|";
			}

			return chartData.TrimEnd("|".ToCharArray());
		}

		private static string TextEncode(long[] data)
		{
			string chartData = string.Empty;

			foreach (long value in data)
			{
				if (value == -1)
				{
					chartData += "-1,";
				}
				else
				{
					chartData += value.ToString () + ",";
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
            string chartData = "chd=e:";

            foreach (int[] objectArray in data)
            {
                chartData += ExtendedEncode(objectArray) + ",";
            }

            return chartData.TrimEnd(",".ToCharArray());
        }

        private static string ExtendedEncode(int[] data)
        {
            string extendedEncoding = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-.";
            string chartData = string.Empty;

            foreach (int value in data)
            {
                if (value == -1)
                {
                    chartData += "__";
                }
                else
                {
                    int firstCharPos = Convert.ToInt32(Math.Floor((double)(value / extendedEncoding.Length)));
                    int secondCharPos = Convert.ToInt32(Math.Floor((double)(value % extendedEncoding.Length)));

                    chartData += extendedEncoding[firstCharPos];
                    chartData += extendedEncoding[secondCharPos];
                }
            }

            return chartData;
        }

        private static int FindMaxValue(int[] data)
        {
            int maxValue = -1;
            foreach (int value in data)
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
            List<int> maxValuesList = new List<int>();

            foreach (int[] objectArray in data)
            {
                maxValuesList.Add(FindMaxValue(objectArray));
            }

            int[] maxValues = maxValuesList.ToArray();
            Array.Sort(maxValues);
            return maxValues[maxValues.Length - 1];
        }
    }
}
