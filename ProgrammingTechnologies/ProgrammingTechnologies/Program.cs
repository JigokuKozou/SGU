using Adapter;
using BuilderImpl;
using System.Drawing.Imaging;

namespace ProgrammingTechnologies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartBuilderDemo(scale: 42, width: 12, height: 12);
        }

        static void StartBuilderDemo(int scale, int width, int height)
        {
            ArrayRoom kitchen = new KitchenRoom(width, height);
            Apartment apartment = new Apartment(kitchen);
            apartment.GenerateRoom();
            kitchen.GetRoom(scale).Save("outBuilder.jpg", ImageFormat.Jpeg);
        }

        static void StartAdapterDemo(int scale, int width, int height)
        {
            ArrayRoom basement = new BasementAdapter(width, height);
            Apartment apartment = new Apartment(basement);
            apartment.GenerateRoom();
            basement.GetRoom(scale).Save("outAdapter.jpg", ImageFormat.Jpeg);
        }
    }
}
