using System;
using System.Collections.Generic;
using System.Text;

namespace PaperBoy.Models
{
   public  class ToDo
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public bool completed { get; set; }

    }
}
