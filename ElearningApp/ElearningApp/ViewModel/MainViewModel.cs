using ElearningApp.Model;
using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private GuideRepository guideRepo = new GuideRepository();
        public ObservableCollection<GuideViewModel> GuidesVM { get; set; } = new();
        private GuideViewModel guideViewModel;
        public GuideViewModel SelectedGuideVM
        {
            get { return guideViewModel; }
            set { guideViewModel = value; OnPropertyChanged("SelectedGuideVM"); }
        }

        public MainViewModel()
        {
            foreach (Guide guide in guideRepo.GetAll())
            {
                GuideViewModel guideVM = new (guide);
                GuidesVM.Add(guideVM);
            }
        }

        public MainViewModel(string guideCategory)
        {
            foreach (Guide guide in guideRepo.GetAll())
            {
                GuideViewModel guideVM = new(guide);
                if (guideVM.Category == guideCategory)
                {
                    GuidesVM.Add(guideVM);
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
