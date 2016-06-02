namespace Idler.Model
{
    using System;
    using System.Runtime.InteropServices;

    public interface IIdlingReporter
    {
        uint GetIdleTime();

        long GetLastInputTime();
    }

    public class IdlingReporter : IIdlingReporter
    {
        internal struct LASTINPUTINFO
        {
            public uint cbSize;

            public uint dwTime;
        }

        public uint GetIdleTime()
        {
            var lastInPut = new LASTINPUTINFO();

            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            GetLastInputInfo(ref lastInPut);

            return ((uint)Environment.TickCount - lastInPut.dwTime);
        }

        public long GetLastInputTime()
        {
            var lastInPut = new LASTINPUTINFO();

            lastInPut.cbSize = (uint)Marshal.SizeOf(lastInPut);
            if (!GetLastInputInfo(ref lastInPut))
            {
                throw new Exception(GetLastError().ToString());
            }

            return lastInPut.dwTime;
        }

        [DllImport("User32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("Kernel32.dll")]
        private static extern uint GetLastError();
    }
}
