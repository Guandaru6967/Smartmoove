using Smartmoveapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using SkiaSharp;
using System.IO;
using System.Diagnostics;
namespace Smartmoveapp.Utilities
{
    public class ImageRotationExtenstion
    {
                    public byte[] Data { get; set; }=Array.Empty<byte>();
                    public bool IsRotated { get; set; } = false;   
                    public bool IsImageLoaded { get; set; }=false;
                    SKEncodedImageFormat imageFormat;
                    public ImageRotationExtenstion(byte[] image,float degrees) 
                    {
                              SKBitmap bitmap = LoadImageToBitmap(image);
                              Debug.WriteLine("IMage Loaded");
                            SKBitmap rbitmap=RotateImage(bitmap,degrees);
                              Debug.WriteLine("Rimage ROtated");
                              Data=BitmapBytes(rbitmap);
                              Debug.WriteLine("IMage unloaded");
                          
                             
                             
                           
                             
                    }
                     byte[] BitmapBytes(SKBitmap bitmap) 

                    {
                               return bitmap.Encode(imageFormat, 100).ToArray();
                                                  
                                        
                              
                    }
                     SKBitmap LoadImageToBitmap(byte[] imageData)
                    {
                              using (MemoryStream stream = new MemoryStream(imageData))
                              {
                                        // Create an SKCodec from the stream
                                        SKCodec codec = SKCodec.Create(stream);
                                        imageFormat=codec.EncodedFormat;
                                       
                                        // Get information about the image
                                        SKImageInfo info = codec.Info;

                                        // Create an SKBitmap with the same information
                                        SKBitmap skBitmap = new SKBitmap(info);

                                        // Read the pixels from the stream into the SKBitmap
                                        SKCodecResult result = codec.GetPixels(skBitmap.Info, skBitmap.GetPixels());

                                        if (result == SKCodecResult.Success || result == SKCodecResult.IncompleteInput)
                                        {
                                                  IsImageLoaded = true;
                                                  return skBitmap;
                                        }
                                        else
                                        {
                                                  throw new InvalidOperationException("Failed to decode the image.");
                                        }
                              }
                    }
                     SKBitmap RotateImage(SKBitmap original, float degrees=90f)
                              {
                                        SKBitmap rotatedBitmap = new SKBitmap(original.Info);

                                        using (var canvas = new SKCanvas(rotatedBitmap))
                                        using (var paint = new SKPaint())
                                        {
                                                  canvas.Clear(SKColors.Transparent);
                                                  canvas.RotateDegrees(degrees, original.Width / 2f, original.Height / 2f);
                                                  canvas.DrawBitmap(original, 0, 0, paint);
                                        IsRotated = true;
                              }

                                        return rotatedBitmap;
                              }
                    
    }
}
