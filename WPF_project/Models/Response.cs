using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_project.Models
{
    public class Response
    {
        private int id;
        private int questionid;
        private string label;

        public int Id { get => id; set => id = value; }
        public int Questionid { get => questionid; set => questionid = value; }
        public string Label { get => label; set => label = value; }
    }
}
