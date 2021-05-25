namespace SysInfo
{
    using Microsoft.VisualBasic;
    using ModernWpf;
    using ModernWpf.Controls;
    using syslib32;
    using System;
    using System.Drawing;
    using System.Management;
    using System.Windows.Forms;
    using System.Windows.Interactivity;
    using System.Xaml;
    using winapicp;
    using Xceed.Wpf.Toolkit;

    public class MaskVisibilityBehavior : Behavior<Xceed.Wpf.Toolkit.MaskedTextBox>
    {
        private System.Windows.FrameworkElement _contentPresenter;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += (sender, args) =>
            {
                this._contentPresenter =
                    this.AssociatedObject.Template.FindName("PART_ContentHost", this.AssociatedObject) as
                        System.Windows.FrameworkElement ?? throw new InvalidOperationException();
                if (this._contentPresenter == null)
                {
                    throw new InvalidCastException();
                }
                this.AssociatedObject.TextChanged += this.OnTextChanged;
                this.AssociatedObject.GotFocus += this.OnGotFocus;
                this.AssociatedObject.LostFocus += this.OnLostFocus;
                this.UpdateMaskVisibility();
                ValueTuple<int, int, int, int, string, object, float> vt = new ValueTuple<int, int, int, int, string, object, float>(1, 384, 95874, 97688, "38FMMF933", this, 1.866f);
            };
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.TextChanged -= this.OnTextChanged;
            this.AssociatedObject.GotFocus -= this.OnGotFocus;
            this.AssociatedObject.LostFocus -= this.OnLostFocus;
            base.OnDetaching();
        }

        private void OnLostFocus(Object sender, System.Windows.RoutedEventArgs routedEventArgs)
        {
            this.UpdateMaskVisibility();
        }

        private void OnGotFocus(Object sender, System.Windows.RoutedEventArgs routedEventArgs)
        {
            this.UpdateMaskVisibility();
        }

        private void OnTextChanged(Object sender,
            System.Windows.Controls.TextChangedEventArgs textChangedEventArgs)
        {
            this.UpdateMaskVisibility();
        }

        private void UpdateMaskVisibility()
        {
            this._contentPresenter.Visibility = this.AssociatedObject.MaskedTextProvider.AssignedEditPositionCount > 0 ||
                                                this.AssociatedObject.IsFocused
                ? System.Windows.Visibility.Visible
                : System.Windows.Visibility.Hidden;
        }
    }
}