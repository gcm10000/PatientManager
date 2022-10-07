using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using PatientManager.WinFormsApp.DTOs;

namespace PatientManager.WinFormsApp.Helpers
{
    public static class LocalWebcam
    {
        internal static readonly Guid SystemDeviceEnum = new(0x62BE5D10, 0x60EB, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);
        internal static readonly Guid VideoInputDevice = new(0x860BB310, 0x5D01, 0x11D0, 0xBD, 0x3B, 0x00, 0xA0, 0xC9, 0x11, 0xCE, 0x86);

        [ComImport, Guid("55272A00-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface IPropertyBag
        {
            [PreserveSig]
            int Read(
                [In, MarshalAs(UnmanagedType.LPWStr)] string propertyName,
                [In, Out, MarshalAs(UnmanagedType.Struct)] ref object pVar,
                [In] IntPtr pErrorLog);
            [PreserveSig]
            int Write(
                [In, MarshalAs(UnmanagedType.LPWStr)] string propertyName,
                [In, MarshalAs(UnmanagedType.Struct)] ref object pVar);
        }

        [ComImport, Guid("29840822-5B84-11D0-BD3B-00A0C911CE86"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        internal interface ICreateDevEnum
        {
            [PreserveSig]
            int CreateClassEnumerator([In] ref Guid type, [Out] out IEnumMoniker enumMoniker, [In] int flags);
        }

        public static IEnumerable<CameraInformation> GetCameraInformations()
        {
            IMoniker[] moniker = new IMoniker[100];
            // Get the system device enumerator
            var srvType = Type.GetTypeFromCLSID(SystemDeviceEnum);
            // create device enumerator
            var comObj = Activator.CreateInstance(srvType);
            var enumDev = (ICreateDevEnum)comObj;
            // Create an enumerator to find filters of specified category
            enumDev.CreateClassEnumerator(VideoInputDevice, out IEnumMoniker enumMon, 0);
            Guid bagId = typeof(IPropertyBag).GUID;
            int i = 0;
            while (enumMon.Next(1, moniker, IntPtr.Zero) == 0)
            {
                // get property bag of the moniker
                moniker[0].BindToStorage(null, null, ref bagId, out object bagObj);
                var bag = (IPropertyBag)bagObj;
                // read FriendlyName
                object val = string.Empty;
                bag.Read("FriendlyName", ref val, IntPtr.Zero);
                //list in box
                yield return new CameraInformation(i++, (string)val);
            }
        }
    }
}
