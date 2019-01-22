namespace Sounty.ViewModel
{
    class AboutViewModel : ViewModelBase
    {
        public string Biography { get; }

        public AboutViewModel(string biography)
        {
            Biography = biography;
        }
    }
}
