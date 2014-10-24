namespace MathQuiz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class DivisionProblem : IQuizzable
    {
        private int[] numbers;

        public DivisionProblem(int[] Numbers)
        {
            int maxVal = 12;
            List<int> nums = new List<int>();
            foreach (var x in Numbers)
            {
                nums.Add(x % maxVal + 1);
            }
            this.Numbers = nums.ToArray();
        }

        private decimal Solution { get; set; }

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

                foreach (int x in value.OrderByDescending(x => x))
                {
                    i++;

                    if (i > 1)
                    {
                        this.Solution /= x;
                    }
                    else
                    {
                        this.Solution += x;
                    }

                    if (value.Length == i)
                    {
                        sb.Append(x);
                    }
                    else
                    {
                        sb.Append(x + " ÷ ");
                    }
                }

                this.Solution = decimal.Round(this.Solution, 2);
                this.Equation = sb.ToString();
                numbers = value;
            }
        }

        public string Equation { get; private set; }

        public bool IsSolution(decimal Answer)
        {
            return Answer == Solution;
        }
    }
}
