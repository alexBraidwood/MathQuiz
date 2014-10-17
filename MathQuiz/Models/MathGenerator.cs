namespace MathQuiz
{
    using System;
    using System.Collections.Generic;

    public static class MathGenerator
    {
        public static Stack<IQuizzable> GetProblems(int Count, int NumberOfNumbers, params ProblemType[] Types)
        {
            // Todo: Do RNG for # of Numbers
            Random rng = new Random(); // Default seed is fine
            var numberArray = new Stack<int>();

            for (int i = 0; i < NumberOfNumbers; ++i)
            {
                numberArray.Push(rng.Next(0, 100));
            }

            // Todo: Send a filled array
            return GetProblems(Count, numberArray.ToArray(), Types);
        }

        public static Stack<IQuizzable> GetProblems(int Count, int[] Numbers, params ProblemType[] Types)
        {
            Stack<IQuizzable> results = new Stack<IQuizzable>();
            int distribution = Count / Types.Length;
            int leftOver = Count % Types.Length;

            foreach (var type in Types)
            {
                switch (type)
                {
                    case ProblemType.Addition:
                        for (int i = 0; i < distribution; ++i)
                        {
                            results.Push(GetProblem(type, Numbers));
                        }
                        break;
                    case ProblemType.Subtraction:
                        break;
                    case ProblemType.Multiplication:
                        break;
                    case ProblemType.Division:
                        break;
                }
            }

            while (leftOver > 0)
            {
                Random rng = new Random();
                ProblemType type = (ProblemType)rng.Next((int)ProblemType.Addition, (int)ProblemType.Division);
                results.Push(GetProblem(type, Numbers));
            }

            return results;
        }

        private static IQuizzable GetProblem(ProblemType type, int[] Numbers)
        {
            switch (type)
            {
                case ProblemType.Addition:
                    return new AdditionProblem(Numbers);
                case ProblemType.Subtraction:
                    break;
                case ProblemType.Multiplication:
                    break;
                case ProblemType.Division:
                    break;
            }

            throw new ArgumentException();
        }
    }
}
