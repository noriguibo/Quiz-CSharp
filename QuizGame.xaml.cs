using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Quiz_ALG.Objects;
using System.Data.SQLite;
using System.Windows.Threading;
using System.Threading;

namespace Quiz_ALG
{
    /// <summary>
    /// Lógica interna para Quiz.xaml
    /// </summary>
    public partial class QuizGame : Window
    {
        //Declaração das variáveis
        int points = 0, selectedanswer = -1, currentquestion = 0, t = -1, dottimer = 0, t2 = -1;
        string dot = "";
        List<Quiz_Data> Quiz = new List<Quiz_Data>();
        List<Statement_Data> Statement = new List<Statement_Data>();
        List<Answer_Data> Answer = new List<Answer_Data>();

        DispatcherTimer newTimer = new DispatcherTimer();
        DispatcherTimer startTimer = new DispatcherTimer();

        //Inicializar janela do jogo (Quiz)
        public QuizGame(List<Quiz_Data> QuizE, List<Statement_Data> StatementE, List<Answer_Data> AnswerE, string quizname, int timer)
        {
            InitializeComponent();

            int i;

            for (i = 0; i < QuizE.Count; i++)
                Quiz.Add(new Quiz_Data { QuestionID = QuizE[i].QuestionID, CorrectAnswer = QuizE[i].CorrectAnswer });

            for (i = 0; i < StatementE.Count; i++)
                Statement.Add(new Statement_Data { Statement = StatementE[i].Statement, FontSize = StatementE[i].FontSize });

            for (i = 0; i < AnswerE.Count; i++)
                Answer.Add(new Answer_Data { AnswerID = AnswerE[i].AnswerID, Answer = AnswerE[i].Answer, FontSize = AnswerE[i].FontSize });

            lbLogo.Content = "QUIZ - " + quizname;

            if(timer <= 300)
            {
                this.t = timer;
                this.t2 = timer;
            }

            startTimer.Interval = TimeSpan.FromSeconds(1);
            startTimer.Tick += OnStartTimerTick;
            startTimer.Start();
        }

