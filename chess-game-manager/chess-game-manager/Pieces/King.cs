using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    public class King : Piece
    {
        public King(char _piece, bool isWhite) : base(_piece, isWhite)
        {

        }

        public override bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            if (!(e_row >= s_row - 1 && e_row <= s_row + 1))
            {
                return false;
            }
            if (!(e_col >= s_col - 1 && e_col <= s_col + 1))
            {
                return false;
            }
            if (board[e_row, e_col] is Blank)
            {
                return true;
            }
            if (board[e_row, e_col].IsWhite == board[s_row, s_col].IsWhite)
            {
                return false;
            }
            return true;
        }
    }
}
