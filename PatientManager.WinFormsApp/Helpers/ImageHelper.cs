using System.Drawing.Imaging;

namespace PatientManager.WinFormsApp.Helpers
{
    public static class ImageHelper
    {
        public static Image FromBytes(byte[] byteArrayIn)
        {
            GC.Collect();
            using var ms = new MemoryStream(byteArrayIn);
            return Image.FromStream(ms);
        }

        public static byte[] ToByteArray(Image imageIn)
        {
            using var ms = new MemoryStream();
            imageIn.Save(ms, ImageFormat.Bmp);
            return ms.ToArray();
        }
    }
}
