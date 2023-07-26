using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    public class Piece
    {
        public char Character;
        public bool IsWhite;

        public Piece(char piece, bool isWhite)
        {
            Character = piece;
            IsWhite = isWhite;
        }

        public virtual bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            throw new NotImplementedException();
        }
    }
}
