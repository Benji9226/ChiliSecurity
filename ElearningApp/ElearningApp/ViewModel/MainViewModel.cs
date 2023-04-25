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
        private QuizRepository quizRepo = new QuizRepository();
        public ObservableCollection<GuideViewModel> GuidesVM { get; set; } = new();
        public ObservableCollection<QuizViewModel> QuizzesVM { get; set; } = new();

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

            foreach (Quiz quiz in quizRepo.GetQuizzesByCategory(guideCategory))
            {
                QuizViewModel quizVM = new(quiz);
                QuizzesVM.Add(quizVM);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null) { propertyChanged(this, new PropertyChangedEventArgs(propertyName)); }
        }
    }
}
