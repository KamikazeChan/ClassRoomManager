using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClassRoom.UserControls
{
    /// <summary>
    /// EditTextBox.xaml 的交互逻辑
    /// </summary>
    public partial class EditTextBox : UserControl
    {
        public EditTextBox()
        {
            InitializeComponent();
        }

        private void body_SelectionChanged(object sender, RoutedEventArgs e)
        {
            SynchronizeWith(rtbBody.Selection);
        }

        private void TextEditorToolbar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (IsSynchronizing) return;

            ComboBox source = e.OriginalSource as ComboBox;
            if (source == null) return;

            switch (source.Name)
            {
                case "fonts":
                    ApplyToSelection(TextBlock.FontFamilyProperty, source.SelectedItem);
                    break;
                case "fontSize":
                    ApplyToSelection(TextBlock.FontSizeProperty, source.SelectedItem);
                    break;
            }

            rtbBody.Focus();
        }

        public void ApplyToSelection(DependencyProperty property, object value)
        {
            if (value != null)
                rtbBody.Selection.ApplyPropertyValue(property, value);
        }

        #region 工具栏事件
        public bool IsSynchronizing { get; private set; }

        private void InitToolBar()
        {
            for (double i = 8; i < 48; i += 2)
            {
                fontSize.Items.Add(i);
            }
        }

        public void SynchronizeWith(TextSelection selection)
        {
            IsSynchronizing = true;

            Synchronize<double>(selection, TextBlock.FontSizeProperty, SetFontSize);
            Synchronize<FontWeight>(selection, TextBlock.FontWeightProperty, SetFontWeight);
            Synchronize<FontStyle>(selection, TextBlock.FontStyleProperty, SetFontStyle);
            Synchronize<TextDecorationCollection>(selection, TextBlock.TextDecorationsProperty, SetTextDecoration);
            Synchronize<FontFamily>(selection, TextBlock.FontFamilyProperty, SetFontFamily);

            IsSynchronizing = false;
        }

        private static void Synchronize<T>(TextSelection selection, DependencyProperty property, Action<T> methodToCall)
        {
            object value = selection.GetPropertyValue(property);
            if (value != DependencyProperty.UnsetValue) methodToCall((T)value);
        }

        private void SetFontSize(double size)
        {
            fontSize.SelectedValue = size;
        }

        private void SetFontWeight(FontWeight weight)
        {
            boldButton.IsChecked = weight == FontWeights.Bold;
        }

        private void SetFontStyle(FontStyle style)
        {
            italicButton.IsChecked = style == FontStyles.Italic;
        }

        private void SetTextDecoration(TextDecorationCollection decoration)
        {
            underlineButton.IsChecked = decoration == TextDecorations.Underline;
        }

        private void SetFontFamily(FontFamily family)
        {
            fonts.SelectedItem = family;
        }

        private void Image_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {

        }
        #endregion

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            InitToolBar();
        }
    }
}
