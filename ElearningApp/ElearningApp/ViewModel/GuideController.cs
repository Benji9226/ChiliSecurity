using ElearningApp.Persistence;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElearningApp.ViewModel
{
    public class GuideController
    {
        GuideRepository guideRepo = new GuideRepository();

        public void FindGuide(string name)
        {

        }

        public void LoadGuide(string guideName)
        {
            if (!File.Exists($@"Guides\{guideName}.pdf")) { guideRepo.CreateGuide(guideName); }
            Process.Start(new ProcessStartInfo($@"Guides\{guideName}.pdf") { UseShellExecute = true });
        }
    }
}
