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
        private int responseId;
        private bool isOrientation;
        private List<Response> questionAnswers;

        public int Id { get => id; set => id = value; }
        public bool IsGame { get => isGame; set => isGame = value; }
        public string Label { get => label; set => label = value; }
        public int ResponseId { get => responseId; set => responseId = value; }
        public bool IsOrientation { get => isOrientation; set => isOrientation = value; }
        public List<Response> QuestionAnswers { get => questionAnswers; set => questionAnswers = value; }
    }
}
