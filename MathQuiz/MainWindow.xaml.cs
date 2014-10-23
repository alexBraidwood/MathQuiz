using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
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
        private List<ProblemType> checkedTypes;
        
        private Quiz quiz;
        private IQuizzable currentProblem;
        private List<ProblemType> CheckedTypes
        {
            get
            {
                if (checkedTypes == null)
                {
                    checkedTypes = new List<ProblemType>();
                }
                return checkedTypes;
            }
            set
            {
                checkedTypes = value;
            }
        }


        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateNewBoxText(string number)
        {
            if (!(number.Equals("0") && NumberBox.Text.Equals("0")))
            {
                NumberBox.Text = string.Concat(NumberBox.Text, number);
            }
        }

        private void toggleInput(bool turnInputOn)
        {
            foreach (UIElement c in UserGrid.Children)
            {
                c.IsEnabled = turnInputOn;
            }
        }

        private void KeyPadButton_Click(object sender, RoutedEventArgs e)
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

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            this.NumberBox.Text = string.Empty;
            this.FeedbackBlock.Text = string.Empty;
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentProblem.IsSolution(decimal.Parse(NumberBox.Text)))
            {
                FeedbackBlock.Foreground = new SolidColorBrush(Color.FromRgb(0, 255, 46));
                FeedbackBlock.Text = "Correct!";
                NextButton.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                FeedbackBlock.Foreground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                FeedbackBlock.Text = "Try Again!";
            }
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (quiz.ProblemsLeft > 0)
            {
                FeedbackBlock.Text = string.Empty;
                this.NumberBox.Text = string.Empty;
                NextButton.Visibility = System.Windows.Visibility.Hidden;
                currentProblem = quiz.getNextProblem();
                EquationBlock.Text = currentProblem.Equation;
            }
            else
            {
                this.NextButton.Content = "Quiz Complete!";
                GeneratorPanel.Visibility = System.Windows.Visibility.Visible;
                toggleInput(false);
            }
        }

        private void MathBox_Checked(object sender, RoutedEventArgs e)
        {
            var checkbox = sender as CheckBox;
            ProblemType toggleType = ProblemType.None;

            switch (checkbox.Name)
            {
                case "addCheckBox":
                    toggleType = ProblemType.Addition;
                    break;
                case "subCheckBox":
                    toggleType = ProblemType.Subtraction;
                    break;
                case "divCheckBox":
                    toggleType = ProblemType.Division;
                    break;
                case "multCheckBox":
                    toggleType = ProblemType.Multiplication;
                    break;
            }

            if (toggleType == ProblemType.None)
                return;

            if (checkbox.IsChecked.Value == true)
            {
                CheckedTypes.Add(toggleType);
            }
            else
            {
                CheckedTypes.Remove(toggleType);
            }
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            GeneratorPanel.Visibility = Visibility.Hidden;
            quiz = new Quiz(int.Parse(AmountBox.Text), ProblemTypes: checkedTypes.ToArray());
            currentProblem = quiz.getNextProblem();
            EquationBlock.Text = currentProblem.Equation;
            NextButton.Visibility = System.Windows.Visibility.Hidden;
            toggleInput(true);
        }

        private void UserGrid_Loaded(object sender, RoutedEventArgs e)
        {
            toggleInput(false);
        }
    }
}
