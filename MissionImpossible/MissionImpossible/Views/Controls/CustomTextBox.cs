using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MissionImpossible.Views.Controls
{
  internal sealed class CustomTextBox : TextBox
  {
    [DllImport("user32")]
    private static extern IntPtr GetWindowDC(IntPtr hwnd);

    private readonly int _clientPadding = 2;
    private readonly int _actualBorderWidth = 2;

    private Color _borderColor = Color.Gray;

    public void SetBordersWhite()
    {
      _borderColor = Color.White;
    }

    public void PaintBordersRed()
    {
      _borderColor = Color.Red;
      PaintBorders();
    }

    public void PaintBordersDefault()
    {
      _borderColor = Color.Gray;
      PaintBorders();
    }

    protected override void WndProc(ref Message m)
    {
      //We have to change the clientsize to make room for borders
      //if not, the border is limited in how thick it is.
      if (m.Msg == 0x83) //WM_NCCALCSIZE   
      {
        if (m.WParam == IntPtr.Zero)
        {
          var rect = (Rect) Marshal.PtrToStructure(m.LParam, typeof(Rect));
          rect.Left += _clientPadding;
          rect.Right -= _clientPadding;
          rect.Top += _clientPadding;
          rect.Bottom -= _clientPadding;
          Marshal.StructureToPtr(rect, m.LParam, false);
        }
        else
        {
          var rects = (NccalsizeParams) Marshal.PtrToStructure(m.LParam, typeof(NccalsizeParams));
          rects.NewWindow.Left += _clientPadding;
          rects.NewWindow.Right -= _clientPadding;
          rects.NewWindow.Top += _clientPadding;
          rects.NewWindow.Bottom -= _clientPadding;
          Marshal.StructureToPtr(rects, m.LParam, false);
        }
      }
      if (m.Msg == 0x85) //WM_NCPAINT    
      {
        PaintBorders();
        return;
      }
      base.WndProc(ref m);
    }

    private void PaintBorders()
    {
      var wDc = GetWindowDC(Handle);
      using (var g = Graphics.FromHdc(wDc))
      {
        ControlPaint.DrawBorder(g, new Rectangle(0, 0, Size.Width, Size.Height), _borderColor, _actualBorderWidth,
          ButtonBorderStyle.Solid,
          _borderColor, _actualBorderWidth, ButtonBorderStyle.Solid, _borderColor, _actualBorderWidth,
          ButtonBorderStyle.Solid,
          _borderColor, _actualBorderWidth, ButtonBorderStyle.Solid);
      }
    }
  }
}
