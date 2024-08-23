using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using Quiz_ALG.Objects;
using System.Data.SQLite;
using Npgsql;
using System.Runtime.CompilerServices;
using System.Windows.Resources;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using static System.Net.Mime.MediaTypeNames;
using System.Collections.ObjectModel;


namespace Quiz_ALG
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    static class DB
    {
        public const int SQLITE = 0;
        public const int POSTGRESQL = 1;
    }

    public partial class MainWindow : Window
    {
        //Declaração de variáveis
        int quizid = -1, dbtype = DB.SQLITE;
        List<Quiz_Data> Quiz = new List<Quiz_Data>();
        List<Statement_Data> Statement = new List<Statement_Data>();
        List<Answer_Data> Answer = new List<Answer_Data>();
        List<Quiz_List> QuizList = new List<Quiz_List>();

        //Inicializar janela de Seleção de Quiz / Janela Principal
        public MainWindow()
        {
            InitializeComponent();
            this.SourceInitialized += MainWindow_SourceInitialized;
            GetQuizList();
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
                this.Close();
            }
        }

        /* Evento: Botões de...
         *  btSelectQuiz - Selecionar Quiz
         *  btEditQuiz - Editar Quiz
         *  btResetQuiz - Apagar Quiz
         * */
        private void btCommon_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btSelectQuiz))
            {
                if (quizid != -1)
                {
                    if (QuizList[quizid - 1].Name != "- - - - - -")
                    {
                        this.Hide();
                        FirstCall();

                        QuizGame quizGame = new QuizGame(Quiz, Statement, Answer, QuizList[quizid - 1].Name, QuizList[quizid - 1].TimeLimit);
                        quizGame.Show();
                    }
                }
            }
            else if (sender.Equals(btEditQuiz))
            {
                if (quizid != -1 && quizid != 1)
                {
                    int edit = 1;
                    this.Hide();
                    FirstCall();

                    if (QuizList[quizid - 1].Name == "- - - - - -")
                        edit = 0;

                    //Criar e inicializar janela de edição de quiz
                    EditQuiz editQuiz = new EditQuiz(Quiz, Statement, Answer, edit, QuizList[quizid - 1].Name, QuizList[quizid - 1].TimeLimit, quizid, dbtype);
                    editQuiz.Show();
                }
            }
            else if (sender.Equals(btResetQuiz))
            {
                if (quizid != -1 && quizid != 1)
                {
                    ResetQuiz();
                }
            }
        }

        /* Função usada para:
         * - Apagar Quiz
         */
        public void ResetQuiz()
        {
            switch (dbtype)
            {
                //Caso esteja trabalhando com Database Embutido (SQLite)
                case 0:
                    var connStringSqlite = "Data Source = quiz.db";

                    var connectionSqlite = new SQLiteConnection(connStringSqlite);
                    var commandSqlite = connectionSqlite.CreateCommand();

                    try
                    {
                        connectionSqlite.Open();

                        using (var transactionSqlite = connectionSqlite.BeginTransaction())
                        {
                            commandSqlite.CommandText = "DELETE FROM quiz WHERE quizid=@quizid";
                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                            commandSqlite.ExecuteNonQuery();

                            commandSqlite.CommandText = "DELETE FROM correctanswer WHERE quizid=@quizid";
                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                            commandSqlite.ExecuteNonQuery();

                            commandSqlite.CommandText = "DELETE FROM answer WHERE quizid=@quizid";
                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                            commandSqlite.ExecuteNonQuery();

                            commandSqlite.CommandText = "DELETE FROM statement WHERE quizid=@quizid";
                            commandSqlite.Parameters.AddWithValue("@quizid", quizid);
                            commandSqlite.ExecuteNonQuery();

                            try
                            {
                                transactionSqlite.Commit();
                                GetQuizList();
                                MessageBox.Show("Quiz apagado com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception)
                            {
                                transactionSqlite.Rollback();
                                MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    finally
                    {
                        if (connectionSqlite.State == ConnectionState.Open)
                            connectionSqlite.Close();
                    }
                    btResetQuiz.Visibility = Visibility.Hidden;
                    break;
                // Caso esteja trabalhando com Database Online (PostgreSQL)
                case 1:
                    var connStringPostgreSql = "Host=ec2-52-207-90-231.compute-1.amazonaws.com;Username=wbzsjddxywtruf;Password=612595f417f43e5197bc0b4fb9b57426b34647c70d58b6c6035a80aa355ac3b8;Database=d7116u8khqnvvo;";

                    var connectionPostgreSql = new NpgsqlConnection(connStringPostgreSql);
                    var commandPostgreSql = connectionPostgreSql.CreateCommand();

                    try
                    {
                        connectionPostgreSql.Open();

                        using (var transactionPostgreSql = connectionPostgreSql.BeginTransaction())
                        {
                            commandPostgreSql.CommandText = "DELETE FROM quiz WHERE quizid=@quizid";
                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                            commandPostgreSql.ExecuteNonQuery();

                            commandPostgreSql.CommandText = "DELETE FROM correctanswer WHERE quizid=@quizid";
                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                            commandPostgreSql.ExecuteNonQuery();

                            commandPostgreSql.CommandText = "DELETE FROM answer WHERE quizid=@quizid";
                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                            commandPostgreSql.ExecuteNonQuery();

                            commandPostgreSql.CommandText = "DELETE FROM statement WHERE quizid=@quizid";
                            commandPostgreSql.Parameters.AddWithValue("@quizid", quizid);
                            commandPostgreSql.ExecuteNonQuery();

                            try
                            {
                                transactionPostgreSql.Commit();
                                GetQuizList();
                                MessageBox.Show("Quiz apagado com sucesso!", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            catch (Exception)
                            {
                                transactionPostgreSql.Rollback();
                                MessageBox.Show("Ocorreu um erro no salvamento do Quiz.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                    finally
                    {
                        if (connectionPostgreSql.State == ConnectionState.Open)
                            connectionPostgreSql.Close();
                    }
                    break;
                    //Ignorar aviso de código inacessível
#pragma warning disable CS0162
                    btResetQuiz.Visibility = Visibility.Hidden;
#pragma warning restore CS0162
                //Tipo de database inválido?
                default:
                    MessageBox.Show("Tipo inválido de Database selecionado.", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    break;
            }
        }

        /* Função utilizada para:
         * - Selecionar algo na lista de Quiz
         */
        private void btSelectQuiz_Down(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(bt1stQuizE))
            {
                quizid = 1;
            }
            else if (sender.Equals(bt2ndQuizE))
            {
                quizid = 2;
            }
            else if (sender.Equals(bt3rdQuizE))
            {
                quizid = 3;
            }
            else if (sender.Equals(bt4thQuizE))
            {
                quizid = 4;
            }
            else if (sender.Equals(bt5thQuizE))
            {
                quizid = 5;
            }
            else if (sender.Equals(bt6thQuizE))
            {
                quizid = 6;
            }
            else if (sender.Equals(bt7thQuizE))
            {
                quizid = 7;
            }
            else if (sender.Equals(bt8thQuizE))
            {
                quizid = 8;
            }
            else if (sender.Equals(bt9thQuizE))
            {
                quizid = 9;
            }
            else if (sender.Equals(bt10thQuizE))
            {
                quizid = 10;
            }
            else if (sender.Equals(bt11thQuizE))
            {
                quizid = 11;
            }
            else if (sender.Equals(bt12thQuizE))
            {
                quizid = 12;
            }
            else if (sender.Equals(bt13thQuizE))
            {
                quizid = 13;
            }
            else if (sender.Equals(bt14thQuizE))
            {
                quizid = 14;
            }
            else if (sender.Equals(bt15thQuizE))
            {
                quizid = 15;
            }

            if (quizid == 1)
            {
                btEditQuiz.Visibility = Visibility.Hidden;
                btResetQuiz.Visibility = Visibility.Hidden;
            }
            else
            {
                btEditQuiz.Visibility = Visibility.Visible;

                if (QuizList[quizid - 1].Name != "- - - - - -")
                    btResetQuiz.Visibility = Visibility.Visible;
                else
                    btResetQuiz.Visibility = Visibility.Hidden;
            }
        }

        /* Função utilizada para:
         * - Atualizar lista de Quiz
         */
        public void GetQuizList()
        {
            QuizList.Clear();

            for (int i = 1; i <= 15; i++)
                QuizList.Add(new Quiz_List { QuizID = i, Name = "- - - - - -" , TimeLimit = 60});

            switch(dbtype)
            {
                case 0:
                    var connStringSqlite = "Data Source = quiz.db";

                    var connectionSqlite = new SQLiteConnection(connStringSqlite);
                    var commandSqlite = connectionSqlite.CreateCommand();

                    try
                    {
                        connectionSqlite.Open();
                        commandSqlite.CommandText = "SELECT * FROM quiz ORDER BY quizid ASC";

                        using (SQLiteDataReader oReaderSqlite = commandSqlite.ExecuteReader())
                        {
                            while (oReaderSqlite.Read())
                            {
                                for(int i = 0; i < QuizList.Count; i++)
                                {
                                    if (QuizList[i].QuizID == oReaderSqlite.GetInt32(0))
                                    {
                                        QuizList[i].Name = (string)oReaderSqlite["name"];
                                        QuizList[i].TimeLimit = oReaderSqlite.GetInt32(2);
                                    }
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
                    var commandPostgreSql = connectionPostgreSql.CreateCommand();

                    try
                    {
                        connectionPostgreSql.Open();
                        commandPostgreSql.CommandText = "SELECT * FROM quiz ORDER BY quizid ASC";

                        using (NpgsqlDataReader oReaderPostgreSql = commandPostgreSql.ExecuteReader())
                        {
                            while (oReaderPostgreSql.Read())
                            {
                                for (int i = 0; i < QuizList.Count; i++)
                                {
                                    if (QuizList[i].QuizID == oReaderPostgreSql.GetInt32(0))
                                    {
                                        QuizList[i].Name = (string)oReaderPostgreSql["name"];
                                        QuizList[i].TimeLimit = oReaderPostgreSql.GetInt32(2);
                                    }
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

            UpdateQuizList();
        }

        /* Função utilizada para:
         * - Pegar a lista de Quiz no Database e popular as Listas de classes (Veja na declaração das variáveis)
         */
        public void FirstCall()
        {
            switch (dbtype)
            {
                case 0:
                    var connStringSqlite = "Data Source = quiz.db";

                    var connectionSqlite = new SQLiteConnection(connStringSqlite);
                    var commandSqlite = connectionSqlite.CreateCommand();

                    try
                    {
                        connectionSqlite.Open();
                        commandSqlite.CommandText = "SELECT * FROM correctanswer WHERE quizid = @fquizid ORDER BY questionid ASC";
                        commandSqlite.Parameters.AddWithValue("@fquizid", quizid);

                        Quiz.Clear();
                        using (SQLiteDataReader oReaderSqlite = commandSqlite.ExecuteReader())
                        {
                            while (oReaderSqlite.Read())
                            {
                                Quiz.Add(new Quiz_Data { QuestionID = oReaderSqlite.GetInt32(1), CorrectAnswer = oReaderSqlite.GetInt32(2) });
                            }
                        }

                        commandSqlite.CommandText = "SELECT * FROM statement WHERE quizid = @fquizid ORDER BY questionid ASC";
                        commandSqlite.Parameters.AddWithValue("@fquizid", quizid);

                        Statement.Clear();
                        using (SQLiteDataReader oReaderSqlite = commandSqlite.ExecuteReader())
                        {
                            while (oReaderSqlite.Read())
                            {
                                Statement.Add(new Statement_Data { Statement = (string)oReaderSqlite["statement"], FontSize = oReaderSqlite.GetInt32(3) });
                            }
                        }

                        commandSqlite.CommandText = "SELECT * FROM answer WHERE quizid = @fquizid ORDER BY questionid ASC, answerid ASC";
                        commandSqlite.Parameters.AddWithValue("@fquizid", quizid);

                        Answer.Clear();
                        using (SQLiteDataReader oReaderSqlite = commandSqlite.ExecuteReader())
                        {
                            while (oReaderSqlite.Read())
                            {
                                Answer.Add(new Answer_Data { AnswerID = oReaderSqlite.GetInt32(2), Answer = (string)oReaderSqlite["answer"], FontSize = oReaderSqlite.GetInt32(4) });
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
                    var commandPostgreSql = connectionPostgreSql.CreateCommand();

                    try
                    {
                        connectionPostgreSql.Open();
                        commandPostgreSql.CommandText = "SELECT * FROM correctanswer WHERE quizid = @fquizid ORDER BY questionid ASC";
                        commandPostgreSql.Parameters.AddWithValue("@fquizid", quizid);

                        Quiz.Clear();
                        using (NpgsqlDataReader oReaderPostgreSql = commandPostgreSql.ExecuteReader())
                        {
                            while (oReaderPostgreSql.Read())
                            {
                                Quiz.Add(new Quiz_Data { QuestionID = oReaderPostgreSql.GetInt32(1), CorrectAnswer = oReaderPostgreSql.GetInt32(2) });
                            }
                        }

                        commandPostgreSql.CommandText = "SELECT * FROM statement WHERE quizid = @fquizid ORDER BY questionid ASC";
                        commandPostgreSql.Parameters.AddWithValue("@fquizid", quizid);

                        Statement.Clear();
                        using (NpgsqlDataReader oReaderPostgreSql = commandPostgreSql.ExecuteReader())
                        {
                            while (oReaderPostgreSql.Read())
                            {
                                Statement.Add(new Statement_Data { Statement = (string)oReaderPostgreSql["statement"], FontSize = oReaderPostgreSql.GetInt32(3) });
                            }
                        }

                        commandPostgreSql.CommandText = "SELECT * FROM answer WHERE quizid = @fquizid ORDER BY questionid ASC, answerid ASC";
                        commandPostgreSql.Parameters.AddWithValue("@fquizid", quizid);

                        Answer.Clear();
                        using (NpgsqlDataReader oReaderPostgreSql = commandPostgreSql.ExecuteReader())
                        {
                            while (oReaderPostgreSql.Read())
                            {
                                Answer.Add(new Answer_Data { AnswerID = oReaderPostgreSql.GetInt32(2), Answer = (string)oReaderPostgreSql["answer"], FontSize = oReaderPostgreSql.GetInt32(4) });
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
        }

        /* Função utilizada para:
         * - Atualizar conteúdo dos botões dentro do ListView (lvQuizE)
         */
        private void UpdateQuizList()
        {
            bt1stQuizE.Content = QuizList[0].Name;
            bt2ndQuizE.Content = QuizList[1].Name;
            bt3rdQuizE.Content = QuizList[2].Name;
            bt4thQuizE.Content = QuizList[3].Name;
            bt5thQuizE.Content = QuizList[4].Name;
            bt6thQuizE.Content = QuizList[5].Name;
            bt7thQuizE.Content = QuizList[6].Name;
            bt8thQuizE.Content = QuizList[7].Name;
            bt9thQuizE.Content = QuizList[8].Name;
            bt10thQuizE.Content = QuizList[9].Name;
            bt11thQuizE.Content = QuizList[10].Name;
            bt12thQuizE.Content = QuizList[11].Name;
            bt13thQuizE.Content = QuizList[12].Name;
            bt14thQuizE.Content = QuizList[13].Name;
            bt15thQuizE.Content = QuizList[14].Name;
        }

        /* Função utilizada para:
         * - Alterar a função do clique com botão Esquerdo do mouse na janela
         */
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            this.DragMove();
        }


        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_STYLE = -16;

        private const int WS_MAXIMIZEBOX = 0x10000; //maximize button
        private const int WS_MINIMIZEBOX = 0x20000; //minimize button

        private IntPtr _windowHandle;
        private void MainWindow_SourceInitialized(object sender, EventArgs e)
        {
            _windowHandle = new WindowInteropHelper(this).Handle;

            //disable minimize button
            DisableMinimizeButton();
        }

        protected void DisableMinimizeButton()
        {
            if (_windowHandle == IntPtr.Zero)
                throw new InvalidOperationException("A janela ainda não foi completamente inicializada.");

            SetWindowLong(_windowHandle, GWL_STYLE, GetWindowLong(_windowHandle, GWL_STYLE) & ~WS_MAXIMIZEBOX);
        }
    }
}

// Example of Abstraction

/* class Cachorro
 * {
 *      private string nome;
 *      
 *      public Cachorro(string nome){
 *          this.nome = nome;
 *      }
 * }
 * */

// Diferenças entre Procedural e POO usando o Quiz:

/* em C: selectQuestion(hwnd)
 *       DestroyWindow(hwnd);
 *       
 * em C#: hwnd.selectQuestion();
 *        hwnd.DestroyWindow();
 */