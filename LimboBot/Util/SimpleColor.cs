using System;

namespace LimboBot.Util
{
    public class SimpleColor
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public SimpleColor(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }

        public SimpleColor(String hexColor)
        {
            int[] rgb = ConvertHexToRgb(hexColor);
            this.Red = rgb[0];
            this.Green = rgb[1];
            this.Blue = rgb[2];
        }

        public String toHexCode()
        {
            return String.Format("#{0}{1}{2}",
                this.Red.ToString("X2"),
                this.Green.ToString("X2"),
                this.Blue.ToString("X2")
            );
        }

        public static int[] ConvertHexToRgb(String hexColor)
        {
            String hashLessString = hexColor.Replace("#", "");

            if (hashLessString.Length != 6)
            {
                throw new ArgumentException("Hexcoded color must be of length 6!");
            }

            String redHex = hashLessString.Substring(0, 2);
            String greenHex = hashLessString.Substring(2, 2);
            String blueHex = hashLessString.Substring(4, 2);

            return new int[] {
                int.Parse(redHex, System.Globalization.NumberStyles.HexNumber),
                int.Parse(greenHex, System.Globalization.NumberStyles.HexNumber),
                int.Parse(blueHex, System.Globalization.NumberStyles.HexNumber)
            };
        }
    }
}
