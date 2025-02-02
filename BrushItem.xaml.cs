using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VisualStudioExtensionDesignGuidelines
{
    /// <summary>
    /// Interaction logic for BrushItem.xaml
    /// </summary>
    public partial class BrushItem : UserControl
    {
        static string ToHex(byte value)
        {
            return String.Format("{0:X}", value);
        }
        string m_key;
        public string Key 
        {
            get => m_key;
            set
            {
                m_key = value;
                Rect.SetResourceReference(Shape.FillProperty, m_key);
                ColorName.Text = m_key;
                try
                {
                    var color = ((SolidColorBrush)Rect.Fill).Color;
                    ColorNameTip.Content = $"{color.R},{color.G},{color.B}\n#{ToHex(color.R)}{ToHex(color.G)}{ToHex(color.B)}";
                }
                catch { }
            }
        }

        public BrushItem()
        {
            InitializeComponent();
        }

        private static MainFrame tryGetMainFrame(DependencyObject dp)
        {
            var tryAsMainFrame = dp as MainFrame;
            if(tryAsMainFrame == null)
            {
                return tryGetMainFrame(VisualTreeHelper.GetParent(dp));
            }
            return tryAsMainFrame;
        }

        private void CopyNameItem_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(Key);


        }

        private void SetAsTextColorItem_Click(object sender, RoutedEventArgs e)
        {
            tryGetMainFrame(this).SetTextColor(Key);
        }

        private void SetAsBackgroundColorItem_Click(object sender, RoutedEventArgs e)
        {
            tryGetMainFrame(this).SetBackgroundColor(Key);
        }
    }
}