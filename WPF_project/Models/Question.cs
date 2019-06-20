using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_project.Models
{
    public class Question
    {
        private int id;
        private bool isGame;
        private string label;
        private bool isOrientation;
        private int ordre;
        private int filiereId;
        private int answer;

        private List<Response> questionAnswers;

        public int Id { get => id; set => id = value; }
        public bool IsGame { get => isGame; set => isGame = value; }
        public string Label { get => label; set => label = value; }
        public bool IsOrientation { get => isOrientation; set => isOrientation = value; }
        public int FiliereId { get => filiereId; set => filiereId = value; }
        public List<Response> QuestionAnswers { get => questionAnswers; set => questionAnswers = value; }
        public int Answer { get => answer; set => answer = value; }
        public int Ordre { get => ordre; set => ordre = value; }
    }
}
