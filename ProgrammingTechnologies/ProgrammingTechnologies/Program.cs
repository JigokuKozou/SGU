using Adapter;
using Builder;
using Decorator;
using System.Drawing;
using System.Drawing.Imaging;

namespace ProgrammingTechnologies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StartDecoratorDemo();
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

        static void StartDecoratorDemo(string pathImage = "outBuilder.jpg")
        {
            Bitmap bitmap = new Bitmap(pathImage);
            EditorOfBitmap editor = new GrayscaleConverter(new ReflectorHorizontallyBitmap(new ReflectorVerticalBitmap()));

            editor.GetFormattedBitmap(bitmap).Save("decorated" + pathImage, ImageFormat.Jpeg);
        }
    }
}
