using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Sounty.Model;

namespace Sounty.ViewModel
{
    class AboutViewModel : ViewModelBase
    {
        public string Biography { get; }

        public AboutViewModel(string biography, int artistId)
        {
            Biography = biography;

            FillConcerts(artistId);
        }

        void FillConcerts(int artistId)
        {
            try
            {
                using (var context = new DataAccess.SountyDB())
                {
                    var concerts = (from concertItem in context.Concerts
                                   where concertItem.artistId == artistId
                                   select concertItem);

                    foreach(var item in concerts)
                    {

                        var newConcert = new ConcertsViewModel();

                        DateTime date = item.dateConcert ?? DateTime.Now;
                        if(date != null)
                        {
                            DateTime dateAux = new DateTime(2010, date.Month, 1);

                            newConcert.Day = date.Day.ToString();
                            newConcert.Month = dateAux.ToString("MMMM").Substring(0,3).ToUpper();
                        }

                        newConcert.Location = item.locationConcert;

                        ConcertsList.Add(newConcert);
                    }

                }
            }
            catch (Exception e)
            {

            }
        }

        private ObservableCollection<ConcertsViewModel> concertsList;

        public ObservableCollection<ConcertsViewModel> ConcertsList
        {
            get
            {
                if (concertsList == null)
                    concertsList = new ObservableCollection<ConcertsViewModel>();

                return concertsList;
            }
            set
            {
                concertsList = value;
                OnPropertyChanged("ConcertsList");
            }
        }
    }
}
