using System;
using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;
using Plugin.CurrentActivity;
using Xamarin.Forms;
using  System.Diagnostics ;
using Xamarin.Forms.Platform.Android;
using Smartmoveapp.Controls;
using Color = Android.Graphics.Color;
using Android.App;

[assembly: ExportRenderer(typeof(HoleLayerView), typeof(XFManualCropApp.Droid.Renderers.HoleLayerViewRenderer))]
namespace XFManualCropApp.Droid.Renderers
{
    internal class HoleLayerViewRenderer : ViewRenderer
    {
        private HoleLayerView _holeLayerView;
        private bool _drawRectangle;
        private int _screenPixelsWidth;

        public HoleLayerViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....1");
                              if (e.NewElement == null)
            {
                return;
            }

            SetLayerType(LayerType.Software, null);
            SetBackgroundColor(Color.Transparent);
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....2");
                              _holeLayerView = (HoleLayerView)e.NewElement;
            _holeLayerView.DrawRectangleHole += HoleLayerViewOnDrawRectangleHole;
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....3");
                              var displayMetrics = new DisplayMetrics();
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....4");
                             // CrossCurrentActivity.Current.Activity.WindowManager.DefaultDisplay.GetMetrics(displayMetrics);
                              Display display = ((Activity)Xamarin.Essentials.Platform.CurrentActivity).WindowManager.DefaultDisplay;

                              display.GetMetrics(displayMetrics);
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....5");
                              _screenPixelsWidth = displayMetrics.WidthPixels;
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....6");
                              System.Diagnostics.Debug.WriteLine("OnElementChanged....7");
                    }

        protected override void OnDraw(Canvas canvas)
        {
            if (!_drawRectangle)
            {
                return;
            }

            var scale = _screenPixelsWidth / Element.Width;
                              System.Diagnostics.Debug.WriteLine("OnDraw....1");
            var points = new Path();
            points.MoveTo((float)(_holeLayerView.TopLeftCorner.X * scale), (float)(_holeLayerView.TopLeftCorner.Y * scale));
            points.LineTo((float)(_holeLayerView.TopRightCorner.X * scale), (float)(_holeLayerView.TopRightCorner.Y * scale));
            points.LineTo((float)(_holeLayerView.BottomRightCorner.X * scale), (float)(_holeLayerView.BottomRightCorner.Y * scale));
            points.LineTo((float)(_holeLayerView.BottomLeftCorner.X * scale), (float)(_holeLayerView.BottomLeftCorner.Y * scale));
            points.LineTo((float)(_holeLayerView.TopLeftCorner.X * scale), (float)(_holeLayerView.TopLeftCorner.Y * scale));
            points.Close();
                              System.Diagnostics.Debug.WriteLine("OnDraw....1");
                              var transparentPaint = new Paint { Color = Color.Transparent };
            transparentPaint.SetXfermode(new PorterDuffXfermode(PorterDuff.Mode.Clear));
                              System.Diagnostics.Debug.WriteLine("OnDraw....2");
                              var borderPaint = new Paint { Color = Color.Black, StrokeWidth = 4 };
            borderPaint.SetStyle(Paint.Style.Stroke);
                              System.Diagnostics.Debug.WriteLine("OnDraw....3");
                              canvas.DrawColor(Color.Argb(150, 0, 0, 0));
            canvas.DrawPath(points, transparentPaint);
            canvas.DrawPath(points, borderPaint);
                              System.Diagnostics.Debug.WriteLine("OnDraw....4");
                    }

        private void HoleLayerViewOnDrawRectangleHole(object sender, EventArgs e)
        {
            _drawRectangle = true;
            Invalidate(); //redraw
                              System.Diagnostics.Debug.WriteLine("HoleLayerViewOnDrawRectangleHole....5");
                    }
    }
}