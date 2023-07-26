using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(char _piece, bool isWhite) : base(_piece, isWhite)
        {

        }
        public override bool CheckMove(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {

            if (s_row == e_row && s_col == e_col)
            {
                return false;
            }

            if (s_row < e_row && s_col < e_col)
            {
                return CheckBottomRight(board, s_row, s_col, e_row, e_col);
            }
            if (s_row > e_row && s_col > e_col)
            {
                return CheckTopLeft(board, s_row, s_col, e_row, e_col);
            }
            if (s_row > e_row && s_col < e_col)
            {
                return CheckTopRight(board, s_row, s_col, e_row, e_col);
            }
            if (s_row < e_row && s_col > e_col)
            {
                return CheckBottomLeft(board, s_row, s_col, e_row, e_col);
            }

            return false;
        }

        public bool CheckBottomRight(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            bool found = false;
            for (int i = 1; i < 8; i++)
            {
                if (s_row + i >= 8 || s_col + i >= 8)
                {
                    return false;
                }
                if (board[s_row + i, s_col +  i] is not Blank)
                {
                    if (s_row + i == e_row && s_col + i == e_col && board[s_row + i, s_col + i].IsWhite != board[s_row, s_col].IsWhite)
                    {
                        return true;
                    }
                    return false;
                }
                if (s_row + i == e_row && s_col + i == e_col)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public bool CheckTopLeft(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            bool found = false;
            for (int i = 1; i < 8; i++)
            {
                if (s_row - i < 0|| s_col - i < 0)
                {
                    return false;
                }
                if (board[s_row - i, s_col - i] is not Blank)
                {
                    if (s_row - i == e_row && s_col - i == e_col && board[s_row - i, s_col - i].IsWhite != board[s_row, s_col].IsWhite)
                    {
                        return true;
                    }
                    return false;
                }
                if (s_row - i == e_row && s_col - i == e_col)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public bool CheckTopRight(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            bool found = false;
            for (int i = 1; i < 8; i++)
            {
                if (s_row - i < 0 || s_col + i >= 8)
                {
                    return false;
                }
                if (board[s_row - i, s_col + i] is not Blank)
                {
                    if (s_row - i == e_row && s_col + i == e_col && board[s_row - i, s_col + i].IsWhite != board[s_row, s_col].IsWhite)
                    {
                        return true;
                    }
                    return false;
                }
                if (s_row - i == e_row && s_col + i == e_col)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
        public bool CheckBottomLeft(Piece[,] board, int s_row, int s_col, int e_row, int e_col)
        {
            bool found = false;
            for (int i = 1; i < 8; i++)
            {
                if (s_row + i >= 8 || s_col - i < 0)
                {
                    return false;
                }
                if (board[s_row + i, s_col - i] is not Blank)
                {
                    if (s_row + i == e_row && s_col - i == e_col && board[s_row + i, s_col - i].IsWhite != board[s_row, s_col].IsWhite)
                    {
                        return true;
                    }
                    return false;
                }
                if (s_row + i == e_row && s_col - i == e_col)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }
    }
}
