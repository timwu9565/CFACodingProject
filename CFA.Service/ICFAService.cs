using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Service
{
    public interface ICFAService
    {
        int GetScore(string input);
        int RemoveGarbage(string input, int n);
    }
}
