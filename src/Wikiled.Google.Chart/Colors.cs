using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Text;

namespace Wikiled.Google.Chart
{
    public readonly struct Colors
    {
        public string AliceBlue => "#FFF0F8FF";

        public string AntiqueWhite => "#FFFAEBD7";

        public string Aqua => "#FF00FFFF";

        public string Aquamarine => "#FF7FFFD4";

        public string Azure => "#FFF0FFFF";

        public string Beige => "#FFF5F5DC";

        public string Bisque => "#FFFFE4C4";

        public string Black => "#FF000000";

        public string BlanchedAlmond => "#FFFFEBCD";

        public string Blue => "#FF0000FF";

        public string BlueViolet => "#FF8A2BE2";

        public string Brown => "#FFA52A2A";

        public string BurlyWood => "#FFDEB887";

        public string CadetBlue => "#FF5F9EA0";

        public string Chartreuse => "#FF7FFF00";

        public string Chocolate => "#FFD2691E";

        public string Coral => "#FFFF7F50";

        public string CornflowerBlue => "#FF6495ED";

        public string Cornsilk => "#FFFFF8DC";

        public string Crimson => "#FFDC143C";

        public string Cyan => "#FF00FFFF";

        public string DarkBlue => "#FF00008B";

        public string DarkCyan => "#FF008B8B";

        public string DarkGoldenrod => "#FFB8860B";

        public string DarkGray => "#FFA9A9A9";

        public string DarkGreen => "#FF006400";

        public string DarkKhaki => "#FFBDB76B";

        public string DarkMagenta => "#FF8B008B";

        public string DarkOliveGreen => "#FF556B2F";

        public string DarkOrange => "#FFFF8C00";

        public string DarkOrchid => "#FF9932CC";

        public string DarkRed => "#FF8B0000";

        public string DarkSalmon => "#FFE9967A";

        public string DarkSeaGreen => "#FF8FBC8F";

        public string DarkSlateBlue => "#FF483D8B";

        public string DarkSlateGray => "#FF2F4F4F";

        public string DarkTurquoise => "#FF00CED1";

        public string DarkViolet => "#FF9400D3";

        public string DeepPink => "#FFFF1493";

        public string DeepSkyBlue => "#FF00BFFF";

        public string DimGray => "#FF696969";

        public string DodgerBlue => "#FF1E90FF";

        public string Firebrick => "#FFB22222";

        public string FloralWhite => "#FFFFFAF0";

        public string ForestGreen => "#FF228B22";

        public string Fuchsia => "#FFFF00FF";

        public string Gainsboro => "#FFDCDCDC";

        public string GhostWhite => "#FFF8F8FF";

        public string Gold => "#FFFFD700";

        public string Goldenrod => "#FFDAA520";

        public string Gray => "#FF808080";

        public string Green => "#FF008000";

        public string GreenYellow => "#FFADFF2F";

        public string Honeydew => "#FFF0FFF0";

        public string HotPink => "#FFFF69B4";

        public string IndianRed => "#FFCD5C5C";

        public string Indigo => "#FF4B0082";

        public string Ivory => "#FFFFFFF0";

        public string Khaki => "#FFF0E68C";

        public string Lavender => "#FFE6E6FA";

        public string LavenderBlush => "#FFFFF0F5";

        public string LawnGreen => "#FF7CFC00";

        public string LemonChiffon => "#FFFFFACD";

        public string LightBlue => "#FFADD8E6";

        public string LightCoral => "#FFF08080";

        public string LightCyan => "#FFE0FFFF";

        public string LightGoldenrodYellow => "#FFFAFAD2";

        public string LightGray => "#FFD3D3D3";

        public string LightGreen => "#FF90EE90";

        public string LightPink => "#FFFFB6C1";

        public string LightSalmon => "#FFFFA07A";

        public string LightSeaGreen => "#FF20B2AA";

        public string LightSkyBlue => "#FF87CEFA";

        public string LightSlateGray => "#FF778899";

        public string LightSteelBlue => "#FFB0C4DE";

        public string LightYellow => "#FFFFFFE0";

        public string Lime => "#FF00FF00";

        public string LimeGreen => "#FF32CD32";

        public string Linen => "#FFFAF0E6";

        public string Magenta => "#FFFF00FF";

        public string Maroon => "#FF800000";

        public string MediumAquamarine => "#FF66CDAA";

        public string MediumBlue => "#FF0000CD";

        public string MediumOrchid => "#FFBA55D3";

        public string MediumPurple => "#FF9370DB";

        public string MediumSeaGreen => "#FF3CB371";

        public string MediumSlateBlue => "#FF7B68EE";

        public string MediumSpringGreen => "#FF00FA9A";

        public string MediumTurquoise => "#FF48D1CC";

        public string MediumVioletRed => "#FFC71585";

        public string MidnightBlue => "#FF191970";

        public string MintCream => "#FFF5FFFA";

        public string MistyRose => "#FFFFE4E1";

        public string Moccasin => "#FFFFE4B5";

        public string NavajoWhite => "#FFFFDEAD";

        public string Navy => "#FF000080";

        public string OldLace => "#FFFDF5E6";

        public string Olive => "#FF808000";

        public string OliveDrab => "#FF6B8E23";

        public string Orange => "#FFFFA500";

        public string OrangeRed => "#FFFF4500";

        public string Orchid => "#FFDA70D6";

        public string PaleGoldenrod => "#FFEEE8AA";

        public string PaleGreen => "#FF98FB98";

        public string PaleTurquoise => "#FFAFEEEE";

        public string PaleVioletRed => "#FFDB7093";

        public string PapayaWhip => "#FFFFEFD5";

        public string PeachPuff => "#FFFFDAB9";

        public string Peru => "#FFCD853F";

        public string Pink => "#FFFFC0CB";

        public string Plum => "#FFDDA0DD";

        public string PowderBlue => "#FFB0E0E6";

        public string Purple => "#FF800080";

        public string Red => "#FFFF0000";

        public string RosyBrown => "#FFBC8F8F";

        public string RoyalBlue => "#FF4169E1";

        public string SaddleBrown => "#FF8B4513";

        public string Salmon => "#FFFA8072";

        public string SandyBrown => "#FFF4A460";

        public string SeaGreen => "#FF2E8B57";

        public string SeaShell => "#FFFFF5EE";

        public string Sienna => "#FFA0522D";

        public string Silver => "#FFC0C0C0";

        public string SkyBlue => "#FF87CEEB";

        public string SlateBlue => "#FF6A5ACD";

        public string SlateGray => "#FF708090";

        public string Snow => "#FFFFFAFA";

        public string SpringGreen => "#FF00FF7F";

        public string SteelBlue => "#FF4682B4";

        public string Tan => "#FFD2B48C";

        public string Teal => "#FF008080";

        public string Thistle => "#FFD8BFD8";

        public string Tomato => "#FFFF6347";

        public string Transparent => "#00FFFFFF";

        public string Turquoise => "#FF40E0D0";

        public string Violet => "#FFEE82EE";

        public string Wheat => "#FFF5DEB3";

        public string White => "#FFFFFFFF";

        public string WhiteSmoke => "#FFF5F5F5";

        public string Yellow => "#FFFFFF00";

        public string YellowGreen => "#FF9ACD32";

        private static Dictionary<string, string> nameResolution = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        static Colors()
        {
            FieldInfo[] fields = typeof(Colors).GetFields();
            foreach (var field in fields)
            {
                nameResolution[field.GetValue(typeof(Colors)).ToString()] = field.Name;
            }
        }

        public static string GetColorName(string hex)
        {
            nameResolution.TryGetValue()
        }
    }
}
