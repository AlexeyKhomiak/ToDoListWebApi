using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace XamarinClient
{
    public class TodoList
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Notes { get; set; }
        public bool Done { get; set; }

    }
}
