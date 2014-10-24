namespace MathQuiz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class MultiplicationProblem : IQuizzable
    {
        private int[] numbers;

        public MultiplicationProblem(int[] Numbers)
        {
            this.Numbers = Numbers;
        }

        public int[] Numbers
        {
            get
            {
                if (numbers == null)
                {
                    numbers = new int[1];
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
                    i++;

                    if (this.Solution == 0)
                    {
                        this.Solution += x;
                    }
                    else
                    {
                        this.Solution *= x;
                    }

                    if (value.Length == i)
                    {
                        sb.Append(x);
                    }
                    else
                    {
                        sb.Append(x + " x ");
                    }
                }

                this.Equation = sb.ToString();
                numbers = value;
            }
        }

        private decimal Solution { get; set; }

        public string Equation { get; private set; }
        
        public bool IsSolution(decimal Answer)
        {
            return Answer == Solution;
        }
    }
}
