using RedPillService.Algorithm;
using System;
using System.Runtime.Serialization;

namespace RedPillService
{
    public class RedPill : IRedPill
    {

        public Guid WhatIsYourToken()
        {
            return new Guid("f327cc4d-bf61-4f49-891e-9d75754a2d8a");
        }

        public long FibonacciNumber(long n)
        {
            return Fibonacci.FibonacciNumberByBinet(n);
            //return Fibonacci.FibonacciNumberByLogN(n);
        }

        public string ReverseWords(string s)
        {
            try
            {
                return s.ReverseWords();
            }
            catch (ArgumentNullException)
            {
                throw new ArgumentNullException();
            }
        }

        public TriangleType WhatShapeIsThis(int height, int width, int length)
        {
            try
            {
                return new Triangle { Height = height, Width = width, Length = length }.Type;
            }
            catch (Exception)
            {
                throw new InvalidDataContractException();
            }
            
        }
    }
}
