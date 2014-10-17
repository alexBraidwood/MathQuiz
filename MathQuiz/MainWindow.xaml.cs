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

namespace MathQuiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            switch (button.Name)
            {
                case "OneButton":
                    updateNewBoxText("1");
                    break;
                case "TwoButton":
                    updateNewBoxText("2");
                    break;
                case "ThreeButton":
                    updateNewBoxText("3");
                    break;
                case "FourButton":
                    updateNewBoxText("4");
                    break;
                case "FiveButton":
                    updateNewBoxText("5");
                    break;
                case "SixButton":
                    updateNewBoxText("6");
                    break;
                case "SevenButton":
                    updateNewBoxText("7");
                    break;
                case "EightButton":
                    updateNewBoxText("8");
                    break;
                case "NineButton":
                    updateNewBoxText("9");
                    break;
                case "ZeroButton":
                    updateNewBoxText("0");
                    break;
            }
        }

        public void updateNewBoxText(string number)
        {
            if (!(number.Equals("0") && NumberBox.Text.Equals("0")))
            {
                NumberBox.Text = string.Concat(NumberBox.Text, number);
            }
        }
    }
}
