using Builder;
using System.Drawing;

namespace Adapter
{
    public class BasementAdapter : ArrayRoom
    {
        Basement basement;

        public BasementAdapter(int width, int height) : base(width, height)
        {
            basement = new Basement(width, height);
        }

        public override bool CreateFloor(int x, int y)
        {
            basement.CreateItem(x, y, 1);
            return true;
        }

        public override bool CreateWall(int x, int y)
        {
            basement.CreateItem(x, y, 2);
            return true;
        }

        public override bool CreateDoor(int x, int y)
        {
            basement.CreateItem(x, y, 3);
            return true;
        }

        public override bool CreateTable(int x, int y)
        {
            basement.CreateItem(x, y, 4);
            return true;
        }

        public override bool CreateChair(int x, int y)
        {
            basement.CreateItem(x, y, 5);
            return true;
        }

        public override bool CreateFurniture(int x, int y)
        {
            basement.CreateItem(x, y, 6);
            return true;
        }

        public override Bitmap GetRoom(int scale)
        {
            return basement.GetBitmap(scale);
        }
    }
}
