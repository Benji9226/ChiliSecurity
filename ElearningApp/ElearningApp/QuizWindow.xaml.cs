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

namespace ElearningApp
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window
    {
        QuizViewModel qzw = new QuizViewModel();
        int correctAnswer;
        int questionNumber = 1;
        int score;
        int totalQuestions;

        public QuizWindow()
        {
            InitializeComponent();

            LoadQuiz(questionNumber);

            totalQuestions = 2;
        }


        public void checkAnswerEvent(object sender, EventArgs e) 
        {
            Button senderObject = sender as Button;


            if (Convert.ToInt32(senderObject.Tag)  == correctAnswer) 
            {
                questionNumber++;
                LoadQuiz(questionNumber);
            
            }
        }

       
        public void LoadQuiz(int qnum)
        {

            switch (qnum)
            {

                case 1:
                    Questionlbl.Content = "Question 1";

                    Answerbtn1.Content = "Answer 1";
                    Answerbtn2.Content = "Answer 1";
                    Answerbtn3.Content = "Answer 1";
                    Answerbtn4.Content = "Answer 1";

                    Answerbtn1.Tag = 1;

                    correctAnswer = (int)Answerbtn1.Tag;

                    break;
                case 2:
                    Questionlbl.Content = "Question 2";

                    Answerbtn1.Content = "Answer 2";
                    Answerbtn2.Content = "Answer 2";
                    Answerbtn3.Content = "Answer 2";
                    Answerbtn4.Content = "Answer 2";

                    Answerbtn1.Tag = 2;

                    correctAnswer = (int)Answerbtn1.Tag;

                    break;
            }

        }

        private void Answerbtn1_Click(object sender, RoutedEventArgs e)
        {
            checkAnswerEvent(sender, new EventArgs());
        }
        private void Answerbtn2_Click(object sender, RoutedEventArgs e)
        {
            checkAnswerEvent(sender, new EventArgs());
        }
        private void Answerbtn3_Click(object sender, RoutedEventArgs e)
        {
            checkAnswerEvent(sender, new EventArgs());
        }
        private void Answerbtn4_Click(object sender, RoutedEventArgs e)
        {
            checkAnswerEvent(sender, new EventArgs());
        }

    }
}
