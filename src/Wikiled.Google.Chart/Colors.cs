using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;

namespace Wikiled.Google.Chart
{
    public static class Colors
    {
        public static Color AliceBlue { get; } = new Color("AliceBlue", "F0F8FF");

        public static Color AntiqueWhite { get; } = new Color("AntiqueWhite", "FAEBD7");

        public static Color Aqua { get; } = new Color("Aqua", "00FFFF");

        public static Color Aquamarine { get; } = new Color("Aquamarine", "7FFFD4");

        public static Color Azure { get; } = new Color("Azure", "F0FFFF");

        public static Color Beige { get; } = new Color("Beige", "F5F5DC");

        public static Color Bisque { get; } = new Color("Bisque", "FFE4C4");

        public static Color Black { get; } = new Color("Black", "000000");

        public static Color BlanchedAlmond { get; } = new Color("BlanchedAlmond", "FFEBCD");

        public static Color Blue { get; } = new Color("Blue", "0000FF");

        public static Color BlueViolet { get; } = new Color("BlueViolet", "8A2BE2");

        public static Color Brown { get; } = new Color("Brown", "A52A2A");

        public static Color BurlyWood { get; } = new Color("BurlyWood", "DEB887");

        public static Color CadetBlue { get; } = new Color("CadetBlue", "5F9EA0");

        public static Color Chartreuse { get; } = new Color("Chartreuse", "7FFF00");

        public static Color Chocolate { get; } = new Color("Chocolate", "D2691E");

        public static Color Coral { get; } = new Color("Coral", "FF7F50");

        public static Color CornflowerBlue { get; } = new Color("CornflowerBlue", "6495ED");

        public static Color Cornsilk { get; } = new Color("Cornsilk", "FFF8DC");

        public static Color Crimson { get; } = new Color("Crimson", "DC143C");

        public static Color Cyan { get; } = new Color("Cyan", "00FFFF");

        public static Color DarkBlue { get; } = new Color("DarkBlue", "00008B");

        public static Color DarkCyan { get; } = new Color("DarkCyan", "008B8B");

        public static Color DarkGoldenrod { get; } = new Color("DarkGoldenrod", "B8860B");

        public static Color DarkGray { get; } = new Color("DarkGray", "A9A9A9");

        public static Color DarkGreen { get; } = new Color("DarkGreen", "006400");

        public static Color DarkKhaki { get; } = new Color("DarkKhaki", "BDB76B");

        public static Color DarkMagenta { get; } = new Color("DarkMagenta", "8B008B");

        public static Color DarkOliveGreen { get; } = new Color("DarkOliveGreen", "556B2F");

        public static Color DarkOrange { get; } = new Color("DarkOrange", "FF8C00");

        public static Color DarkOrchid { get; } = new Color("DarkOrchid", "9932CC");

        public static Color DarkRed { get; } = new Color("DarkRed", "8B0000");

        public static Color DarkSalmon { get; } = new Color("DarkSalmon", "E9967A");

        public static Color DarkSeaGreen { get; } = new Color("DarkSeaGreen", "8FBC8F");

        public static Color DarkSlateBlue { get; } = new Color("DarkSlateBlue", "483D8B");

        public static Color DarkSlateGray { get; } = new Color("DarkSlateGray", "2F4F4F");

        public static Color DarkTurquoise { get; } = new Color("DarkTurquoise", "00CED1");

        public static Color DarkViolet { get; } = new Color("DarkViolet", "9400D3");

        public static Color DeepPink { get; } = new Color("DeepPink", "FF1493");

        public static Color DeepSkyBlue { get; } = new Color("DeepSkyBlue", "00BFFF");

        public static Color DimGray { get; } = new Color("DimGray", "696969");

        public static Color DodgerBlue { get; } = new Color("DodgerBlue", "1E90FF");

        public static Color Firebrick { get; } = new Color("Firebrick", "B22222");

        public static Color FloralWhite { get; } = new Color("FloralWhite", "FFFAF0");

        public static Color ForestGreen { get; } = new Color("ForestGreen", "228B22");

        public static Color Fuchsia { get; } = new Color("Fuchsia", "FF00FF");

        public static Color Gainsboro { get; } = new Color("Gainsboro", "DCDCDC");

        public static Color GhostWhite { get; } = new Color("GhostWhite", "F8F8FF");

        public static Color Gold { get; } = new Color("Gold", "FFD700");

