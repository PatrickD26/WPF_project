using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_project.Models
{
    class Filiere
    {
        private int id;
        private string label;
        private string description;
        private int score;

        public int Id { get => id; set => id = value; }
        public string Label { get => label; set => label = value; }
        public string Description { get => description; set => description = value; }
        public int Score { get => score; set => score = value; }
    }
}
