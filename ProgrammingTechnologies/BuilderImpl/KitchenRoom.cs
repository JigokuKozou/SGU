using System;
using System.Drawing;

namespace BuilderImpl
{
    public class KitchenRoom : ArrayRoom
    {
        public KitchenRoom(int width, int height) : base(width, height) { }

        override protected Color ToColor(ItemsType type)
        {
            Color color = Color.Transparent;

            switch (type)
            {
                case ItemsType.None:
                    break;
                case ItemsType.Floor:
                    color = Color.Brown;
                    break;
                case ItemsType.Wall:
                    color = Color.Black;
                    break;
                case ItemsType.Door:
                    color = Color.White;
                    break;
                case ItemsType.Table:
                    color = Color.Orange;
                    break;
                case ItemsType.Chair:
                    color = Color.DarkOrange;
                    break;
                case ItemsType.Furniture:
                    color = Color.Green;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return color;
        }
    }
}
