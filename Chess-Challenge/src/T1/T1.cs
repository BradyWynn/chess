using ChessChallenge.API;
using System;

namespace ChessChallenge.Example
{
    public class T1 : IChessBot
    {
        //                     .  P    K    B    R    Q    K
        readonly int[] kPieceValues = { 0, 100, 300, 310, 500, 900, 10000 };
        readonly int kMassiveNum = 99999999;

        int mDepth;
        Move mBestMove;

        public Move Think(Board board, Timer timer)
        {
            // Move[] legalMoves = board.GetLegalMoves();
            mDepth = 4;

            EvaluateBoardNegaMax(board, mDepth, -kMassiveNum, kMassiveNum, board.IsWhiteToMove ? 1 : -1);
            board.MakeMove(mBestMove);
            // Console.WriteLine(board.GetFenString());

            return mBestMove;
        }

        int EvaluateBoardNegaMax(Board board, int depth, int alpha, int beta, int color)
        {
            Move[] legalMoves;

            if (board.IsDraw())
                return 0;

            if (depth == 0 || (legalMoves = board.GetLegalMoves()).Length == 0)
            {
                // EVALUATE
                int sum = 0;

                if (board.IsInCheckmate())
                    return -9999999;

                // subtracting all the white pieces from the black pieces
                // this produces high value when white is winning and low value when black is winning
                // this is why we need to multiply the final sum by the color variable
                // 1 for white and -1 for black meaning that the returned value will be high whenever the 
                // current color is doing well and low for when their position is bad
                for (int i = 0; ++i < 7;)
                    sum += (board.GetPieceList((PieceType)i, true).Count - board.GetPieceList((PieceType)i, false).Count) * kPieceValues[i];
                // EVALUATE

                return color * sum;
            }

            // TREE SEARCH
            int recordEval = int.MinValue;
            foreach (Move move in legalMoves)
            {
                board.MakeMove(move);
                int evaluation = -EvaluateBoardNegaMax(board, depth - 1, -beta, -alpha, -color);
                board.UndoMove(move);

                if (recordEval < evaluation)
                {
                    recordEval = evaluation;
                    if (depth == mDepth){
                        mBestMove = move;
                    }
                }
                alpha = Math.Max(alpha, recordEval);
                if (alpha >= beta) break;
            }
            // TREE SEARCH

            return recordEval;
        }
    }
}