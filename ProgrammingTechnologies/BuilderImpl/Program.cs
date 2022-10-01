using System.Drawing.Imaging;

namespace BuilderImpl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            KitchenRoom kitchen = new KitchenRoom(12,12);
            Apartment apartment = new Apartment(kitchen);
            apartment.GenerateRoom();
            kitchen.GetRoom(20).Save("out.jpg", ImageFormat.Jpeg);
        }
    }
}
