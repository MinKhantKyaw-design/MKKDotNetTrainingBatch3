using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp
{
    public class Father
    {
        public string ProName { get; set; }
        protected string Test1(string name)
        { 
            if(!string.IsNullOrEmpty(name))
                return ProName = name;
            return "Khant";
        }
    }
}
