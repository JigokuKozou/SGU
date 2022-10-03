using System;
using System.IO;

namespace Builder
{
    public enum ItemsType
    {
        None = 0,
        Floor = 1,
        Wall = 2,
        Door = 3,
        Table = 4,
        Chair = 5,
        Furniture = 6,
    }

    public class Apartment
    {
        Room room;

        public Apartment(Room room)
        {
            this.room = room;
        }

        public void GenerateRoom(string pathMap = "map.txt")
        {
            StreamReader read = new StreamReader(pathMap);
            string line;
            for (int y = 0; (line = read.ReadLine()) != null; y++)
            {
                string[] items = line.Split(' ');
                for (int x = 0; x < items.Length; x++)
                {
                    switch ((ItemsType)Int32.Parse(items[x]))
                    {
                        case ItemsType.Floor:
                            room.CreateFloor(x, y); break;
                        case ItemsType.Wall:
                            room.CreateWall(x, y); break;
                        case ItemsType.Furniture:
                            room.CreateFurniture(x, y); break;
                        case ItemsType.Chair:
                            room.CreateChair(x, y); break;
                        case ItemsType.Table:
                            room.CreateTable(x, y); break;
                        case ItemsType.Door:
                            room.CreateDoor(x, y); break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            read.Close();
        }
    }
}
