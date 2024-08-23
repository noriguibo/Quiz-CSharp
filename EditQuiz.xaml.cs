using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Data;
using System.Transactions;
using System.Linq;
using System.Windows.Threading;
using Npgsql;

namespace Quiz_ALG
{
    /// <summary>
    /// Lógica interna para EditQuiz.xaml
    /// </summary>
    public partial class EditQuiz : Window
    {
        //Inicialização das variáveis
        int selectedanswer = 1, first = 0, oldquestion, oldca, edit = 0, quizid, t = 0, tl, dbtype;
        string quizname, dot = "", tls = "";

        List<Quiz_Data> QuizE = new List<Quiz_Data>();
        List<Statement_Data> StatementE = new List<Statement_Data>();
        List<Answer_Data> AnswerE = new List<Answer_Data>();

        List<Quiz_Data> OldQuiz = new List<Quiz_Data>();
        List<Statement_Data> OldStatement = new List<Statement_Data>();
        List<Answer_Data> OldAnswer = new List<Answer_Data>();

        List<cbList> cbQuestions = new List<cbList>();
        List<cbList> cbCorrectAnswers = new List<cbList>();
        List<cbTimeLimits> cbTimerLimit = new List<cbTimeLimits>();

        DispatcherTimer newTimer = new DispatcherTimer();

        //Inicializar janela de Edição de Quiz
        public EditQuiz(List<Quiz_Data> Quiz, List<Statement_Data> Statement, List<Answer_Data> Answer, int newquiz, string quizname, int timelimit, int quizid, int dbtype)
        {
            InitializeComponent();

            int i;

            if (newquiz == 0)
            {
                for (i = 1; i <= 10; i++)
                    QuizE.Add(new Quiz_Data { QuestionID = i, CorrectAnswer = 0 });

                for (i = 1; i <= 10; i++)
                    StatementE.Add(new Statement_Data { Statement = "- - - - - -", FontSize = 20 });

                int c = 0;

                for (i = 1; i <= 40; i++)
                {
                    c = c >= 4 ? c = 1 : c+1;
                    AnswerE.Add(new Answer_Data { AnswerID = c, Answer = "- - - - - -", FontSize = 14 });
                }
                    
            }
            else
            {
                edit = 1;

                for (i = 0; i < Quiz.Count; i++)
                {
                    QuizE.Add(new Quiz_Data { QuestionID = Quiz[i].QuestionID, CorrectAnswer = Quiz[i].CorrectAnswer });
                    OldQuiz.Add(new Quiz_Data { QuestionID = Quiz[i].QuestionID, CorrectAnswer = Quiz[i].CorrectAnswer });
                }
                    

                for (i = 0; i < Statement.Count; i++)
                {
                    StatementE.Add(new Statement_Data { Statement = Statement[i].Statement, FontSize = Statement[i].FontSize });
                    OldStatement.Add(new Statement_Data { Statement = Statement[i].Statement, FontSize = Statement[i].FontSize });
                }
                    

                for (i = 0; i < Answer.Count; i++)
                {
                    AnswerE.Add(new Answer_Data { AnswerID = Answer[i].AnswerID, Answer = Answer[i].Answer, FontSize = Answer[i].FontSize });
                    OldAnswer.Add(new Answer_Data { AnswerID = Answer[i].AnswerID, Answer = Answer[i].Answer, FontSize = Answer[i].FontSize });
                }
            }

            for (i = 1; i <= 10; i++)
                cbQuestions.Add(new cbList { ID = i });

            for (i = 1; i <= 4; i++)
                cbCorrectAnswers.Add(new cbList { ID = i });

            for (i = 2; i < 12; i++)
            {
                if (i < 11)
                {
                    tls = (i / 2).ToString() + "m";
                    cbTimerLimit.Add(new cbTimeLimits { ID = ((i % 2) == 0 ? tls : tls + " 30s") });
                }
                else
                {
                    cbTimerLimit.Add(new cbTimeLimits { ID = "Ilimitado" });
                }
            }

            cbQuestion.ItemsSource = cbQuestions;
            cbCorrectAnswer.ItemsSource = cbCorrectAnswers;
            cbTimeLimit.ItemsSource = cbTimerLimit;

            this.tl = timelimit;
            this.quizid = quizid;
            this.quizname = quizname;
            this.dbtype = dbtype;

            tbQuizName.Text = quizname;

            cbQuestion.SelectedIndex = 0;
            cbCorrectAnswer.SelectedIndex = QuizE[0].CorrectAnswer;
            cbTimeLimit.SelectedIndex = (tl - 60) / 30;

            newTimer.Interval = TimeSpan.FromSeconds(1);
            newTimer.Tick += OnTimerTick;
            newTimer.Start();
        }

