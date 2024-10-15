using System.Runtime.InteropServices;

namespace OrmConfigGenerator.Extensions
{
    public static partial class ControlExtensions
    {
        [LibraryImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static partial bool LockWindowUpdate(IntPtr hWndLock);

        public static void SuspendDrawing(this Control control)
        {
            LockWindowUpdate(control.Handle);
        }

        public static void ResumeDrawing(this Control control)
        {
            LockWindowUpdate(IntPtr.Zero);
        }
    }
}
