using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace Sounty.View
{
    public partial class PlayerView : UserControl
    {
        public PlayerView()
        {
            InitializeComponent();
        }

        private void SeekBarDragStarted(object sender, DragStartedEventArgs eventArgs)
        {
            if (DataContext is ViewModel.PlayerViewModel)
            {
                (DataContext as ViewModel.PlayerViewModel).SeekBarDragStarted();
            }
        }

        private void SeerkBarDragCompleted(object sender, DragCompletedEventArgs eventArgs)
        {
            if (DataContext is ViewModel.PlayerViewModel)
            {
                (DataContext as ViewModel.PlayerViewModel).SeekBarDragCompleted();
            }
        }
    }
}