        /* Função utilizada para:
         * - Executar função a cada 1 segundo quando, chamado pelo Timer iniciado na inicialização da janela
         */
        void OnTimerTick(Object sender, EventArgs args)
        {
            if (t == 3)
            {
                t = 0;
                dot = "";
            }
            t++;
            dot = dot + ".";
            lbTitle.Content = "Editando Quiz" + dot;
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

        /* Evento: Botões de...
         *  bt1stAnswerE - Primeira Resposta
         *  bt2ndAnswerE - Segunda Resposta
         *  bt3rdAnswerE - Terceira Resposta
         *  bt4thAnswerE - Quarta Resposta
         * */
        private void btAnswerE_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(bt1stAnswerE))
            {
                selectedanswer = 1;
                tbAnswer1.Visibility = Visibility.Visible;
                tbAnswer2.Visibility = Visibility.Hidden;
                tbAnswer3.Visibility = Visibility.Hidden;
                tbAnswer4.Visibility = Visibility.Hidden;

                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => tbAnswer1.Focus()));
                tbAnswer1.CaretIndex = tbAnswer1.Text.Length;
            }
            else if (sender.Equals(bt2ndAnswerE))
            {
                selectedanswer = 2;
                tbAnswer1.Visibility = Visibility.Hidden;
                tbAnswer2.Visibility = Visibility.Visible;
                tbAnswer3.Visibility = Visibility.Hidden;
                tbAnswer4.Visibility = Visibility.Hidden;

                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => tbAnswer2.Focus()));
                tbAnswer2.CaretIndex = tbAnswer2.Text.Length;
            }
            else if (sender.Equals(bt3rdAnswerE))
            {
                selectedanswer = 3;
                tbAnswer1.Visibility = Visibility.Hidden;
                tbAnswer2.Visibility = Visibility.Hidden;
                tbAnswer3.Visibility = Visibility.Visible;
                tbAnswer4.Visibility = Visibility.Hidden;

                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => tbAnswer3.Focus()));
                tbAnswer3.CaretIndex = tbAnswer3.Text.Length;
            }
            else if (sender.Equals(bt4thAnswerE))
            {
                selectedanswer = 4;
                tbAnswer1.Visibility = Visibility.Hidden;
                tbAnswer2.Visibility = Visibility.Hidden;
                tbAnswer3.Visibility = Visibility.Hidden;
                tbAnswer4.Visibility = Visibility.Visible;

                Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => tbAnswer4.Focus()));
                tbAnswer4.CaretIndex = tbAnswer4.Text.Length;
            }

            tblAnswer.Text = "Resposta " + selectedanswer + ":";
        }

        /* Evento: Botões de...
         *  btReturnQuiz - Retornar
         *  btSaveQuiz - Salvar
         * */
        private void btCommonE_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btReturnQuiz))
            {
                if (MessageBox.Show("Deseja retornar a janela de seleção de quiz?", "Confirmação", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                    this.Close();
                }
            }
            else if (sender.Equals(btSaveQuiz))
            {
                ForceSave();
                SaveQuiz();
            }
        }

        /* Função utilizada para:
         * - Forçar o salvamento da pergunta caso o usuário não troque entre as perguntas.
         */
        private void ForceSave()
        {
            cbList cbquest = cbQuestion.SelectedItem as cbList;
            cbList cbca = cbCorrectAnswer.SelectedItem as cbList;

            int i = cbquest.ID - 1;

            QuizE[i].CorrectAnswer = cbca.ID - 1;

            StatementE[i].Statement = tbStatement.Text;

            AnswerE[4 * i].Answer = tbAnswer1.Text;
            AnswerE[(4 * i) + 1].Answer = tbAnswer2.Text;
            AnswerE[(4 * i) + 2].Answer = tbAnswer3.Text;
            AnswerE[(4 * i) + 3].Answer = tbAnswer4.Text;

        }

        /* Função utilizada para:
         *  - Salvar Quiz no Database
         */
        private void SaveQuiz()
        {
            int i, c, alt = 0, msg = 0, editqn = 0, edittl = 0;
            int[] editsta = new int[StatementE.Count];
            int[] editans = new int[AnswerE.Count];
            int[] editca = new int[QuizE.Count];
            int tle = 30 + ((cbTimeLimit.SelectedIndex + 1) * 30);

            //Checar se há erros ou há edições no Quiz
            for (i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        //Checar perguntas
                        for (c = 0; c < StatementE.Count; c++)
                        {
                            if (edit == 0 && StatementE[c].Statement == "- - - - - -")
                            {
                                msg = 1;
                                break;
                            }
                            if (edit == 1 && (StatementE[c].Statement != OldStatement[c].Statement))
                            {
                                editsta[c] = 1;
                                alt++;
                            }
                        }
                        break;
                    case 1:
                        //Checar respostas
                        for (c = 0; c < AnswerE.Count; c++)
                        {
                            if (edit == 0 && AnswerE[c].Answer == "- - - - - -")
                            {
                                msg = 2;
                                break;
                            }
                            if (edit == 1 && (AnswerE[c].Answer != OldAnswer[c].Answer))
                            {
                                editans[c] = 1;
                                alt++;
                            }
                        }
                        break;
                    case 2:
                        //Checar perguntas corretas
                        for (c = 0; c < QuizE.Count; c++)
                        {
                            if (edit == 0 && QuizE[c].CorrectAnswer < 0 || QuizE[c].CorrectAnswer > 3)
                            {
                                msg = 3;
                                break;
                            }
                            if (edit == 1 && (QuizE[c].CorrectAnswer != OldQuiz[c].CorrectAnswer))
                            {
                                editca[c] = 1;
                                alt++;
                            }
                        }
                        break;
                    case 3:
                        //Checar nome do quiz
                        if (edit == 0 && tblQuizName.Text == "- - - - - -")
                            msg = 4;
                        else if (edit == 1 && (quizname != tbQuizName.Text))
                        {
                            editqn = 1;
                            alt++;
                        }
                        break;
                    case 4:
                        //Checar tempo limite
                        if (edit == 1 && (tle != tl))
                        {
                            edittl = 1;
                            alt++;
                        }
                        break;
                }
            }
            //Usuário tentou salvar o quiz sem executar mudanças?
            if (edit == 1 && alt == 0)
            {
                msg = 5;
            }
            switch (msg)
            {
                case 0:
                    switch (dbtype)
                    {
                        case 0:
                            var connStringSqlite = "Data Source = quiz.db";

                            var connectionSqlite = new SQLiteConnection(connStringSqlite);

                            try
                            {
                                connectionSqlite.Open();
                                if (edit == 1)
                                {
                                    using (var transactionSqlite = connectionSqlite.BeginTransaction())
                                    {
                                        var commandSqlite = connectionSqlite.CreateCommand();

                                        commandSqlite.CommandText = "UPDATE quiz SET name=@name WHERE quizid=@quizid";

                                        if (editqn == 1)
                                        {
                                            commandSqlite.Parameters.AddWithValue("@name", tbQuizName.Text);
                                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                            commandSqlite.ExecuteNonQuery();
                                        }

                                        commandSqlite.CommandText = "UPDATE correctanswer SET correctanswer=@ca WHERE quizid=@quizid AND questionid=@questid";

                                        for (i = 0; i < QuizE.Count; i++)
                                        {
                                            if (editca[i] == 1)
                                            {
                                                commandSqlite.Parameters.AddWithValue("@ca", QuizE[i].CorrectAnswer);
                                                commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                                commandSqlite.Parameters.AddWithValue("@questid", i + 1);
                                                commandSqlite.ExecuteNonQuery();
                                            }
                                        }

                                        commandSqlite.CommandText = "UPDATE statement SET statement=@name WHERE quizid=@quizid AND questionid=@questid";

                                        for (i = 0; i < StatementE.Count; i++)
                                        {
                                            if (editsta[i] == 1)
                                            {
                                                commandSqlite.Parameters.AddWithValue("@name", StatementE[i].Statement);
                                                commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                                commandSqlite.Parameters.AddWithValue("@questid", i + 1);
                                                commandSqlite.ExecuteNonQuery();
                                            }
                                        }

                                        commandSqlite.CommandText = "UPDATE answer SET answer=@name WHERE quizid=@quizid AND questionid=@questid AND answerid=@answerid";

                                        for (i = 0; i < AnswerE.Count; i++)
                                        {
                                            if (editans[i] == 1)
                                            {
                                                commandSqlite.Parameters.AddWithValue("@name", AnswerE[i].Answer);
                                                commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                                commandSqlite.Parameters.AddWithValue("@questid", (i / 4) + 1);
                                                commandSqlite.Parameters.AddWithValue("@answerid", AnswerE[i].AnswerID);
                                                commandSqlite.ExecuteNonQuery();
                                            }
                                        }

                                        commandSqlite.CommandText = "UPDATE quiz SET timelimit=@tl WHERE quizid=@quizid";

                                        if (edittl == 1)
                                        {
                                            commandSqlite.Parameters.AddWithValue("@tl", tle);
                                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                            commandSqlite.ExecuteNonQuery();
                                        }

                                        try
                                        {
                                            transactionSqlite.Commit();
                                            if (MessageBox.Show("Alterações no Quiz feitas com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                                            {
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).GetQuizList();
                                                this.Close();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            transactionSqlite.Rollback();
                                            MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    using (var transactionSqlite = connectionSqlite.BeginTransaction())
                                    {
                                        var commandSqlite = connectionSqlite.CreateCommand();

                                        commandSqlite.CommandText = "INSERT INTO quiz VALUES (@quizid, @name, @tl)";

                                        commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                        commandSqlite.Parameters.AddWithValue("@name", tbQuizName.Text);
                                        commandSqlite.Parameters.AddWithValue("@tl", tle);
                                        commandSqlite.ExecuteNonQuery();

                                        commandSqlite.CommandText = "INSERT INTO correctanswer VALUES (@quizid, @questid, @ca)";

                                        for (i = 0; i < QuizE.Count; i++)
                                        {
                                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                            commandSqlite.Parameters.AddWithValue("@questid", i + 1);
                                            commandSqlite.Parameters.AddWithValue("@ca", QuizE[i].CorrectAnswer);
                                            commandSqlite.ExecuteNonQuery();
                                        }

                                        commandSqlite.CommandText = "INSERT INTO statement VALUES (@quizid, @questid, @name, @font)";

                                        for (i = 0; i < StatementE.Count; i++)
                                        {
                                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                            commandSqlite.Parameters.AddWithValue("@questid", i + 1);
                                            commandSqlite.Parameters.AddWithValue("@name", StatementE[i].Statement);
                                            commandSqlite.Parameters.AddWithValue("@font", StatementE[i].FontSize);
                                            commandSqlite.ExecuteNonQuery();
                                        }

                                        commandSqlite.CommandText = "INSERT INTO answer VALUES (@quizid, @questid, @answerid, @name, @fontsize)";

                                        for (i = 0; i < AnswerE.Count; i++)
                                        {
                                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                                            commandSqlite.Parameters.AddWithValue("@questid", (i / 4) + 1);
                                            commandSqlite.Parameters.AddWithValue("@answerid", AnswerE[i].AnswerID);
                                            commandSqlite.Parameters.AddWithValue("@name", AnswerE[i].Answer);
                                            commandSqlite.Parameters.AddWithValue("@fontsize", AnswerE[i].FontSize);
                                            commandSqlite.ExecuteNonQuery();
                                        }

                                        try
                                        {
                                            transactionSqlite.Commit();
                                            if (MessageBox.Show("Quiz criado com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                                            {
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).GetQuizList();
                                                this.Close();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            transactionSqlite.Rollback();
                                            MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                if (connectionSqlite.State == ConnectionState.Open)
                                    connectionSqlite.Close();
                            }
                            break;
                        case 1:
                            var connStringPostgreSql = "Host=ec2-52-207-90-231.compute-1.amazonaws.com;Username=wbzsjddxywtruf;Password=612595f417f43e5197bc0b4fb9b57426b34647c70d58b6c6035a80aa355ac3b8;Database=d7116u8khqnvvo;";

                            var connectionPostgreSql = new NpgsqlConnection(connStringPostgreSql);

                            try
                            {
                                connectionPostgreSql.Open();
                                if (edit == 1)
                                {
                                    using (var transactionPostgreSql = connectionPostgreSql.BeginTransaction())
                                    {
                                        var commandPostgreSql = connectionPostgreSql.CreateCommand();

                                        commandPostgreSql.CommandText = "UPDATE quiz SET name=@name WHERE quizid=@quizid";

                                        if (editqn == 1)
                                        {
                                            commandPostgreSql.Parameters.AddWithValue("@name", tbQuizName.Text);
                                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                            commandPostgreSql.ExecuteNonQuery();
                                        }

                                        commandPostgreSql.CommandText = "UPDATE correctanswer SET correctanswer=@ca WHERE quizid=@quizid AND questionid=@questid";

                                        for (i = 0; i < QuizE.Count; i++)
                                        {
                                            if (editca[i] == 1)
                                            {
                                                commandPostgreSql.Parameters.AddWithValue("@ca", QuizE[i].CorrectAnswer);
                                                commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                                commandPostgreSql.Parameters.AddWithValue("@questid", i + 1);
                                                commandPostgreSql.ExecuteNonQuery();
                                            }
                                        }

                                        commandPostgreSql.CommandText = "UPDATE statement SET statement=@name WHERE quizid=@quizid AND questionid=@questid";

                                        for (i = 0; i < StatementE.Count; i++)
                                        {
                                            if (editsta[i] == 1)
                                            {
                                                commandPostgreSql.Parameters.AddWithValue("@name", StatementE[i].Statement);
                                                commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                                commandPostgreSql.Parameters.AddWithValue("@questid", i + 1);
                                                commandPostgreSql.ExecuteNonQuery();
                                            }
                                        }

                                        commandPostgreSql.CommandText = "UPDATE answer SET answer=@name WHERE quizid=@quizid AND questionid=@questid AND answerid=@answerid";

                                        for (i = 0; i < AnswerE.Count; i++)
                                        {
                                            if (editans[i] == 1)
                                            {
                                                commandPostgreSql.Parameters.AddWithValue("@name", AnswerE[i].Answer);
                                                commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                                commandPostgreSql.Parameters.AddWithValue("@questid", (i / 4) + 1);
                                                commandPostgreSql.Parameters.AddWithValue("@answerid", AnswerE[i].AnswerID);
                                                commandPostgreSql.ExecuteNonQuery();
                                            }
                                        }

                                        commandPostgreSql.CommandText = "UPDATE quiz SET timelimit=@tl WHERE quizid=@quizid";

                                        if (edittl == 1)
                                        {
                                            commandPostgreSql.Parameters.AddWithValue("@tl", tle);
                                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                            commandPostgreSql.ExecuteNonQuery();
                                        }

                                        try
                                        {
                                            transactionPostgreSql.Commit();
                                            if (MessageBox.Show("Alterações no Quiz feitas com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                                            {
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).GetQuizList();
                                                this.Close();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            transactionPostgreSql.Rollback();
                                            MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                                else
                                {
                                    using (var transactionPostgreSql = connectionPostgreSql.BeginTransaction())
                                    {
                                        var commandPostgreSql = connectionPostgreSql.CreateCommand();

                                        commandPostgreSql.CommandText = "INSERT INTO quiz VALUES (@quizid, @name, @tl)";

                                        commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                        commandPostgreSql.Parameters.AddWithValue("@name", tbQuizName.Text);
                                        commandPostgreSql.Parameters.AddWithValue("@tl", tle);
                                        commandPostgreSql.ExecuteNonQuery();

                                        commandPostgreSql.CommandText = "INSERT INTO correctanswer VALUES (@quizid, @questid, @ca)";

                                        for (i = 0; i < QuizE.Count; i++)
                                        {
                                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                            commandPostgreSql.Parameters.AddWithValue("@questid", i + 1);
                                            commandPostgreSql.Parameters.AddWithValue("@ca", QuizE[i].CorrectAnswer);
                                            commandPostgreSql.ExecuteNonQuery();
                                        }

                                        commandPostgreSql.CommandText = "INSERT INTO statement VALUES (@quizid, @questid, @name, @font)";

                                        for (i = 0; i < StatementE.Count; i++)
                                        {
                                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                            commandPostgreSql.Parameters.AddWithValue("@questid", i + 1);
                                            commandPostgreSql.Parameters.AddWithValue("@name", StatementE[i].Statement);
                                            commandPostgreSql.Parameters.AddWithValue("@font", StatementE[i].FontSize);
                                            commandPostgreSql.ExecuteNonQuery();
                                        }

                                        commandPostgreSql.CommandText = "INSERT INTO answer VALUES (@quizid, @questid, @answerid, @name, @fontsize)";

                                        for (i = 0; i < AnswerE.Count; i++)
                                        {
                                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                                            commandPostgreSql.Parameters.AddWithValue("@questid", (i / 4) + 1);
                                            commandPostgreSql.Parameters.AddWithValue("@answerid", AnswerE[i].AnswerID);
                                            commandPostgreSql.Parameters.AddWithValue("@name", AnswerE[i].Answer);
                                            commandPostgreSql.Parameters.AddWithValue("@fontsize", AnswerE[i].FontSize);
                                            commandPostgreSql.ExecuteNonQuery();
                                        }

                                        try
                                        {
                                            transactionPostgreSql.Commit();
                                            if (MessageBox.Show("Quiz criado com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                                            {
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).Show();
                                                ((MainWindow)System.Windows.Application.Current.MainWindow).GetQuizList();
                                                this.Close();
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            transactionPostgreSql.Rollback();
                                            MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                                        }
                                    }
                                }
                            }
                            finally
                            {
                                if (connectionPostgreSql.State == ConnectionState.Open)
                                    connectionPostgreSql.Close();
                            }
                            break;
                        default:
                            MessageBox.Show("Tipo inválido de Database selecionado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            break;
                    }
                    break;
                //Houveram erros? Se sim, exiba a mensagem adequada
                case 1:
                    MessageBox.Show("Existem perguntas que não foram alteradas, verifique as perguntas e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 2:
                    MessageBox.Show("Existem respostas que não foram alteradas, verifique as respostas e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 3:
                    MessageBox.Show("\"Resposta Correta\" fora do escopo. Verifique se não há alguma resposta correta inválida.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                case 4:
                    MessageBox.Show("O nome do Quiz não foi alterado. Faça a alteração e tente novamente.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
                case 5:
                    MessageBox.Show("Nenhuma alteração foi detectada no Quiz.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    break;
            }
        }

        // Evento: Houveram mudanças na caixa de seleção de Questões (cbQuestion)?
        private void cbQuestion_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (first >= 1)
            {
                bt1stAnswerE.Focus();

                selectedanswer = 1;
                tbAnswer1.Visibility = Visibility.Visible;
                tbAnswer2.Visibility = Visibility.Hidden;
                tbAnswer3.Visibility = Visibility.Hidden;
                tbAnswer4.Visibility = Visibility.Hidden;

                tblAnswer.Text = "Resposta " + selectedanswer + ":";

                StatementE[oldquestion].Statement = tbStatement.Text;

                QuizE[oldquestion].QuestionID = oldquestion + 1;
                QuizE[oldquestion].CorrectAnswer = oldca;

                AnswerE[4 * oldquestion].Answer = tbAnswer1.Text;
                AnswerE[(4 * oldquestion) + 1].Answer = tbAnswer2.Text;
                AnswerE[(4 * oldquestion) + 2].Answer = tbAnswer3.Text;
                AnswerE[(4 * oldquestion) + 3].Answer = tbAnswer4.Text;

            }
            else
            {
                first++;
            }

            change();
        }

        /* Função utilizada para:
         * - Alterar questão selecionada baseada no que foi selecionado na Caixa de Combinação de Questões (cbQuestion)
         */
        private void change()
        {
            cbList cbquest = cbQuestion.SelectedItem as cbList;

            int i = cbquest.ID - 1;

            tbStatement.Text = StatementE[i].Statement;

            cbCorrectAnswer.SelectedIndex = QuizE[i].CorrectAnswer;

            tbAnswer1.Text = AnswerE[4 * i].Answer;
            tbAnswer2.Text = AnswerE[(4 * i) + 1].Answer;
            tbAnswer3.Text = AnswerE[(4 * i) + 2].Answer;
            tbAnswer4.Text = AnswerE[(4 * i) + 3].Answer;

            Dispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => tbStatement.Focus()));
            tbStatement.CaretIndex = tbStatement.Text.Length;
        }

        // Evento: Alguma Caixa de Combinação foi aberta? (Exceto de Questões)
        private void cbCommon_Opened(object sender, EventArgs e)
        {
            cbList cbquest = cbQuestion.SelectedItem as cbList;
            cbList cbca = cbCorrectAnswer.SelectedItem as cbList;

            oldquestion = cbquest.ID - 1;
            oldca = cbca.ID - 1;
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
}
