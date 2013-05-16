using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using System.Reflection;

namespace Util
{
   public class ColorHelpers
    {
        public static string GetColorName(Color color)
        {
            return _knownColors
                .Where(kvp => kvp.Value.Equals(color))
                .Select(kvp => kvp.Key)
                .FirstOrDefault();
        }

        static readonly Dictionary<string, Color> _knownColors = GetKnownColors();

        static Dictionary<string, Color> GetKnownColors()
        {
            var colorProperties = typeof(Colors).GetProperties(BindingFlags.Static | BindingFlags.Public);
            return colorProperties
                .ToDictionary(
                    p => p.Name,
                    p => (Color)p.GetValue(null, null));
        }

        public static Color GetColorByName(string ColorName)
        {
            return _knownColors[ColorName];
        }

        public static Color GetRandomLightColor()
        {
            Random rand = new Random();
            List<Color> lightColors = _knownColors.Where(o => o.Key.StartsWith("Light")).Select(m=>m.Value).ToList();
            return lightColors[rand.Next(lightColors.Count)];
        }
    }
}
