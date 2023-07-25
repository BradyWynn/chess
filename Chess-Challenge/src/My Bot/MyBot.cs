using ChessChallenge.API;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;

public class MyBot : IChessBot
{
    public Move Think(Board board, Timer timer)
    {
        // var b = System.Numerics.BigInteger.Parse("2");
        // double[,] w1 = {{}};
        // double[,] a = FenToArray(board.GetFenString());
        // Console.Write(a * b);
        // double[,] a = {{7}, {3}, {2}};
        // double[,] b = {{7, 1, 18}};
        // double[,] c = MatMul(a, w1);
        // for(int row = 0; row < c.GetLength(0); row++){
        //     for(int col = 0; col < c.GetLength(1); col++){
        //         Console.Write(c[row, col] + ", ");
        //     }
        //     Console.Write("\n");
        // }
        // Console.WriteLine(board.GetFenString());
        Move[] moves = board.GetLegalMoves();
        for(int i = 0; i < moves.Length; i++){
            board.MakeMove(moves[i]);
            Console.Write(board.GetFenString() + "\n");
            board.UndoMove(moves[i]);
        }
        // Console.WriteLine(board.GetPieceBitboard(PieceType.Pawn, true));
        return moves[0];
    }
    // int[] BitBoardToArray(ulong bitboard){
    //     int[] bits = new int[64];
    //     int count = 0; 
    //     while(bitboard != 0){
    //         bits[count] = (int)(bitboard % 2);
    //         bitboard /= 2;
    //     }
    //     return bits;
    // } 
    // double[,] FenToArray(String fen){
    //     double[,] bitboards = new double[1, 768];
    //     int count = 0;
    //     for(int i = 0; i < fen.Length; i++){
    //         String letter = fen.Substring(i, 1);
    //         if(letter.Equals("/")){
    //             continue;
    //         }
    //         try{
    //             count += int.Parse(letter);
    //         }
    //         catch{
    //             if(letter =="p")
    //                 bitboards[0, 0 * 64 + count] = 1;
    //             if(letter == "n")
    //                 bitboards[0, 1 * 64 + count] = 1;
    //             if(letter == "r")
    //                 bitboards[0, 2 * 64 + count] = 1;
    //             if(letter == "b")
    //                 bitboards[0, 3 * 64 + count] = 1;
    //             if(letter == "q")
    //                 bitboards[0, 4 * 64 + count] = 1;
    //             if(letter == "k")
    //                 bitboards[0, 5 * 64 + count] = 1;

    //             if(letter == "P")
    //                 bitboards[0, 6 * 64 + count] = 1;
    //             if(letter == "N")
    //                 bitboards[0, 7 * 64 + count] = 1;
    //             if(letter == "R")
    //                 bitboards[0, 8 * 64 + count] = 1;
    //             if(letter == "B")
    //                 bitboards[0, 9 * 64 + count] = 1;
    //             if(letter == "Q")
    //                 bitboards[0, 10 * 64 + count] = 1;
    //             if(letter == "K")
    //                 bitboards[0, 11 * 64 + count] = 1;
    //             count += 1;
    //         }
    //         if(count == 64){
    //             break;
    //         }
    //     }
    //     return bitboards;
    // }
    // double[,] MatMul(double[,] a, double[,] b){
    //     double[,] c = new double[a.GetLength(0), b.GetLength(1)];
    //     for(int row = 0; row < a.GetLength(0); row++){
    //         for(int col = 0; col < b.GetLength(1); col++){
    //             double[] x = new double[a.GetLength(1)];
    //             for(int i = 0; i < x.Length; i++){
    //                 x[i] = a[row, i];
    //             }
    //             // Console.Write(x[0] + " " + x[1] + "\n");
    //             double[] y = new double[b.GetLength(0)];
    //             for(int i = 0; i < y.Length; i++){
    //                 y[i] = b[i, col];
    //             }
    //             // Console.Write(y[0] + " " + y[1]);
    //             c[row, col] = Dot(x, y);
    //         }
    //     }
    //     return c;
    // }
    // double Dot(double[] a, double[] b){
    //     double sum = 0;
    //     for(int i = 0; i < a.GetLength(0); i++){
    //         sum += a[i] * b[i];
    //     }
	// 	return sum;
    // }

    // double[,] Transpose(double[,] a){
    //     double[,] b = new double[a.GetLength(1), a.GetLength(0)];
	// 	for(int col = 0; col < a.GetLength(1); col++){
	// 		for(int row = 0; row < a.GetLength(0); row++){
	// 			b[col, row] = a[row, col];
	// 		}
	// 	}
	// 	return b;
    // }
}
