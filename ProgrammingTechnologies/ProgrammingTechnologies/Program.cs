using BuilderImpl;
using System.Drawing.Imaging;

namespace ProgrammingTechnologies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartBuilderDemo();
        }

        static void StartBuilderDemo()
        {
            KitchenRoom kitchen = new KitchenRoom(12, 12);
            Apartment apartment = new Apartment(kitchen);
            apartment.GenerateRoom();
            kitchen.GetRoom(42).Save("out.jpg", ImageFormat.Jpeg);
        }
    }
}
