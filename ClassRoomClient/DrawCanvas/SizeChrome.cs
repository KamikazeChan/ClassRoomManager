using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ClassRoom.DrawCanvas
{
    public class SizeChrome : Control
    {
        static SizeChrome()
        {
            FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(SizeChrome), new FrameworkPropertyMetadata(typeof(SizeChrome)));
        }
    }  
}
