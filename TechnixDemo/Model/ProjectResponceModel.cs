using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnixDemo.Model
{
    public class ProjectResponceModel
    {
        public string SolutionPath { get; set; }
        public string ProjectPath { get; set; }
        public string ControllerPath { get; set; }
        public string ServicePath { get; set; }
        public string ModelPath { get; set; }
        public bool Status {  get; set; }
    }
}