        public static Color Goldenrod { get; } = new Color("Goldenrod", "DAA520");

        public static Color Gray { get; } = new Color("Gray", "808080");

        public static Color Green { get; } = new Color("Green", "008000");

        public static Color GreenYellow { get; } = new Color("GreenYellow", "ADFF2F");

        public static Color Honeydew { get; } = new Color("Honeydew", "F0FFF0");

        public static Color HotPink { get; } = new Color("HotPink", "FF69B4");

        public static Color IndianRed { get; } = new Color("IndianRed", "CD5C5C");

        public static Color Indigo { get; } = new Color("Indigo", "4B0082");

        public static Color Ivory { get; } = new Color("Ivory", "FFFFF0");

        public static Color Khaki { get; } = new Color("Khaki", "F0E68C");

        public static Color Lavender { get; } = new Color("Lavender", "E6E6FA");

        public static Color LavenderBlush { get; } = new Color("LavenderBlush", "FFF0F5");

        public static Color LawnGreen { get; } = new Color("LawnGreen", "7CFC00");

        public static Color LemonChiffon { get; } = new Color("LemonChiffon", "FFFACD");

        public static Color LightBlue { get; } = new Color("LightBlue", "ADD8E6");

        public static Color LightCoral { get; } = new Color("LightCoral", "F08080");

        public static Color LightCyan { get; } = new Color("LightCyan", "E0FFFF");

        public static Color LightGoldenrodYellow { get; } = new Color("LightGoldenrodYellow", "FAFAD2");

        public static Color LightGray { get; } = new Color("LightGray", "D3D3D3");

        public static Color LightGreen { get; } = new Color("LightGreen", "90EE90");

        public static Color LightPink { get; } = new Color("LightPink", "FFB6C1");

        public static Color LightSalmon { get; } = new Color("LightSalmon", "FFA07A");

        public static Color LightSeaGreen { get; } = new Color("LightSeaGreen", "20B2AA");

        public static Color LightSkyBlue { get; } = new Color("LightSkyBlue", "87CEFA");

        public static Color LightSlateGray { get; } = new Color("LightSlateGray", "778899");

        public static Color LightSteelBlue { get; } = new Color("LightSteelBlue", "B0C4DE");

        public static Color LightYellow { get; } = new Color("LightYellow", "FFFFE0");

        public static Color Lime { get; } = new Color("Lime", "00FF00");

        public static Color LimeGreen { get; } = new Color("LimeGreen", "32CD32");

        public static Color Linen { get; } = new Color("Linen", "FAF0E6");

        public static Color Magenta { get; } = new Color("Magenta", "FF00FF");

        public static Color Maroon { get; } = new Color("Maroon", "800000");

        public static Color MediumAquamarine { get; } = new Color("MediumAquamarine", "66CDAA");

        public static Color MediumBlue { get; } = new Color("MediumBlue", "0000CD");

        public static Color MediumOrchid { get; } = new Color("MediumOrchid", "BA55D3");

        public static Color MediumPurple { get; } = new Color("MediumPurple", "9370DB");

        public static Color MediumSeaGreen { get; } = new Color("MediumSeaGreen", "3CB371");

        public static Color MediumSlateBlue { get; } = new Color("MediumSlateBlue", "7B68EE");

        public static Color MediumSpringGreen { get; } = new Color("MediumSpringGreen", "00FA9A");

        public static Color MediumTurquoise { get; } = new Color("MediumTurquoise", "48D1CC");

        public static Color MediumVioletRed { get; } = new Color("MediumVioletRed", "C71585");

        public static Color MidnightBlue { get; } = new Color("MidnightBlue", "191970");

        public static Color MintCream { get; } = new Color("MintCream", "F5FFFA");

        public static Color MistyRose { get; } = new Color("MistyRose", "FFE4E1");

        public static Color Moccasin { get; } = new Color("Moccasin", "FFE4B5");

        public static Color NavajoWhite { get; } = new Color("NavajoWhite", "FFDEAD");

        public static Color Navy { get; } = new Color("Navy", "000080");

        public static Color OldLace { get; } = new Color("OldLace", "FDF5E6");

        public static Color Olive { get; } = new Color("Olive", "808000");

        public static Color OliveDrab { get; } = new Color("OliveDrab", "6B8E23");

        public static Color Orange { get; } = new Color("Orange", "FFA500");

        public static Color OrangeRed { get; } = new Color("OrangeRed", "FF4500");

