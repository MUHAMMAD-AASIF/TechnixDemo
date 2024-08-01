using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnixDemo.Model
{
    public class ProjectResponseModel
    {
        public string SolutionPath { get; set; }=string.Empty;
        public string ProjectPath { get; set; } = string.Empty;
        public string ControllerPath { get; set; } = string.Empty;
        public string ServicePath { get; set; } = string.Empty;
        public string InterfacePath { get; set; } = string.Empty;
        public string ModelPath { get; set; } = string.Empty;
        public bool Status {  get; set; } = false;
        public Dictionary<string, string> ClassLibraryPaths { get; set; } = new Dictionary<string, string>();

    }
}
