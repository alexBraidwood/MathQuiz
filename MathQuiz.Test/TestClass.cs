namespace MathQuiz.Test
{
    using System;
    using NUnit.Framework;
    using MathQuiz;

    [TestFixture]
    public class TestClass
    {
        /// <summary>
        /// Test for 2 + 2 = 4
        /// </summary>
        [TestCase]
        public void TwoPlusTwoEqualsFour()
        {
            int[] problem = new int[] { 2, 2 }; // 2 and 2
            int solution = 4; // 2 + 2 == 4

            var problems = MathGenerator.GetProblems(1, problem, ProblemType.Addition);
            Console.WriteLine(problems.Peek().Equation);
            
            Assert.IsTrue(problems.Pop().IsSolution(solution));
        }
    }
}
