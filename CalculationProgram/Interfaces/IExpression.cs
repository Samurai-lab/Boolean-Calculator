using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculationProgram.Interfaces;

namespace CalculationProgram
{
    public interface IExpression
    { 
       public void UseExpression(IUniversum  universum, Dictionary<string, HashSet<int>> setElement);
    }
}