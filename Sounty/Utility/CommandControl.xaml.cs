using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sounty
{
    public partial class CommandControl : UserControl
    {
        public CommandControl()
        {
            InitializeComponent();
            this.MouseLeftButtonDown += this.ExecuteCommandIfPossible;
        }

        private void ExecuteCommandIfPossible(object sender, MouseButtonEventArgs eventArgs)
        {
            if (Command != null)
            {
                if (Command.CanExecute(CommandParameter))
                {
                    Command.Execute(CommandParameter);
                }
            }
        }

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command",
                                        typeof(ICommand),
                                        typeof(CommandControl),
                                        new PropertyMetadata(null));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value);           }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter",
                                        typeof(object),
                                        typeof(CommandControl),
                                        new PropertyMetadata(null));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value);         }
        }
    }
}