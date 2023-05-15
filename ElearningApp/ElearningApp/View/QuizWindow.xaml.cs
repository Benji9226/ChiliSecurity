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
        QuizViewModel qvm = new QuizViewModel();
        private Quiz quiz;
        private EmployeeViewModel selectedEmployee;
        private int currentQuestion = 0;
        private int correctAnswers = 0;

        public QuizWindow(string category, EmployeeViewModel selectedEmployee)
        {
            InitializeComponent();
            quiz = qvm.GetQuiz(category);
            this.selectedEmployee = selectedEmployee;
            StartQuiz();
        }

        private void StartQuiz()
        {
            LoadQuestion(currentQuestion);
        }

        private void LoadQuestion(int currentQuestion)
        {
            if (currentQuestion < quiz.Questions.Count)
            {
                correctAnswerCounter.Content = correctAnswers;
                questionNumber.Content = $"{currentQuestion + 1} / {quiz.Questions.Count}";
                quizLabel.Content = quiz.Questions.ElementAt(currentQuestion).Text;
                answerOne.Content = quiz.Questions.ElementAt(currentQuestion).PossibleAnswers[0];
                answerTwo.Content = quiz.Questions.ElementAt(currentQuestion).PossibleAnswers[1];
                answerThree.Content = quiz.Questions.ElementAt(currentQuestion).PossibleAnswers[2];
                answerFour.Content = quiz.Questions.ElementAt(currentQuestion).PossibleAnswers[3];
            }
            else
            {
                MessageBox.Show($"{selectedEmployee.FirstName} {selectedEmployee.LastName} you have completed the Quiz with {correctAnswers} / {quiz.Questions.Count} correct.");
                // If Employee got 100% correct
                if (correctAnswers == quiz.Questions.Count)
                {
                    selectedEmployee.AmountGuidesCompleted++;
                    selectedEmployee.UpdateEmployee();
                }
            }
        }

        private void Answer_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string userAnswer = clickedButton.Content.ToString();
            string correctAnswer = quiz.Questions.ElementAt(currentQuestion).CorrectAnswer;
            if (userAnswer == correctAnswer)
            {
                correctAnswers++;
            }
            currentQuestion++;
            LoadQuestion(currentQuestion);
        }
    }
}
