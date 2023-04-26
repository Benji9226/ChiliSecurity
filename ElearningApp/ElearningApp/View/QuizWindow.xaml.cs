using ElearningApp.Model;
using ElearningApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ElearningApp.View
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        MainViewModel mvm = new MainViewModel();
        QuizViewModel qvm = new QuizViewModel();
        public QuizWindow(string category)
        {
            mvm = new MainViewModel(category);
            InitializeComponent();
            DataContext = mvm;
            LoadQuiz(category);
        }

        public void LoadQuiz(string category)
        {
            List<Quiz> quizList = qvm.GetQuiz(category);
            int i = 0;

            foreach(Quiz quiz in quizList)
            {
                quizLabel.Content = quiz.Title;
                answerOne.Content = quiz.Questions.ElementAt(i).PossibleAnswers[0];
                answerTwo.Content = quiz.Questions.ElementAt(i).PossibleAnswers[1];
                answerThree.Content = quiz.Questions.ElementAt(i).PossibleAnswers[2];
                answerFour.Content = quiz.Questions.ElementAt(i).PossibleAnswers[3];
                i++;
            }
        }
    }
}
