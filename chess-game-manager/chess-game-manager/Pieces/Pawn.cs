using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    public class Pawn : Piece
    {
        public bool FirstMove;
        public Pawn(char _piece, bool isWhite, bool f_move) : base(_piece, isWhite) 
        {
            FirstMove = f_move;
        }
        public override bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            int mult = IsWhite ? -1 : 1;
            if (board[s_row + (1 * mult), s_col] is Blank && s_row + (1 * mult) == e_row && s_col == e_col)
            {
                return true;
            }
            if (FirstMove && board[s_row + (1 * mult), s_col] is Blank && board[s_row + (2 * mult), s_col] is Blank && s_row + (2 * mult) == e_row && s_col == e_col)
            {
                return true;
            }
            return false;
        }
    }
}
