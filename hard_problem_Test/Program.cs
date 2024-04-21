using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hard_problem_Test
{
    public class Solution
    {
        public int TotalNQueens(int n)
        {
            int count = 0;
            int[] board = new int[n];
            for (int i = 0; i < n; i++)
            {
                board[i] = -1;
            }
            Backtrack(board, 0, ref count);
            return count;
        }

        private bool IsSafe(int[] board, int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                if (board[i] == col || Math.Abs(board[i] - col) == row - i)
                    return false;
            }
            return true;
        }

        private void Backtrack(int[] board, int row, ref int count)
        {
            if (row == board.Length)
            {
                count++;
                return;
            }

            for (int col = 0; col < board.Length; col++)
            {
                if (IsSafe(board, row, col))
                {
                    board[row] = col;
                    Backtrack(board, row + 1, ref count);
                    board[row] = -1;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Solution solution = new Solution();

            // Example usage:
            int n = 4; // Change the value of n as needed
            int totalSolutions = solution.TotalNQueens(n);
            Console.WriteLine($"Total solutions for {n}-queens problem: {totalSolutions}");
        }
    }
}