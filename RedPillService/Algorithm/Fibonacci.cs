using System;

namespace RedPillService.Algorithm
{
    public class Fibonacci
    {
        #region fields
        private static double BigPhi = (Math.Sqrt(5) + 1) / 2;
        private static double MiniPhi = BigPhi - 1;
        private static long[] G = new long[] { 1, 1, 1, 0 };
        #endregion

        #region Public methods
        /// <summary>
        /// Calculates the Nth(starting from zero) Fibonacci number using Binet’s formula
        /// </summary>
        /// <param name="n">n can range from 0 to 93</param>
        /// <returns>F(n)</returns>
        public static long FibonacciNumberByBinet(long n)
        {
            
                if (n > 92)
                    throw new ArgumentOutOfRangeException("n", "Fib(>92) will cause a 64-bit integer overflow.");
                if (n < -92)
                    throw new ArgumentOutOfRangeException("n", "Fib(<-92) will cause a 64-bit integer overflow.");


                return Convert.ToInt64((Math.Pow(BigPhi, n) - Math.Pow(-MiniPhi, n)) / Math.Sqrt(5));
           
            
        }

        /// <summary>
        /// Calculates the Nth(starting from zero) Fibonacci number matrix exponentiation method(linear recurrence method)
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>F(n)</returns>
        public static long FibonacciNumberByLogN(long n)
        {
            try
            {
                if (n <= 1)
                    return n;

                return GetFiboMatrix(n)[1];
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException("n", string.Format("Fib({0}) will cause a 64-bit integer overflow.", n));
            }
        }
        #endregion


        #region Private methods
        /// <summary>
        /// Get [[1,1][1,0]]^n matrix.
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>[[1,1][1,0]]^n</returns>
        private static long[] GetFiboMatrix(long n)
        {
            if (n == 1)
                return G;
            long[] c = GetFiboMatrix(n / 2);
            c = MatrixMul(c, c);
            if (n % 2 == 1)
                c = MatrixMul(c, G);
            return c;
        }

        private static long[] MatrixMul(long[] a, long[] b)
        {
            if (a.Length != 4 || b.Length != 4)
                throw new Exception("Invalid matrix size");

            long[] res = new long[4];
            res[0] = a[0] * b[0] + a[1] * b[2];
            res[1] = a[0] * b[1] + a[1] * b[3];
            res[2] = a[2] * b[0] + a[3] * b[2];
            res[3] = a[2] * b[1] + a[3] * b[3];
            return res;
        }
        #endregion
    }
}