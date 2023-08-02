using ChessChallenge.API;
using System;
using System.Numerics;
// using System.Collections.Generic;
using System.Linq;

public class MyBot : IChessBot
{
    int[,] w1 = new int[384, 16];
    int[,] w2 = new int[16, 16];
    int[,] w3 = new int[16, 1];
    public MyBot(){
        // UInt64[] w = {4856156134427813478, 3911521856006809191, 7244117474980292214, 5225415157427365733, 9819666223999645270, 9540706994317911399, 5077359319410169463, 7450772815724504950, 8531900609334769510, 7383201233389450855, 7450755291973903991, 8531620229325154166, 7378715153235605351, 7378978009512375926, 7383183709940705125, 7450474916793972310, 8527134226446247271, 7306939107173095032, 6230561272512210823, 7455259991647615093, 8603695424104531799, 8531918269705647478, 7383483799323498343, 7455276346918663801, 8603957108441311126, 8536105219094116710, 7450474989539006053, 8527135390366787158, 7306957729901733220, 6230859236170421828, 7460027410178991172, 8679974120606549061, 9752377413737923670, 8464086030130365798, 6298167966118991459, 8536967089356105270, 7464264913730823015, 8747774177435858551, 10837178323006875506, 7374156504724043560, 7306039633327387269, 6216169690980886616, 7224994687146427781, 4919450552085534807, 4924232538530350454, 5000744321647400804, 6224932851520206409, 7365205255775544470};
        // for(int x = 0; x < w.Length; x++){
        //     string str = Convert.ToString((long) w[x], 2).PadLeft(64, '0');
        //     for(int y = 0; y < 16; y++){
        //         w1[(16 * x) + (y), 0] = Convert.ToInt32(str.Substring(y*4, 4), 2);
        //     }
        //     Console.WriteLine();
        // }
    }
    public Move Think(Board board, Timer timer){
        Move[] moves = board.GetLegalMoves();
        Move bestMove = moves[0];
        // double bestScore = 1;
        // foreach(Move move in moves){
        //     board.MakeMove(move);
        //     double score = Eval(BoardToBit(board));
        //     if(score < bestScore){
        //         bestScore = score;
        //         bestMove = move;
        //     }
        //     board.UndoMove(move);
        // }
        int a = 257;
        byte b = (byte)a;
        Console.WriteLine(b);
        return bestMove;
    }
    double Eval(int[,] a){
        double b = 0.5235;
        return (MatMul(a, w1)[0, 0] - (6.7241 * a.Cast<int>().Sum()))/90.2425267908 + b;
    }
    // 285 tokens, 373 tokens to start
    // int[,] FenToArray(String fen){
    //     int[,] bitboards = new int[1, 768];
    //     String[] pieces = {"p", "n", "r", "b", "q", "k", "P", "N", "R", "B", "Q", "K"};
    //     int count = 0;
    //     for(int i = 0; i < 100; i++){
    //         String letter = fen.Substring(i, 1);
    //         if(letter == "/")
    //             continue;
    //         try{
    //             count += int.Parse(letter);
    //         }
    //         catch{
    //             for(int p = 0; p < pieces.Length; p++)
    //                 if(letter == pieces[p])
    //                     if(p > 5)
    //                         bitboards[0, p * 64 + count] = -1;
    //                     else
    //                         bitboards[0, p * 64 + count] = 1;
    //             count += 1;
    //         }
    //         if(count == 64)
    //             break;
    //     }
    //     return bitboards;
    // }
    int[,] BoardToBit(Board board){
        int[,] bit = new int[1, 384];
        PieceType[] types = {PieceType.Pawn, PieceType.Knight, PieceType.Bishop, PieceType.Rook, PieceType.King};
        int count = 0;
        foreach(PieceType type in types){
            string white = Convert.ToString((long)board.GetPieceBitboard(type, true), 2);
            string black = Convert.ToString((long)board.GetPieceBitboard(type, true), 2);
            for(int i = 0; i < white.Length; i++){
                bit[0, count * 64 + i] = int.Parse(white.Substring(i, 1));
            }
            for(int i = 0; i < white.Length; i++){
                bit[0, count * 64 + i] = -1 * int.Parse(black.Substring(i, 1));
            }
        }
        return bit;
    }
    int[,] MatMul(int[,] a, int[,] b){
        int[,] c = new int[a.GetLength(0), b.GetLength(1)];
        for(int row = 0; row < a.GetLength(0); row++){
            for(int col = 0; col < b.GetLength(1); col++){
                int[] x = new int[a.GetLength(1)];
                int i = 0;
                foreach (var val in a)
                    x[i++] = val;
                
                int[] y = new int[b.GetLength(0)];
                i = 0;
                foreach (var val in b)
                    y[i++] = val;
                
                Vector<int> x_V = new Vector<int>(x);
                Vector<int> y_V = new Vector<int>(y);
                c[row, col] = Vector.Dot(x_V, y_V);
            }
        }
        return c;
    }
    // int ReLU(int a){
    //     return Math.Max(0, a);
    // }
    // int Dot(int[] a, int[] b){
    //     int sum = 0;
    //     for(int i = 0; i < a.GetLength(0); i++){
    //         sum += a[i] * b[i];
    //     }
	// 	return sum;
    // }

    // int[,] Transpose(int[,] a){
    //     int[,] b = new int[a.GetLength(1), a.GetLength(0)];
	// 	for(int col = 0; col < a.GetLength(1); col++){
	// 		for(int row = 0; row < a.GetLength(0); row++){
	// 			b[col, row] = a[row, col];
	// 		}
	// 	}
	// 	return b;
    // }
}