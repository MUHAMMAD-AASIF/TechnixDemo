using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnixDemo.Model
{
    public class ProjectResponseModel
    {
        public string SolutionName { get; set; } = string.Empty;
        public string SolutionPath { get; set; }=string.Empty;
        public string ProjectPath { get; set; } = string.Empty;
        public string ProjectName { get; set; } = string.Empty;
        public string APIPath { get; set; } = string.Empty;
        public string BusinessPath { get; set; } = string.Empty;
        public string BusinessContractPath { get; set; } = string.Empty;
        public string DataAccessPath { get; set; } = string.Empty;
        public string DataAccessContractPath { get; set; } = string.Empty;
        public string CommonModelPath { get; set; } = string.Empty;
        public string APITestPath { get; set; } = string.Empty;
        public string BusinessTestPath { get; set; } = string.Empty;
        public bool Status {  get; set; } = false;
        public string DbConfig { get; set;} = string.Empty; 
    }
}
