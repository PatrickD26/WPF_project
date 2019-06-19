using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_project.Models
{
    class Player
    {
        private int id;
        private string nickname;
        private int score;
        private int userid;

        public int Id { get => id; set => id = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public int Score { get => score; set => score = value; }
        public int Userid { get => userid; set => userid = value; }
    }
}
