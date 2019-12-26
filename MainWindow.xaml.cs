using ContactBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
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

namespace ContactBook
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeViewModel();
            GenerateLetters();
        }

        protected void InitializeViewModel()
        {
            AppViewModel viewModel = DataContext as AppViewModel;
            viewModel.BookVm.LoadDataContact();

            var textInput = Observable.FromEventPattern<TextChangedEventHandler, TextChangedEventArgs>(
                h => QueryInput.TextChanged += h, h => QueryInput.TextChanged -= h);

            var textQuery =
                from evt in textInput
                let obj = evt.Sender as TextBox
                let text = obj.Text
                select text;

            textQuery.Subscribe(o =>
            {
                this.SetSearchQueryAndLoad(viewModel, o);
            });
        }

        public void SetSearchQueryAndLoad(AppViewModel viewModel, string text)
        {
            viewModel.BookVm.SearchQuery = text;
            viewModel.BookVm.LoadDataContact();
        }

        protected void GenerateLetters()
        {
            for (char letterFirst = 'A', letterLast = 'Z', i = letterFirst; i <= letterLast; ++i)
            {
                var definition = new ColumnDefinition();
                definition.Width = new GridLength(1, GridUnitType.Star);
                AlphabeticGrid.ColumnDefinitions.Add(definition);

                var button = new Button();
                button.Content = i;

                Style default_style = new Style();
                default_style.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.Gray) });
                button.Style = default_style;

                button.Name = "Index" + i;
                Grid.SetColumn(button, i - letterFirst);

                AlphabeticGrid.Children.Add(button);

                var buttonClick = Observable.FromEventPattern<RoutedEventHandler, RoutedEventArgs>(h => button.Click += h, h => button.Click -= h);

                AppViewModel viewModel = DataContext as AppViewModel;

                Style selected = new Style();
                selected.Setters.Add(new Setter { Property = Control.BackgroundProperty, Value = new SolidColorBrush(Colors.White) });

                buttonClick.Subscribe(arg =>
                {
                    Button but = arg.Sender as Button;
                    if (but == null)
                        return;
                    if (viewModel.BookVm.CurLetterButton != null)
                    {
                        if (viewModel.BookVm.CurLetter == but.Content.ToString().ToLower())
                        {
                            viewModel.BookVm.CurLetter = "";
                            viewModel.BookVm.CurLetterButton.Style = default_style;
                        }
                        else
                        {
                            viewModel.BookVm.CurLetter = but.Content.ToString().ToLower();
                            viewModel.BookVm.CurLetterButton.Style = default_style;

                            but.Style = selected;
                            viewModel.BookVm.CurLetterButton = but;
                        }
                    }
                    else
                    {
                        viewModel.BookVm.CurLetter = but.Content.ToString().ToLower();
                        viewModel.BookVm.CurLetterButton = but;
                        viewModel.BookVm.CurLetterButton.Style = selected;
                    }
                    viewModel.BookVm.LoadDataContact();
                });
            }
        }

    }
}
