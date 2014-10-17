namespace MathQuiz
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IQuizzable
    {
        int[] Numbers { get; }
        string Equation { get; }
        bool IsSolution(decimal Answer);
    }
}
