using System.ComponentModel;
using ControlSystemMessage.iOS.CustomRenderers;
using ControlSystemMessage.Views.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(PickerRendererIOS))]
namespace ControlSystemMessage.iOS.CustomRenderers
{
    public class PickerRendererIOS : PickerRenderer
    {
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}