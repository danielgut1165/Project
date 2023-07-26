using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    internal class Knight : Piece
    {
        public Knight(char _piece, bool isWhite) : base(_piece, isWhite)
        {

        }

        public override bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            int[] x_moves = { 2, 1, -1, -2, -2, -1, 1, 2 };
            int[] y_moves = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int i = 0; i < 8; i++)
            {
                int x = s_row + x_moves[i];
                int y = s_col + y_moves[i];

                if (x == e_row && y == e_col)
                {
                    if (board[e_row, e_col] is Blank || board[e_row, e_col].IsWhite != board[s_row, s_col].IsWhite)
                    {
                        return true;
                    }
                    
                }
            }
            return false;
        }
    }
}
