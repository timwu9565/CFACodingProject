using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFA.Service
{
    public class CFAService : ICFAService
    {
        public int GetScore(string input)
        {
            int score = 0;
            int level = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    level++;
                    continue;
                }
                else if (input[i] == '}')
                {
                    // ignore } without corresponding {
                    if (level == 0) continue;
                    score = score + level;                 
                    level--;
                    continue;
                }
             
                // garbage processor
                else if (input[i] == '<')
                {
                    i++;
                    i = RemoveGarbage(input, i);
                }
            }
            return score;
        }

        public int RemoveGarbage(string input, int n)
        {
            int len = input.Length;
            for (var i = n;  i< len; i++)
            {
                if (input[i] == '!')
                {
                    if (input[i - 1] == '!') continue;
                    else i = i + 1;
                }
                else if (input[i] == '>')
                {
                    return i;
                }
            }
            return n;
        }
    }
}

