using Builder;
using Adapter;
using Decorator;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using Facade;

namespace ProgrammingTechnologies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int scale = 42;
            int width = 12;
            int height = 12;

            StartBuilderDemo(scale, width, height);

            StartAdapterDemo(scale, width, height);

            StartDecoratorDemo();

            StartFacadeDemo();
        }

        static void StartBuilderDemo(int scale, int width, int height)
        {


            Console.WriteLine("Builder demo working...");

            ArrayRoom kitchen = new KitchenRoom(width, height);
            Apartment apartment = new Apartment(kitchen);

            apartment.GenerateRoom();

            string pathOutput = "outBuilder.jpg";
            kitchen.GetRoom(scale).Save(pathOutput, ImageFormat.Jpeg);

            Console.WriteLine("Builder demo finished!" + Environment.NewLine +
                "File output: " + pathOutput + Environment.NewLine);
        }

        static void StartAdapterDemo(int scale, int width, int height)
        {
            Console.WriteLine("Adapter demo working...");

            ArrayRoom basement = new BasementAdapter(width, height);
            Apartment apartment = new Apartment(basement);

            apartment.GenerateRoom();

            string pathOutput = "outAdapter.jpg";
            basement.GetRoom(scale).Save(pathOutput, ImageFormat.Jpeg);

            Console.WriteLine("Adapter demo finished!" + Environment.NewLine +
                "File output: " + pathOutput + Environment.NewLine);
        }

        static void StartDecoratorDemo(string pathImage = "outBuilder.jpg")
        {
            Console.WriteLine("Decorator demo working...");

            Bitmap bitmap = new Bitmap(pathImage);
            EditorOfBitmap editor = 
                new GrayscaleConverter(new ReflectorHorizontallyBitmap(new ReflectorVerticalBitmap()));

            string pathOutput = "decorated_" + pathImage;
            editor.GetFormattedBitmap(bitmap).Save(pathOutput, ImageFormat.Jpeg);

            Console.WriteLine("Decorator demo finished!" + Environment.NewLine +
                "File output: " + pathOutput + Environment.NewLine);
        }

        static void StartFacadeDemo()
        {
            Console.WriteLine("Decorator demo working...");

            var group = new WarMachineGroup();

            group.Add(new Tigr());
            group.Add(new Havoc());
            group.Add(new Havoc());
            group.Add(new Tigr());
            group.Add(new Tigr());
            group.Add(new Tigr());
            group.Add(new Tigr());

            group.Attack();

            Console.WriteLine("Decorator demo finished!");
        }
    }
}
