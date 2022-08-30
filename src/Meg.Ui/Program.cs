using Meg.Ui.Sheets;

namespace Meg.Ui
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(new DivisionProblemSheet(new DivisionProblemSheetConfiguration(30, 2, 1, 10)).GetProblemsSheet());

            Console.ReadLine();
        }
    }
}

/*
10 + 23 = 33                   -- equality expression
E1: 10 + 23                    -- sum expression (lhs equality expr)
E2: =                          -- operator expression
E3: 33                         -- constant expression (rhs equality expr)

3rt(1/2) * log2(8) - x = 0     -- equality expression
E1: 3rt(1/2) * log2(8) - x     -- sum expression (lhs equality expr)
E2: =                          -- operator expression
E3: 0                          -- constant expression (rhs equality expr)
E4: 3rt(1/2) * log2(8)         -- mult expression lhs E1
E5: -                          -- operator expression
E6: x                          -- literal (variable) expression rhs E1
E7: 3rt()                      -- func expression

-- types:
- constant
- operator (is it an expression ?)
- sum, mult, equality: operation expression
- literal-variable
- functional
*/
