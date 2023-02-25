using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ColorSetting
{
    public static Dictionary<Color, string> colors = new Dictionary<Color, string>()
    {
        {new Color(1.0f, 1.0f, 1.0f, 1.0f), "White" },
        {new Color(0.75f, 0.75f, 0.75f, 1.0f), "Silver" },
        {new Color(0.5f, 0.5f, 0.5f, 1.0f), "Gray" },
        {new Color(0.0f, 0.0f, 0.0f, 1.0f), "Black" },
        {new Color(1.0f, 0.0f, 0.0f, 1.0f), "Red" },
        {new Color(0.5f, 0.0f, 0.0f, 1.0f), "Maroon" },
        {new Color(1.0f, 1.0f, 0.0f, 1.0f), "Yellow" },
        {new Color(0.5f, 0.5f, 0.0f, 1.0f), "Olive" },
        {new Color(0.0f, 1.0f, 0.0f, 1.0f), "Lime" },
        {new Color(0.0f, 0.5f, 0.0f, 1.0f), "Green" },
        {new Color(0.0f, 1.0f, 1.0f, 1.0f), "Aqua" },
        {new Color(0.0f, 0.5f, 0.5f, 1.0f), "Teal" },
        {new Color(0.0f, 0.0f, 1.0f, 1.0f), "Blue" },
        {new Color(0.0f, 0.0f, 0.5f, 1.0f), "Navy" },
        {new Color(1.0f, 0.0f, 1.0f, 1.0f), "Fuchsia" },
        {new Color(0.5f, 1.0f, 0.5f, 1.0f), "Purple" },
    };

    public static string GetColorName(Color colorFormat)
    {
        string colorName;
        // If name found.
        if (colors.TryGetValue(colorFormat, out colorName))
        {
            return colorName;
        }

        // If name not found.
        return "Color name not found.";
    }
}
