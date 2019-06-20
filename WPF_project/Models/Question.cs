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
        private int filiereId;

        public int Id { get => id; set => id = value; }
        public bool IsGame { get => isGame; set => isGame = value; }
        public string Label { get => label; set => label = value; }
        public bool IsOrientation { get => isOrientation; set => isOrientation = value; }
        public int FiliereId { get => filiereId; set => filiereId = value; }
    }
}
