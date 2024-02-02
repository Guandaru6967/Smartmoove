using SkiaSharp.Views.Forms;
using SkiaSharp;
using Smartmoveapp.Controls;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Smartmoveapp.ViewModels;
using System.IO;
using Xamarin.Essentials;
using System.Diagnostics;

namespace Smartmoveapp.Views.Document
{
          public class CropppingObject 
          {
                    public   SKBitmap originalBitmap;
                    public  bool pageLoaded=false;
                    public  SKPath pathToClip;
               
                    public  byte[] bytearray;
          }
          [XamlCompilation(XamlCompilationOptions.Compile)]
          public partial class CroppingPage : ContentPage
          {
                    CropppingObject cropObject=new CropppingObject();

                    public CroppingPage(ImageObject image)
                    {
                              BindingContext = new CroppingViewModel { ImageObject = image };
                              /*  MemoryStream stream = new MemoryStream(image.ImageData);

                                // Use StreamImageSource to create an ImageSource from the MemoryStream
                                ImageSource imageSource = ImageSource.FromStream(() => stream);*/
                              MemoryStream stream = new MemoryStream(image.ImageData);
                              cropObject.originalBitmap = SKBitmap.Decode(stream);


                              InitializeComponent();
                        

                            
                    }
                    private void CropButton_OnClicked(object sender, EventArgs e)
                              {
                              Debug.WriteLine("Drawn Something on Image");
                              cropObject.pathToClip = new SKPath();
                                        SKPoint[] arr = 
                                        {
                new SKPoint((float) (ManualCropView.TopLeftCorner.X * DeviceDisplay.MainDisplayInfo.Density), (float) (ManualCropView.TopLeftCorner.Y * DeviceDisplay.MainDisplayInfo.Density)),
                new SKPoint((float) (ManualCropView.TopRightCorner.X * DeviceDisplay.MainDisplayInfo.Density), (float) (ManualCropView.TopRightCorner.Y * DeviceDisplay.MainDisplayInfo.Density)),
                new SKPoint((float) (ManualCropView.BottomRightCorner.X * DeviceDisplay.MainDisplayInfo.Density), (float) (ManualCropView.BottomRightCorner.Y * DeviceDisplay.MainDisplayInfo.Density)),
                new SKPoint((float) (ManualCropView.BottomLeftCorner.X * DeviceDisplay.MainDisplayInfo.Density), (float) (ManualCropView.BottomLeftCorner.Y * DeviceDisplay.MainDisplayInfo.Density))
                                        };
                              cropObject.pathToClip.AddPoly(arr);

                                        CropImageCanvas.InvalidateSurface(); // redraw
                              }

                    private void DisplayCroppedButton_OnClicked(object sender, EventArgs e)
          {
                    DisplayCroppedButton.IsVisible = false;
                    CropImageCanvas.IsVisible = false;
                    CroppedImageView.IsVisible = true;

                    Stream stream = new MemoryStream(cropObject.bytearray);
                    //CroppedImageView.Source = Xamarin.Forms.ImageSource.FromStream(() => stream);
          }
                    protected override void OnAppearing()
                    {
                              base.OnAppearing();

                              if (cropObject.pageLoaded)
                              {
                                        return;
                              }

                              cropObject.pageLoaded = true;
                              ManualCropView.Initialize();
                    }
                    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs e)
                    {
                              SKImageInfo info = e.Info;
                              SKSurface surface = e.Surface;
                              SKCanvas canvas = surface.Canvas;

                              canvas.Clear();



                              if (cropObject.pathToClip != null)
                              {
                                        // Crop canvas before drawing image
                                        canvas.ClipPath(cropObject.pathToClip);
                              }

                              //canvas.DrawBitmap(_originalBitmap, info.Rect);

                              using (SKPaint paint = new SKPaint())
                              {
                                        paint.ColorFilter =
                                         SKColorFilter.CreateColorMatrix(new float[]
                                            {
                        0.21f, 0.72f, 0.07f, 0, 0,
                        0.21f, 0.72f, 0.07f, 0, 0,
                        0.21f, 0.72f, 0.07f, 0, 0,
                        0,     0,     0,     1, 0
                                            });

                                        // Calculate the scale factor to fit the SKBitmap within the SKCanvasView
                                        float scaleX = (float)e.Info.Width / cropObject.originalBitmap.Width;
                                        float scaleY = (float)e.Info.Height / cropObject.originalBitmap.Height;
                                        float scaleFactor = Math.Min(scaleX, scaleY);
                                      /*  Debug.WriteLine("Scale X {0}",scaleX);
                                        Debug.WriteLine("Scale Y {0}", scaleY);
                                        Debug.WriteLine(e.Info.Width);Debug.WriteLine(cropObject.originalBitmap.Width);
                                        Debug.WriteLine(e.Info.Height);Debug.WriteLine(cropObject.originalBitmap.Height);*/
                                        // Calculate the scaled dimensions of the SKBitmap
                                        float scaledWidth = e.Info.Width * scaleFactor;
                                        float scaledHeight = e.Info.Height * scaleFactor;

                                        // Calculate the translation to center the SKBitmap within the SKCanvasView
                                        float translateX = ((float)e.Info.Width - scaledWidth) / 2;
                                        float translateY = ((float)e.Info.Height - scaledHeight) / 2;

                                        // Set up the matrix for scaling and translation
                                        SKRect destRect = new SKRect(translateX, translateY, translateX + scaledWidth, translateY + scaledHeight);

                                        //   canvas.DrawBitmap(cropObject.originalBitmap, info.Rect,paint:paint);
                                        //destRect
                                        /*    Debug.WriteLine(info.Rect.Width);
                                            Debug.WriteLine(info.Rect.Height);
                                            Debug.WriteLine(info.Rect.Top);
                                            Debug.WriteLine(info.Rect.Bottom);
                                                       Debug.WriteLine(info.Rect.Left);
                                                      Debug.WriteLine(info.Rect.Right);*/
                                        var displayinfo=DeviceDisplay.MainDisplayInfo;
                                            var imagRect = new SKRect {Size=new SKSize { Width=cropObject.originalBitmap.Width/2,Height=cropObject.originalBitmap.Height / 2 }, Top = 0, Bottom = cropObject.originalBitmap.Height/2, Left = Convert.ToSingle(displayinfo.Width/4)/- Convert.ToSingle(cropObject.originalBitmap.Width/4), Right = Convert.ToSingle(cropObject.originalBitmap.Width /4)+Convert.ToSingle(displayinfo.Width/4)};
                                        canvas.DrawBitmap(cropObject.originalBitmap, imagRect, paint: paint);
                              }

                              if (cropObject.pathToClip != null)
                              {
                                        // Get cropped image byte array
                                        var snap = surface.Snapshot();
                                        var data = snap.Encode();
                                        cropObject.bytearray = data.ToArray();

                                        ManualCropView.IsVisible = false;
                                        CropButton.IsVisible = false;
                                        DisplayCroppedButton.IsVisible = true;
                              }
                    }
          }
}