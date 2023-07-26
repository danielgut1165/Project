using chess_game_manager.Pieces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace chess_game_manager
{
    public class GameState
    {
        public string GameID { get; set; }
        public string GameFen { get; set; }

        public Piece[,] Board { get; set; }

        public Piece[,] DebugBoard { get; set; }

        public GameState(string gameID, string gameFen)
        {
            GameID = gameID;
            GameFen = gameFen;
            Board = DeconstructFen(gameFen);
            DebugBoard = DeconstructFen(gameFen);
        }

        public Piece[,] DeconstructFen(string fen)
        {
            char[] order = new char[64];
            int order_index = 0;
            for (int i = 0; i < fen.Length; i++)
            {
                char piece = fen[i];
                if (piece == '/')
                {
                    continue;
                }
                if (piece >= 48 && piece <= 57)
                {
                    int spaces = (int)(Char.GetNumericValue(piece));
                    for (int j = 0; j < spaces; j++)
                    {
                        order[order_index + j] = ' ';
                    }
                    order_index += spaces;
                } else
                {
                    order[order_index] = piece;
                    order_index++;
                }
                
            }

            Piece[,] board = new Piece[8, 8];
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    int index = r * 8 + c;
                    char piece = order[index];
                    switch(piece)
                    {
                        case 'p':
                            bool f_move = r == 1 ? true : false;
                            board[r, c] = new Pawn(piece, false, f_move);
                            break;
                        case 'P':
                            f_move = r == 6 ? true : false;
                            board[r, c] = new Pawn(piece, true, f_move);
                            break;
                        case 'b':
                            board[r, c] = new Bishop(piece, false);
                            break;
                        case 'B':
                            board[r, c] = new Bishop(piece, true);
                            break;
                        case 'n':
                            board[r, c] = new Knight(piece, false);
                            break;
                        case 'N':
                            board[r, c] = new Knight(piece, true);
                            break;
                        case 'r':
                            board[r, c] = new Rook(piece, false);
                            break;
                        case 'R':
                            board[r, c] = new Rook(piece, true);
                            break;
                        case 'q':
                            board[r, c] = new Queen(piece, false);
                            break;
                        case 'Q':
                            board[r, c] = new Queen(piece, true);
                            break;
                        case 'k':
                            board[r, c] = new King(piece, false);
                            break;
                        case 'K':
                            board[r, c] = new King(piece, true);
                            break;
                        case ' ':
                            board[r, c] = new Blank(piece, false);
                            break;
                    }
                }
            }
            return board;
            
        }

        public string GenerateFen()
        {
            string fen = "";
            for (int r = 0; r < 8; r++)
            {
                int count = 0;
                for (int c = 0; c < 8; c++)
                {
                    Piece piece = DebugBoard[r, c];
                    if (piece.Character == ' ')
                    {
                        count++;
                    }
                    else
                    {
                        fen += count != 0 ? count : "";
                        fen += piece.Character;
                        count = 0;
                    }
                }
                fen += count != 0 ? count : "";
                fen += r == 7 ? "" : "/";
            }
            return fen;
        }

        public void PrintBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(Board[r, c].Character + "|");
                }
                Console.WriteLine();
                Console.WriteLine("----------------");
            }
        }

        public void PrintDebugBoard()
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    Console.Write(DebugBoard[r, c].Character + "|");
                }
                Console.WriteLine();
                Console.WriteLine("----------------");
            }
        }

        public void MakeMove(int start, int end)
        {
            //grabbing the coords and pieces
            int s_row = start / 8;
            int s_col = start % 8;
            int e_row = end / 8;
            int e_col = end % 8;   
            Piece start_p = Board[s_row, s_col];
            Piece end_p = Board[e_row, e_col];

            if (start_p.CheckMove(Board, s_row, s_col, e_row, e_col))
            {
                Board[e_row, e_col] = start_p;
                Board[s_row, s_col] = new Blank(' ', false);
            } else
            {
                Console.WriteLine("Illegal Move");
            }
        }

        public void DebugMoves(int index)
        {
            //grabbing the coords
            int s_row = index / 8;
            int s_col = index % 8;
            Piece piece = Board[s_row, s_col];

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (piece.CheckMove(Board, s_row, s_col, r, c))
                    {
                        DebugBoard[r, c] = new Blank('X', false);
                    }
                }
            }
        }
        public void DebugMovesAll(char _piece)
        {
            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    if (Board[r, c].Character == _piece)
                    {
                        DebugMoves(r * 8 + c);
                    }
                }
            }
        }
    }
}