        public static Color Orchid { get; } = new Color("Orchid", "DA70D6");

        public static Color PaleGoldenrod { get; } = new Color("PaleGoldenrod", "EEE8AA");

        public static Color PaleGreen { get; } = new Color("PaleGreen", "98FB98");

        public static Color PaleTurquoise { get; } = new Color("PaleTurquoise", "AFEEEE");

        public static Color PaleVioletRed { get; } = new Color("PaleVioletRed", "DB7093");

        public static Color PapayaWhip { get; } = new Color("PapayaWhip", "FFEFD5");

        public static Color PeachPuff { get; } = new Color("PeachPuff", "FFDAB9");

        public static Color Peru { get; } = new Color("Peru", "CD853F");

        public static Color Pink { get; } = new Color("Pink", "FFC0CB");

        public static Color Plum { get; } = new Color("Plum", "DDA0DD");

        public static Color PowderBlue { get; } = new Color("PowderBlue", "B0E0E6");

        public static Color Purple { get; } = new Color("Purple", "800080");

        public static Color Red { get; } = new Color("Red", "FF0000");

        public static Color RosyBrown { get; } = new Color("RosyBrown", "BC8F8F");

        public static Color RoyalBlue { get; } = new Color("RoyalBlue", "4169E1");

        public static Color SaddleBrown { get; } = new Color("SaddleBrown", "8B4513");

        public static Color Salmon { get; } = new Color("Salmon", "FA8072");

        public static Color SandyBrown { get; } = new Color("SandyBrown", "F4A460");

        public static Color SeaGreen { get; } = new Color("SeaGreen", "2E8B57");

        public static Color SeaShell { get; } = new Color("SeaShell", "FFF5EE");

        public static Color Sienna { get; } = new Color("Sienna", "A0522D");

        public static Color Silver { get; } = new Color("Silver", "C0C0C0");

        public static Color SkyBlue { get; } = new Color("SkyBlue", "87CEEB");

        public static Color SlateBlue { get; } = new Color("SlateBlue", "6A5ACD");

        public static Color SlateGray { get; } = new Color("SlateGray", "708090");

        public static Color Snow { get; } = new Color("Snow", "FFFAFA");

        public static Color SpringGreen { get; } = new Color("SpringGreen", "00FF7F");

        public static Color SteelBlue { get; } = new Color("SteelBlue", "4682B4");

        public static Color Tan { get; } = new Color("Tan", "D2B48C");

        public static Color Teal { get; } = new Color("Teal", "008080");

        public static Color Thistle { get; } = new Color("Thistle", "D8BFD8");

        public static Color Tomato { get; } = new Color("Tomato", "FF6347");

        public static Color Transparent { get; } = new Color("Transparent", "#00FFFFFF");

        public static Color Turquoise { get; } = new Color("Turquoise", "40E0D0");

        public static Color Violet { get; } = new Color("Violet", "EE82EE");

        public static Color Wheat { get; } = new Color("Wheat", "F5DEB3");

        public static Color White { get; } = new Color("White", "FFFFFF");

        public static Color WhiteSmoke { get; } = new Color("WhiteSmoke", "F5F5F5");

        public static Color Yellow { get; } = new Color("Yellow", "FFFF00");

        public static Color YellowGreen { get; } = new Color("YellowGreen", "9ACD32");

        private static readonly ConcurrentDictionary<string, Color> nameResolutionByCode = new ConcurrentDictionary<string, Color>(StringComparer.OrdinalIgnoreCase);

        private static readonly Dictionary<string, Color> nameResolutionByName = new Dictionary<string, Color>(StringComparer.OrdinalIgnoreCase);

        static Colors()
        {
            PropertyInfo[] properties = typeof(Colors).GetProperties();
            foreach (PropertyInfo propertyInfo in properties)
            {
                Color instance = (Color)propertyInfo.GetValue(typeof(Colors));
                nameResolutionByCode[instance.Code] = instance;
                nameResolutionByName[instance.Name] = instance;
            }
        }

        public static Color GetColor(string hex)
        {
            if (!nameResolutionByCode.TryGetValue(hex, out Color color))
            {
                color = new Color(hex);
                return color;
            }

            return color;
        }

        public static Color GetColorByName(string name)
        {
            if (!nameResolutionByName.TryGetValue(name, out Color color))
            {
                return null;
            }

            return color;
        }
    }
}
