using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace LeafFarmer
{
    internal class CursorMover
    {
        #region Public methods to move cursor within game window

        public static void MovePointer(WindowInformation gameWindow, IMovementGenerator generator)
        {
            RECT rect = new RECT();
            GetWindowRect(gameWindow.Handle, out rect);

            while (true)
            {
                List<Point> pointsToMove = generator.GenerateMovement(rect.Top, rect.Bottom, rect.Left, rect.Right);
                foreach (Point pt in pointsToMove)
                {
                    POINT p = new POINT(pt.x, pt.y);
                    //ClientToScreen(gameWindow.Handle, ref p);
                    SetCursorPos(p.x, p.y);
                    Thread.Sleep(500); // todo: add async timer
                }
            }
        }

        #endregion


        #region Unmanaged Code References

        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        /// <summary>
        /// The POINT structure defines the x- and y- coordinates of a point for Windows API.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;

            public POINT(int X, int Y)
            {
                x = X;
                y = Y;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }


        #endregion
    }
}
