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
    public class MainViewModel
    {
        private GuideRepository guideRepo = new GuideRepository();
        public List<GuideViewModel> GuidesVM { get; set; } = new();
        private GuideViewModel guideViewModel;
        public GuideViewModel SelectedGuideVM
        {
            get { return guideViewModel; }
            set { guideViewModel = value; }
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
            var filteredGuides = guideRepo.GetAll().Where(guide => guide.Category == guideCategory);
            foreach (Guide guide in filteredGuides)
            {
                GuideViewModel guideVM = new(guide);
                GuidesVM.Add(guideVM);
            }
        }
    }
}
