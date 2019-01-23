namespace Sounty.ViewModel
{
    public class ConcertsViewModel : ViewModelBase
    {
        private string day;
        private string month;
        private string location;

        public string Day
        {
            get => day;
            set
            {
                day = value;
                OnPropertyChanged("Day");
            }
        }

        public string Month
        {
            get => month;
            set
            {
                month = value;
                OnPropertyChanged("Month");
            }
        }

        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged("Location");
            }
        }
        
        public ConcertsViewModel()
        {
            
        }
    }
}
