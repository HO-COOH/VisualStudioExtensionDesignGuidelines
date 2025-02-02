using System;

namespace VisualStudioExtensionDesignGuidelines
{
    internal static class ColorContrast
    {
        // Find the contrast ratio: https://www.w3.org/WAI/GL/wiki/Contrast_ratio
        public static double CalculateContrastRatio(System.Windows.Media.Color first, System.Windows.Media.Color second)
        {
            var relLuminanceOne = GetRelativeLuminance(first);
            var relLuminanceTwo = GetRelativeLuminance(second);
            return (Math.Max(relLuminanceOne, relLuminanceTwo) + 0.05)
                / (Math.Min(relLuminanceOne, relLuminanceTwo) + 0.05);
        }

        // Get relative luminance: https://www.w3.org/WAI/GL/wiki/Relative_luminance
        public static double GetRelativeLuminance(System.Windows.Media.Color c)
        {
            var rSRGB = c.R / 255.0;
            var gSRGB = c.G / 255.0;
            var bSRGB = c.B / 255.0;

            var r = rSRGB <= 0.04045 ? rSRGB / 12.92 : Math.Pow(((rSRGB + 0.055) / 1.055), 2.4);
            var g = gSRGB <= 0.04045 ? gSRGB / 12.92 : Math.Pow(((gSRGB + 0.055) / 1.055), 2.4);
            var b = bSRGB <= 0.04045 ? bSRGB / 12.92 : Math.Pow(((bSRGB + 0.055) / 1.055), 2.4);
            return 0.2126 * r + 0.7152 * g + 0.0722 * b;
        }
    }
}
