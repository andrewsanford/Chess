using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess.Objects
{
    public class TestedMove
    {
        public List<List<Square>> Board;
        public int BoardsEvaluation;
        public int? FinalEvaluation = null;
    }
}
