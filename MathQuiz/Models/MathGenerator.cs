namespace MathQuiz
{
    using System;
    using System.Collections.Generic;

    public static class MathGenerator
    {
        private static int MIN = 1;
        private static int MAX = 50;

        private static readonly Random RNG = new Random();

        //public static Stack<IQuizzable> GetProblems(int Count, int NumberOfNumbers, params ProblemType[] Types)
        //{
        //    // Todo: Do RNG for # of Numbers
        //    Random rng = new Random(); // Default seed is fine
        //    var numberArray = new Stack<int>();

        //    for (int i = 0; i < NumberOfNumbers * Count; ++i)
        //    {
        //        numberArray.Push(rng.Next(1, 40));
        //    }

        //    // Todo: Send a filled array
        //    return GetProblems(Count, numberArray.ToArray(), Types);
        //}

        public static Stack<IQuizzable> GetProblems(int Count, int NumberOfNumbers, params ProblemType[] Types)
        {
            Stack<IQuizzable> results = new Stack<IQuizzable>();
            int distribution = Count / Types.Length;
            int leftOver = Count % Types.Length;

            foreach (var type in Types)
            {
                for (int i = 0; i < distribution; ++i)
                {
                    results.Push(GetProblem(type, NumberOfNumbers));
                }
            }

            while (leftOver > 0)
            {
                Random rng = new Random();
                ProblemType type = (ProblemType)rng.Next((int)ProblemType.Addition, (int)ProblemType.Division);
                results.Push(GetProblem(type, NumberOfNumbers));
            }

            
            return results;
        }

        private static IQuizzable GetProblem(ProblemType type, int NumberCount)
        {
            var numList = new Stack<int>();

            for (int i = 0; i < NumberCount; ++i)
            {
                numList.Push(RNG.Next(MIN, MAX));
            }

            switch (type)
            {
                case ProblemType.Addition:
                    return new AdditionProblem(numList.ToArray());
                case ProblemType.Subtraction:
                    return new SubtractionProblem(numList.ToArray());
                case ProblemType.Multiplication:
                    break;
                case ProblemType.Division:
                    break;
            }

            throw new ArgumentException();
        }
    }
}
