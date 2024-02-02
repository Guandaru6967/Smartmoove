using CommunityToolkit.Mvvm.ComponentModel;
using Smartmoveapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Smartmoveapp.ViewModels
{
          public class ImageObject
          {
                    public byte[] ImageData { get; set; } = Array.Empty<byte>();
                    public string Id { get; set; } = string.Empty;
                    public DateTime TimeTaken { get; set; } = DateTime.MinValue;
          }
          public partial class ScanningPageViewModel:ObservableObject
          {
                    [ObservableProperty]
                    List<ImageObject> images=new List<ImageObject>();
                    [ObservableProperty]
                    Folder folder = null;
                    [ObservableProperty]
                    bool isSinglePhoto = true;
          }
}