        /* Evento: Botões de...
         * btMinimize - Minimizar
         * btClose - Fechar
         * */
        private void btTitle_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btMinimize))
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (sender.Equals(btClose))
            {
                Environment.Exit(0);
            }
        }

        /* Função utilizada para:
         * - Executar função a cada 1 segundo quando, chamado pelo timer quando o jogo é inicializado
         */
        void OnTimerTick(Object sender, EventArgs args)
        {
            lbTitle.Content = "Boa sorte!         Tempo Restante: " + t + "s";
            if (t == 0)
            {
                currentquestion = 10;
                LastCall();
                newTimer.Stop();
            }
            t--;
        }

        /* Função utilizada para:
         * - Executar função a cada 1 segundo quando, chamado pelo Timer iniciado na inicialização da janela
         */
        void OnStartTimerTick(Object sender, EventArgs args)
        {
            if (dottimer == 3)
            {
                dottimer = 0;
                dot = "";
            }
            dottimer++;
            dot = dot + ".";
            lbTitle.Content = "Iniciando Quiz" + dot;
        }

        /* Evento: Botões de...
         *  btStart - Começar Quiz
         *  btConfirm - Confirmar Resposta
         *  btNextQuestion - Próxima Questão
         *  btRestart - Reiniciar Quiz
         *  btReturn - Retornar a Lista de Quiz (Janela Principal)
         * */
        private void btCommon_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btStart))
            {
                FirstQuestion();

                startTimer.Stop();

                if(t != -1)
                {
                    newTimer.Interval = TimeSpan.FromSeconds(1);
                    newTimer.Tick += OnTimerTick;
                    newTimer.Start();
                }
                else
                {
                    lbTitle.Content = "Boa sorte!         Tempo Restante: ∞";
                }
            }
            else if (sender.Equals(btConfirm))
            {
                if (selectedanswer != -1)
                    CheckAnswer();
            }
            else if (sender.Equals(btNextQuestion))
            {
                if (currentquestion < 10)
                {
                    NextQuestion();
                    selectedanswer = -1;
                    Dummy.Focus();
                    btAnswerHandler(0);
                }
                else
                {
                    LastCall();
                    newTimer.Stop();
                }
            }
            else if (sender.Equals(btRestart))
            {
                RestartQuiz();
            }
            else if (sender.Equals(btReturn) || sender.Equals(btReturntoQuizSelect))
            {
                ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                this.Close();
            }
        }

        // Evento: Botões de seleção de resposta
        private void btAnswer_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(bt1stAnswer))
            {
                selectedanswer = 0;
            }
            else if (sender.Equals(bt2ndAnswer))
            {
                selectedanswer = 1;
            }
            else if (sender.Equals(bt3rdAnswer))
            {
                selectedanswer = 2;
            }
            else if (sender.Equals(bt4thAnswer))
            {
                selectedanswer = 3;
            }
        }

        //Começar o jogo! Embaralhar Quiz e esconder/mostrar botões necessários
        private void FirstQuestion()
        {
            Quiz.Shuffle();

            btStart.Visibility = Visibility.Hidden;
            lbLogo.Visibility = Visibility.Hidden;
            btReturn.Visibility = Visibility.Hidden;

            btConfirm.Visibility = Visibility.Visible;

            bt1stAnswer.Visibility = Visibility.Visible;
            bt2ndAnswer.Visibility = Visibility.Visible;
            bt3rdAnswer.Visibility = Visibility.Visible;
            bt4thAnswer.Visibility = Visibility.Visible;

            lbProgress.Visibility = Visibility.Visible;
            lbQuestion.Visibility = Visibility.Visible;
            lbGridBorder.Visibility = Visibility.Visible;

            stateblock.Visibility = Visibility.Visible;
            lbBorder.Visibility = Visibility.Visible;

            NextQuestion();
        }

        //Finalizar Quiz e apresentar a quantidade de respostas certas
        private void LastCall()
        {
            btConfirm.Visibility = Visibility.Hidden;
            btNextQuestion.Visibility = Visibility.Hidden;

            bt1stAnswer.Visibility = Visibility.Hidden;
            bt2ndAnswer.Visibility = Visibility.Hidden;
            bt3rdAnswer.Visibility = Visibility.Hidden;
            bt4thAnswer.Visibility = Visibility.Hidden;

            lbProgress.Visibility = Visibility.Hidden;
            lbQuestion.Visibility = Visibility.Hidden;
            lbGridBorder.Visibility = Visibility.Hidden;

            stateblock.Visibility = Visibility.Hidden;
            lbBorder.Visibility = Visibility.Hidden;

            imgc.Visibility = Visibility.Hidden;
            imgi.Visibility = Visibility.Hidden;

            btRestart.Visibility = Visibility.Visible;
            lbLast.Visibility = Visibility.Visible;
            btReturntoQuizSelect.Visibility = Visibility.Visible;

            if (points == 0)
            {
                lbLast.Content = "VOCÊ NÃO ACERTOU NENHUMA QUESTÃO...";
            }
            else
            {
                lbLast.Content = "VOCÊ ACERTOU [ " + points + " ] QUEST" + (points == 1 ? "ÃO!" : "ÕES!");
            }

        }

        //Reiniciar Quiz - Reembaralhar o Quiz e repetir o processo do início
        private void RestartQuiz()
        {
            selectedanswer = -1;
            currentquestion = 0;
            points = 0;

            Quiz.Shuffle();

            btConfirm.Visibility = Visibility.Visible;

            bt1stAnswer.Visibility = Visibility.Visible;
            bt2ndAnswer.Visibility = Visibility.Visible;
            bt3rdAnswer.Visibility = Visibility.Visible;
            bt4thAnswer.Visibility = Visibility.Visible;

            lbProgress.Visibility = Visibility.Visible;
            lbQuestion.Visibility = Visibility.Visible;
            lbGridBorder.Visibility = Visibility.Visible;

            stateblock.Visibility = Visibility.Visible;
            lbBorder.Visibility = Visibility.Visible;

            btRestart.Visibility = Visibility.Hidden;
            lbLast.Visibility = Visibility.Hidden;
            btReturntoQuizSelect.Visibility = Visibility.Hidden;

            Dummy.Focus();
            btAnswerHandler(0);

            if (t2 != -1)
            {
                t = t2;
                newTimer.Start();
            }

            NextQuestion();
        }

        //Puxar próxima questão da Lista de questões
        private void NextQuestion()
        {
            bt1stAnswer.Content = Answer[(4 * (Quiz[currentquestion].QuestionID - 1))].Answer;
            bt1stAnswer.FontSize = Answer[(4 * (Quiz[currentquestion].QuestionID - 1))].FontSize;

            bt2ndAnswer.Content = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 1].Answer;
            bt2ndAnswer.FontSize = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 1].FontSize;

            bt3rdAnswer.Content = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 2].Answer;
            bt3rdAnswer.FontSize = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 2].FontSize;

            bt4thAnswer.Content = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 3].Answer;
            bt4thAnswer.FontSize = Answer[(4 * (Quiz[currentquestion].QuestionID - 1)) + 3].FontSize;

            stateblock.Text = Statement[(Quiz[currentquestion].QuestionID - 1)].Statement;
            stateblock.FontSize = Statement[(Quiz[currentquestion].QuestionID - 1)].FontSize;

            currentquestion++;
            lbProgress.Content = currentquestion + " / 10";

            imgc.Visibility = Visibility.Hidden;
            imgi.Visibility = Visibility.Hidden;
        }

        //Checar se a resposta está certa
        private void CheckAnswer()
        {
            if (selectedanswer == Quiz[currentquestion - 1].CorrectAnswer)
            {
                imgc.Visibility = Visibility.Visible;
                imgi.Visibility = Visibility.Hidden;
                points++;
            }
            else
            {
                imgc.Visibility = Visibility.Hidden;
                imgi.Visibility = Visibility.Visible;
            }

            btAnswerHandler(1);
        }

        //Trancar interação com os botões de respostas (Já que o usuário confirmou a resposta)
        private void btAnswerHandler(int i)
        {
            if (i == 1)
            {
                bt1stAnswer.IsEnabled = false;
                bt2ndAnswer.IsEnabled = false;
                bt3rdAnswer.IsEnabled = false;
                bt4thAnswer.IsEnabled = false;

                btConfirm.Visibility = Visibility.Hidden;
                btNextQuestion.Visibility = Visibility.Visible;
            }
            else
            {
                bt1stAnswer.IsEnabled = true;
                bt2ndAnswer.IsEnabled = true;
                bt3rdAnswer.IsEnabled = true;
                bt4thAnswer.IsEnabled = true;

                btConfirm.Visibility = Visibility.Visible;
                btNextQuestion.Visibility = Visibility.Hidden;
            }
        }

        /* Função utilizada para:
         * - Alterar a função do clique com botão Esquerdo do mouse na janela
         */
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }
    }

    // Algoritmo Fisher-Yates, usado para embaralhar uma sequência sem haver duplicatas
    static class FisherYatesShuffle
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> values)
        {
            for (int i = values.Count - 1; i > 0; i--)
            {
                int k = rng.Next(i + 1);
                T value = values[k];
                values[k] = values[i];
                values[i] = value;
            }
        }
    }
}
