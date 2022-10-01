using System.Drawing;

namespace Decorator
{
    public abstract class EditorOfBitmap
    {
        private readonly EditorOfBitmap editor;

        public EditorOfBitmap(EditorOfBitmap editor = null)
        {
            this.editor = editor;
        }

        virtual public Bitmap GetFormattedBitmap(Bitmap bitmap)
        {
            if (editor != null)
            {
                bitmap = editor.GetFormattedBitmap(bitmap);
            }

            return bitmap;
        }
    }

    public class ReflectorHorizontallyBitmap : EditorOfBitmap
    {
        public ReflectorHorizontallyBitmap(EditorOfBitmap editor = null) : base(editor) { }

        public override Bitmap GetFormattedBitmap(Bitmap bitmap)
        {
            bitmap = base.GetFormattedBitmap(bitmap);
            bitmap?.RotateFlip(RotateFlipType.RotateNoneFlipX);

            return bitmap;
        }
    }

    public class ReflectorVerticalBitmap : EditorOfBitmap
    {
        public ReflectorVerticalBitmap(EditorOfBitmap editor = null) : base(editor) { }

        public override Bitmap GetFormattedBitmap(Bitmap bitmap)
        {
            bitmap = base.GetFormattedBitmap(bitmap);
            bitmap?.RotateFlip(RotateFlipType.RotateNoneFlipY);

            return bitmap;
        }
    }
    public class GrayscaleConverter : EditorOfBitmap
    {
        public GrayscaleConverter(EditorOfBitmap editor = null) : base(editor) { }

        public override Bitmap GetFormattedBitmap(Bitmap bitmap)
        {
            bitmap = base.GetFormattedBitmap(bitmap);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var realColor = bitmap.GetPixel(x, y);

                    int greyScale = (int)((realColor.R * 0.3) + (realColor.G * 0.59) + (realColor.B * 0.11));
                    var greyscaleColor = Color.FromArgb(realColor.A, greyScale, greyScale, greyScale);

                    bitmap.SetPixel(x, y, greyscaleColor);
                }
            }

            return bitmap;
        }
    }


}
