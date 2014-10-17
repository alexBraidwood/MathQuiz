namespace MathQuiz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AdditionProblem : IQuizzable
    {
        private int[] numbers;

        public AdditionProblem(int[] Numbers)
        {
            this.Numbers = Numbers;
        }

        public int[] Numbers
        {
            get
            {
                if (this.numbers == null)
                {
                    this.numbers = new int[1];
                }
                return numbers;
            }
            private set
            {
                var sb = new StringBuilder();
                int i = 0;
                this.Solution = 0.0m;
                
                foreach (int x in value)
                {
                    i++; // Increment count

                    this.Solution += x; // Add to solution

                    if (value.Length == i)
                    {
                        sb.Append(x);
                    }
                    else
                    {
                        sb.Append(x + " + ");
                    }
                }

                this.Equation = sb.ToString(); // Store Equation
                numbers = value; // Store Numbers
                
            }
        }

        private decimal Solution { get; set; }

        public string Equation { get; private set; }
        
        public bool IsSolution(decimal Answer)
        {
            return Solution == Answer;
        }
    }
}
