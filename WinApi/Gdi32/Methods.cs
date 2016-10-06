﻿using System;
using System.Runtime.InteropServices;
using System.Security;
using WinApi.Core;
using WinApi.User32;

namespace WinApi.Gdi32
{
    public static class Gdi32Methods
    {
        public const string LibraryName = "gdi32";

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr GetStockObject(int fnObject);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool DeleteObject(IntPtr hObject);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern uint SetPixel(IntPtr hdc, int x, int y, uint crColor);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int GetPixelFormat(IntPtr hdc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetBkMode(IntPtr hdc, int iBkMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateDIBSection(IntPtr hdc, IntPtr pbmi,
            DibBmiColorUsageFlag iUsage, out IntPtr ppvBits, IntPtr hSection, uint dwOffset);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport(LibraryName, CharSet = Properties.BuildCharSet)]
        public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, IntPtr lpvObject);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateBitmap(int nWidth, int nHeight, uint cPlanes, uint cBitsPerPel, IntPtr lpvBits);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateBitmapIndirect([In] ref Bitmap lpbm);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateDIBitmap(IntPtr hdc, [In] ref BitmapInfoHeader
                lpbmih, uint fdwInit, byte[] lpbInit, IntPtr lpbmi,
            DibBmiColorUsageFlag fuUsage);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateDIBitmap(IntPtr hdc, [In] ref BitmapInfoHeader
                lpbmih, uint fdwInit, IntPtr lpbInit, IntPtr lpbmi,
            DibBmiColorUsageFlag fuUsage);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int xDest, int yDest, uint
                dwWidth, uint dwHeight, int xSrc, int ySrc, uint uStartScan, uint cScanLines,
            byte[] lpvBits, IntPtr lpbmi, DibBmiColorUsageFlag fuColorUse);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetDIBitsToDevice(IntPtr hdc, int xDest, int yDest, uint
                dwWidth, uint dwHeight, int xSrc, int ySrc, uint uStartScan, uint cScanLines,
            IntPtr lpvBits, IntPtr lpbmi, DibBmiColorUsageFlag fuColorUse);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool DeleteDC(IntPtr hdc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetBitmapBits(IntPtr hbmp, uint cBytes, [In] byte[] lpBits);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int GetBitmapBits(IntPtr hbmp, int cbBuffer, [Out] byte[] lpvBits);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetBitmapBits(IntPtr hbmp, uint cBytes, IntPtr lpBits);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int GetBitmapBits(IntPtr hbmp, int cbBuffer, IntPtr lpvBits);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateRectRgnIndirect([In] ref Rectangle lprc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateEllipticRgn(int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateEllipticRgnIndirect([In] ref Rectangle lprc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2,
            int cx, int cy);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int CombineRgn(IntPtr hrgnDest, IntPtr hrgnSrc1,
            IntPtr hrgnSrc2, RegionCombinationFlags fnCombineMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool OffsetViewportOrgEx(IntPtr hdc, int nXOffset, int nYOffset, out Point lpPoint);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool SetViewportOrgEx(IntPtr hdc, int x, int y, out Point lpPoint);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SetMapMode(IntPtr hdc, int fnMapMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern RegionType SelectClipRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern RegionType ExtSelectClipRgn(IntPtr hdc, IntPtr hrgn, RegionCombinationFlags fnMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool FillRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreateSolidBrush(uint crColor);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool FrameRgn(IntPtr hdc, IntPtr hrgn, IntPtr hbr, int nWidth,
            int nHeight);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool PaintRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool InvertRgn(IntPtr hdc, IntPtr hrgn);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool LineTo(IntPtr hdc, int nXEnd, int nYEnd);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool MoveToEx(IntPtr hdc, int x, int y, IntPtr lpPoint);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool RoundRect(IntPtr hdc, int nLeftRect, int nTopRect,
            int nRightRect, int nBottomRect, int nWidth, int nHeight);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport(LibraryName, CharSet = Properties.BuildCharSet)]
        public static extern bool TextOut(IntPtr hdc, int nXStart, int nYStart,
            string lpString, int cbString);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool BitBlt(IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight,
            IntPtr hdcSrc,
            int nXSrc, int nYSrc, BitBltFlags dwRop);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
            int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
            BitBltFlags dwRop);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int SaveDC(IntPtr hdc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern bool RestoreDC(IntPtr hdc, int nSavedDc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr PathToRegion(IntPtr hdc);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreatePolygonRgn(
            Point[] lppt,
            int cPoints,
            int fnPolyFillMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern IntPtr CreatePolyPolygonRgn(Point[] lppt,
            int[] lpPolyCounts,
            int nCount, int fnPolyFillMode);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int GetDeviceCaps(IntPtr hdc, int nIndex);

        [DllImport(LibraryName, ExactSpelling = true, EntryPoint = "GdiAlphaBlend")]
        public static extern bool AlphaBlend(IntPtr hdcDest, int nXOriginDest, int nYOriginDest,
            int nWidthDest, int nHeightDest,
            IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
            BlendFunction blendFunction);

        [DllImport(LibraryName, ExactSpelling = true)]
        public static extern int GetRandomRgn(IntPtr hdc, IntPtr hrgn, DcRegionType iNum);

    }
}