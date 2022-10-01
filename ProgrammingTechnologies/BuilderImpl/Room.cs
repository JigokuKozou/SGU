using System;
using System.Drawing;

namespace BuilderImpl
{
    public abstract class Room
    {
        virtual public bool CreateFloor(int x, int y) => false;
        virtual public bool CreateWall(int x, int y) => false;
        virtual public bool CreateDoor(int x, int y) => false;
        virtual public bool CreateTable(int x, int y) => false;
        virtual public bool CreateChair(int x, int y) => false;
        virtual public bool CreateFurniture(int x, int y) => false;
    }

    public class ArrayRoom : Room
    {
        ItemsType[,] map;

        int width, height;

        public ArrayRoom(int width, int height)
        {
            map = new ItemsType[width, height];

            this.width = width;
            this.height = height;
        }

        override public bool CreateFloor(int x, int y) => CreateItem(x, y, ItemsType.Floor);
        public override bool CreateWall(int x, int y) => CreateItem(x, y, ItemsType.Wall);
        public override bool CreateDoor(int x, int y) => CreateItem(x, y, ItemsType.Door);
        public override bool CreateTable(int x, int y) => CreateItem(x, y, ItemsType.Table);
        public override bool CreateChair(int x, int y) => CreateItem(x, y, ItemsType.Chair);
        public override bool CreateFurniture(int x, int y) => CreateItem(x, y, ItemsType.Furniture);

        virtual protected bool isInRange(int x, int y) => (0 <= x && x < width) && (0 <= y && y < height);

        virtual protected Color ToColor(ItemsType type)
        {
            Color color = Color.Transparent;

            return color;
        }

        virtual protected bool IsAvailableSpaceFor(int x, int y, ItemsType placedObject)
        {
            bool isAvailableSpace = false;

            switch (placedObject)
            {
                case ItemsType.None:
                    break;
                case ItemsType.Floor:
                case ItemsType.Wall:
                    isAvailableSpace = true;
                    break;
                case ItemsType.Door:
                    isAvailableSpace = map[x, y] is ItemsType.None || map[x, y] is ItemsType.Wall;
                    break;
                case ItemsType.Table:
                    isAvailableSpace = map[x, y] is ItemsType.None || map[x, y] is ItemsType.Floor;
                    break;
                case ItemsType.Chair:
                    isAvailableSpace = map[x, y] is ItemsType.None || map[x, y] is ItemsType.Floor;
                    break;
                case ItemsType.Furniture:
                    isAvailableSpace = map[x, y] is ItemsType.None || map[x, y] is ItemsType.Floor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return isAvailableSpace;
        }

        virtual protected bool CreateItem(int x, int y, ItemsType type)
        {
            if (isInRange(x, y) == false)
                throw new ArgumentOutOfRangeException();

            bool result = IsAvailableSpaceFor(x, y, type);

            if (result)
            {
                map[x, y] = type;
            }

            return result;
        }

        public Bitmap GetRoom(int scale)
        {
            Bitmap bitmap = new Bitmap(width * scale, height * scale);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    var color = ToColor(map[x, y]);

                    int startX = x > 0 ? x * scale: x;
                    int startY = y > 0 ? y * scale: y;

                    int endX = x > 0 ? (x + 1) * scale : scale;
                    int endY = y > 0 ? (y + 1) * scale : scale;

                    SetRectangle(bitmap, color, startX, endX, startY, endY);
                }
            }

            return bitmap;
        }

        private void SetRectangle(Bitmap bitmap, Color color, int startX, int endX, int startY, int endY)
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