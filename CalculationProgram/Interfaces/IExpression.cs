using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationProgram
{
    public interface IExpression
    { 
        public string getExpression(); 
        public void setExpression(String text); 
        public void SolvingExpression();
        
    }
}