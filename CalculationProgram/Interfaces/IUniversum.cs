using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculationProgram.Interfaces
{
    public interface IUniversum
    {
        public void createOwnUniversum();
        public void createRandomUniversum();
        public int[] getUniversum();
    }
}