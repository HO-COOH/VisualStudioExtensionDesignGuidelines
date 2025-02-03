using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using Microsoft.VisualStudio.PlatformUI;
using static Microsoft.VisualStudio.Shell.RegistrationAttribute;

namespace VisualStudioExtensionDesignGuidelines
{
    /// <summary>
    /// Interaction logic for ColorContrastChecker.xaml
    /// </summary>
    public partial class ColorContrastChecker : UserControl
    {
        public ColorContrastChecker()
        {
            InitializeComponent();
            VSColorTheme.ThemeChanged += VSColorTheme_ThemeChanged;
        }

        private void VSColorTheme_ThemeChanged(ThemeChangedEventArgs e)
        {
            updateCheckState();
        }

        void updateCheckState()
        {
            if (!(Color1.Fill is SolidColorBrush) || !(Color2.Fill is SolidColorBrush))
                return;

            var color1 = Application.Current.FindResource(ColorKey1) as SolidColorBrush;
            var color2 = Application.Current.FindResource(ColorKey2) as SolidColorBrush;
            var ratio = ColorContrast.CalculateContrastRatio(color1.Color, color2.Color);
            ColorContrastRatioText.Text = Math.Round(ratio, 2) + ":1";

            VisualStateManager.GoToState(
                this,
                ratio >= 4.5 ? "NormalTextCheckPassState" : "NormalTextCheckFailState",
                false);

            VisualStateManager.GoToState(
                this,
                ratio >= 3.0 ? "LargeTextCheckPassState" : "LargeTextCheckFailState",
                false);

            VisualStateManager.GoToState(
                this,
                ratio >= 3.0 ? "GraphicalObjectCheckPassState" : "GraphicalObjectCheckFailState",
                false);
        }

        string m_colorKey1;
        string m_colorKey2;

        public string ColorKey1
        {
            get => m_colorKey1;
            set
            {
                m_colorKey1 = value;
                Color1.SetResourceReference(Shape.FillProperty, value);
                updateCheckState();
            }
        }

        public string ColorKey2
        {
            get => m_colorKey2;
            set
            {
                m_colorKey2 = value;
                Color2.SetResourceReference(Shape.FillProperty, value);
                updateCheckState();
            }
        }

        private void NormalTextCheckEllipse_Loaded(object sender, RoutedEventArgs e)
        {
            var result = VisualStateManager.GoToState(this, "MyState", false);
            Debug.WriteLine(result);
        }
    }
}
