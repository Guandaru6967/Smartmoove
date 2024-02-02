using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Smartmoveapp.Controls
{
          public class HoleLayerView : View
          {
                    public event EventHandler DrawRectangleHole;

                    public Point TopLeftCorner { get; set; }
                    public Point TopRightCorner { get; set; }
                    public Point BottomLeftCorner { get; set; }
                    public Point BottomRightCorner { get; set; }

                    public void DrawRectangle()
                    {
                              DrawRectangleHole?.Invoke(this, EventArgs.Empty);
                    }
          }
}
