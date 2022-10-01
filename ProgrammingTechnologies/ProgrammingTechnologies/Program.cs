using Adapter;
using BuilderImpl;
using System.Drawing.Imaging;

namespace ProgrammingTechnologies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartAdapterDemo();
        }

        static void StartBuilderDemo()
        {
            KitchenRoom kitchen = new KitchenRoom(12, 12);
            Apartment apartment = new Apartment(kitchen);
            apartment.GenerateRoom();
            kitchen.GetRoom(42).Save("outBuilder.jpg", ImageFormat.Jpeg);
        }

        static void StartAdapterDemo()
        {
            BasementAdapter basement = new BasementAdapter(12, 12);
            Apartment apartment = new Apartment(basement);
            apartment.GenerateRoom();
            basement.GetRoom(42).Save("outAdapter.jpg", ImageFormat.Jpeg);
        }
    }
}
