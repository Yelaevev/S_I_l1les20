using System;
using System.Collections.Generic;

namespace Level1Space
{
    public static class Level1
    {
        public static void MatrixTurn(string []Matrix,int M,int N,int T)
        {
            ///
            ////<проверка условий четности наименьшего числа>
            //
            bool flag =true;
            if (M<N)
            {
                if (M % 2 != 0) flag = false;
              
            }

            else
            {
                if (N % 2 != 0) flag = false;
            }

            /////
            ////<находим границу симметрии>
            int Board;
            if (N < M) Board = N / 2;
            else Board = M / 2;

            ////<переводим массив строк в матрицу элементов >
            char[,] Matrix_move = new char[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Matrix_move[i, j] = Matrix[i][j];
                }
            }
            if (flag)
            {
                while (T > 0)
                {
                    int b = 0;

                    while (b < Board)
                    {
                        
                        ////< узловые точки матрицы >
                        char Temp00 = Matrix_move[b, b];
                        char TempM0 = Matrix_move[M - b - 1, b];
                        char TempNM = Matrix_move[M - b - 1, N - b - 1];
                        char Temp0N = Matrix_move[b, N - b - 1];
                        // Console.WriteLine(TempNM + " =нижний правый угол");
                        // Console.WriteLine(Temp0N + " =верхний правый угол");
                        // Console.WriteLine(TempM0 +" =нижний левый угол");

                        ///
                        ///<  сдвиг  вверхнихстрок слева направа>
                       
                        int Board00 = N -  b - 1;
                        for (int i = 0; i < Board00; i++)
                        {
                            char temp1 = Matrix_move[b, i + 1];
                            Matrix_move[b, i +1] = Temp00;
                            Temp00 = temp1;
                            ////Matrix_move[i + b + 1, b] = Matrix_move[i + b, b];
                            //Matrix_move[b,i + b ] = Matrix_move[b,i + b+1];
                            //Matrix_move[b, i + b+1] = temp;
                        }
                       

                        int Board0N = M - 2 * b - 1;
                        for (int i = 0; i < Board0N; i++)
                        {
                            char temp1 = Matrix_move[b + i + 1, N - 1 - b];
                            char view = Matrix_move[b + i, N - 1 - b];
                            Matrix_move[b + i + 1, N - 1 - b] = Temp0N;
                            Temp0N = temp1;

                        }

                        int BoardNM = N - b - 1;
                        for (int i = BoardNM; i > b; i--)
                        {
                            char temp1 = Matrix_move[M - 1 - b, i - 1];
                            Matrix_move[M - 1 - b, i - 1] = TempNM;
                            TempNM = temp1;

                        }

                        int Board0M = M - b - 1;
                        for (int i = Board0M; i > b; i--)
                        {
                            char temp1 = Matrix_move[i - 1, b];
                            char view = Matrix_move[i - 1, b];
                            Matrix_move[i - 1, b] = TempM0;
                            TempM0 = temp1;

                        }

                        b++;
                    }
                    T--;
                }
            }
            

            for (int i = 0; i < Matrix.Length; i++)
            {
                string templine = "!";
                for (int j = 0; j < N; j++)
                {
                    char view = Matrix_move[i, j];
                    templine = templine.Insert(templine.Length, Convert.ToString(Matrix_move[i, j]));
                   
                }
                templine = templine.Remove(0, 1);
                Matrix[i]=templine;
            }

           // foreach (string t in Matrix) Console.WriteLine(t);



        }
        //static void Main(string[] args)
        //{
        //    string[] Matrix = new string[2];
        //    Matrix[0] = "12";
        //    Matrix[1] = "45";
        //    //Matrix[2] = "789e";
        //    //Matrix[3] = "456t";
        //    //Matrix[4] = "aaaaaa";
        //    //Matrix[5] = "bbbbbb";
        //    //Matrix[6] = "cccccc";
        //    //Matrix[7] = "dddddd";
        //    int N = Matrix[0].Length;
        //    int M = Matrix.Length;


        //    foreach (string t in Matrix) Console.WriteLine(t);
        //    MatrixTurn(new string[] { "12", "45" }, Matrix.Length,Matrix[1].Length,1);
        //    Console.WriteLine();
        //    foreach (string t in Matrix) Console.WriteLine(t);

        //}
    }
}
