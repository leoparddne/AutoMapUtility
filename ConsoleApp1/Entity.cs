using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ConsoleApp1
{
    public class T
    {
        public int a { get; set; }
        public int b { get; set; }

    }

    public class T2
    {
        public string a { get; set; }
        [Description("b")]
        public int bb { get; set; }

    }
}
