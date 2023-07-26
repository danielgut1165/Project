using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    public class Blank : Piece
    {
        public Blank(char _piece, bool isWhite) : base(_piece, isWhite)
        {

        }

        public override bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            return false;
        }
    }
}
