using Sounty.Resources;
using Sounty.View;
using Sounty.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Sounty
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();

            IDialogService dialogService = new DialogService(MainWindow);
            dialogService.Register<EditPlaylistDialogViewModel, EditPlaylistDialogView>();
            dialogService.Register<PaySubscriptionDialogViewModel, PaySubscriptionView>();

            var viewModel = ApplicationViewModel.Instance;
            viewModel.dialogService = dialogService;

            /*
             // Create the ViewModel to which 
            // the main window binds.
            string path = "Data/customers.xml";
            var viewModel = new MainWindowViewModel(path);

            // When the ViewModel asks to be closed, 
            // close the window.
            EventHandler handler = null;
            handler = delegate
            {
                viewModel.RequestClose -= handler;
                window.Close();
            };
            viewModel.RequestClose += handler;
            */

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
