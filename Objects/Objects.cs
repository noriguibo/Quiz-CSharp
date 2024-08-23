using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_ALG.Objects
{
    public class Quiz_Data
    {
        public int QuestionID { get; set; }

        public int CorrectAnswer { get; set; }
    }

    public class Statement_Data
    {
        public string Statement { get; set; } = string.Empty;
        public int FontSize { get; set; }
    }

    public class Answer_Data
    {
        public int AnswerID { get; set; }
        public string Answer { get; set; } = string.Empty;
        public int FontSize { get; set; }

    }

    public class Quiz_List
    {
        public int QuizID { get; set; }

        public string Name { get; set; } = string.Empty;

        public int TimeLimit { get; set; }
    }

    public class cbList
    {
        public int ID { get; set; }
    }

    public class cbTimeLimits
    {
        public string ID { get; set; } = string.Empty;
    }
}
