using System;
using System.Drawing;

namespace Adapter
{
    public class Basement
    {
        int[,] map;

        int width, height;

        public Basement(int width, int height)
        {
            map = new int[width, height];

            this.width = width;
            this.height = height;
        }

        public void CreateItem(int x, int y, int type)
        {
            if (isInRange(x, y) == false)
                throw new ArgumentOutOfRangeException();

            map[x, y] = type;
        }

        private bool isInRange(int x, int y) => (0 <= x && x < width) && (0 <= y && y < height);

        public Bitmap GetBitmap(int scale)
        {
            Bitmap bitmap = new Bitmap(width * scale, height * scale);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var color = ToColor(map[x, y]);

                    int startX = x > 0 ? x * scale : x;
                    int startY = y > 0 ? y * scale : y;

                    int endX = x > 0 ? (x + 1) * scale : scale;
                    int endY = y > 0 ? (y + 1) * scale : scale;

                    SetRectangle(bitmap, color, startX, endX, startY, endY);
                }
            }

            return bitmap;
        }

        private Color ToColor(int type)
        {
            Color color = Color.Transparent;

            switch (type)
            {
                case 0:
                    break;
                case 1:
                    color = Color.Black;
                    break;
                case 2:
                    color = Color.Red;
                    break;
                case 3:
                    color = Color.Brown;
                    break;
                case 4:
                    color = Color.Orange;
                    break;
                case 5:
                    color = Color.DarkOrange;
                    break;
                case 6:
                    color = Color.DarkGreen;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return color;
        }

        private static void SetRectangle(Bitmap bitmap, Color color, int startX, int endX, int startY, int endY)
        {
            for (int y = startY; y < endY; y++)
            {
                for (int x = startX; x < endX; x++)
                {
                    bitmap.SetPixel(x, y, color);
                }
            }
        }
    }
}
