
namespace ProjectEuler
{
    internal class text
    {
        public text()
        {

        }
        private string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        private Dictionary<char, int> AlphabetValues = new Dictionary<char, int> {{'A', 1}, {'B', 2}, {'C', 3}, {'D', 4}, {'E', 5}, {'F', 6}, {'G', 7}, {'H', 8}, {'I', 9}, {'J', 10},
            {'K', 11}, {'L', 12}, {'M', 13}, {'N', 14}, {'O', 15}, {'P', 16}, {'Q', 17}, {'R', 18}, {'S', 19}, {'T', 20},
            {'U', 21}, {'V', 22}, {'W', 23}, {'X', 24}, {'Y', 25}, {'Z', 26} };

        public int AlphValueOfWord(string word)
        {
            int value = 0;
            foreach (char Ch in word)
            {
                value += AlphabetValues[Ch];
            }
            return value;
        }
        public string transformLExprv2(string expr)
        {
            int A = 0;
            Stack<(string, string)> stack = new Stack<(string, string)>();
            stack.Push((expr, ""));
            expr = "";
            long k = 0;
            long sum = 0;
            int min = stack.Count;
            int max = stack.Count;
            while (stack.Count > 0)
            {
                sum += expr.Length;
                if (stack.Count < min)
                {
                    min = stack.Count;
                }
                if (stack.Count > max)
                {
                    max = stack.Count;
                }
                k++;

                if (k % 1048576 == 0)
                {
                    Console.WriteLine($"{k} {A} {(double)sum / 1048576} {min} {max} {stack.First()}");
                    sum = 0;
                    min = stack.Count;
                    max = stack.Count;
                }

                (string, string) temp1 = stack.Pop();
                expr = temp1.Item1 + expr + temp1.Item2;
                Stack<(char, int, int)> S = new Stack<(char, int, int)>();
                (char, int, int) current = (expr[0], 0, 0);
                bool done = false;

                for (int i = 1; i < expr.Length - 1; i++)
                {
                    switch (expr[i])
                    {
                        case 'S':
                            S.Push(current);
                            current = ('S', i, 0);
                            break;
                        case 'Z':
                            S.Push(current);
                            current = ('Z', i, 0);
                            break;
                        case 'A':
                            S.Push(current);
                            current = ('A', i, 0);
                            break;
                        case '(':
                            current.Item3++;
                            if (DoneFunction(expr, current))
                            {
                                done = true;
                            }
                            break;
                        case ')':
                            current = S.Pop();
                            break;
                    }
                    if (done)
                    {
                        break;
                    }
                }
                if (done)
                {
                    string beg = "";
                    string[] mid = new string[current.Item3];
                    string end = "";
                    int brack = 1;
                    for (int i = 0; i < current.Item2; i++)
                    {
                        beg += expr[i];
                    }
                    int index = 0;
                    int j = current.Item2 + 2;
                    while (index < current.Item3)
                    {
                        if (brack == 0)
                        {
                            index++;
                            if (index == current.Item3)
                            {
                                break;
                            }
                            j++;
                            brack++;
                        }
                        if (expr[j] == '(')
                        {
                            brack++;
                        }
                        else if (expr[j] == ')')
                        {
                            brack--;
                        }
                        if (brack != 0)
                        {
                            mid[index] += expr[j].ToString();
                        }
                        j++;
                    }
                    for (int i = j; i < expr.Length; i++)
                    {
                        end += expr[i].ToString();
                    }
                    if (beg.Length > 0 || end.Length > 0)
                    {
                        stack.Push((beg, end));
                    }
                    if (current.Item1 == 'S')
                    {
                        stack.Push((mid[1] + "(", ")"));
                        stack.Push(("", ""));
                        expr = mid[0] + "(" + mid[1] + ")(" + mid[2] + ")";
                    }
                    else if (current.Item1 == 'Z')
                    {
                        expr = mid[1];
                    }
                    else if (current.Item1 == 'A')
                    {
                        A++;
                        A %= 1000000000;
                        expr = mid[0];
                    }
                }
            }
            Console.WriteLine(A);
            return expr;
        }

        static bool DoneFunction(string expr, (char, int, int) current)
        {
            return (current.Item1 == 'A' && current.Item3 == 1) ||
                   (current.Item1 == 'Z' && current.Item3 == 2) ||
                   (current.Item1 == 'S' && current.Item3 == 3);
        }
    }
    internal class Lexpr
    {
        public char index;
        public char Lead;
        private List<Lexpr> Brackets = new List<Lexpr>();
        public int A = 0;
        public Lexpr(char lead)
        {
            Lead = lead;
        }
        public Lexpr(char lead, List<Lexpr> brackets)
        {
            Lead = lead;
            for (int i = 0; i < brackets.Count; i++)
            {
                Brackets.Add(new Lexpr(brackets[i]));
            }
        }
        public Lexpr(Lexpr A)
        {
            this.Lead = A.Lead;
            this.index = A.index;
            for (int i = 0; i < A.Brackets.Count; i++)
            {
                this.Brackets.Add(new Lexpr(A.Brackets[i]));
            }
        }
        public Lexpr(string u)
        {
            Lead = u[0];
            index = u[1];
            List<string> brack = [""];
            int i = 0;
            int stack = 0;
            foreach (char c in u)
            {
                if (c == '(')
                {
                    stack++;
                }
                else if (c == ')')
                {
                    stack--;
                    if (stack == 0)
                    {
                        brack.Add("");
                        i++;
                    }
                }
                if (stack != 0 && !(stack == 1 && c == '('))
                {
                    brack[i] += c.ToString();
                }
            }
            foreach (var item in brack)
            {
                if (item.Length == 0)
                {

                }
                else if (item.Length == 1)
                {
                    Brackets.Add(new Lexpr(item[0]));
                }
                else
                {
                    Brackets.Add(new Lexpr(item));
                }
            }
        }
        public (Lexpr, Lexpr) operation()
        {
            switch (Lead)
            {
                case 'A':
                    if (Brackets.Count < 1)
                    {
                        return (null, null);
                    }
                    Lead = Brackets[0].Lead;
                    index = Brackets[0].index;
                    A += Brackets[0].A + 1;
                    Brackets = Brackets[0].Brackets;
                    A %= 1000000000;
                    return (null, null);
                case 'Z':
                    if (Brackets.Count < 2)
                    {
                        return (null, null);
                    }
                    A += Brackets[1].A;
                    A %= 1000000000;
                    Lead = Brackets[1].Lead;
                    index = Brackets[1].index;
                    Brackets = Brackets[1].Brackets;
                    return (null, null);
                case 'S':
                    if (Brackets.Count < 3)
                    {
                        return (null, null);
                    }
                    Lead = Brackets[1].Lead;
                    index = Brackets[1].index;
                    Lexpr u = Brackets[0];
                    u.Brackets.Add(new Lexpr(Brackets[1]));
                    u.Brackets.Add(Brackets[2]);
                    List<Lexpr> l = new List<Lexpr>();
                    for (int i = 3; i < Brackets.Count; i++)
                    {
                        l.Add(Brackets[i]);
                    }
                    Brackets = Brackets[1].Brackets;
                    Brackets.Add(u);
                    for (int i = 0; i < l.Count; i++)
                    {
                        Brackets.Add(l[i]);
                    }
                    return (this, u);
            }
            return (null, null);
        }
        public int CountA()
        {
            int sum = A;
            foreach (var item in Brackets)
            {
                sum += item.CountA();
                sum %= 1000000000;
            }
            return sum;
        }
        public override string ToString()
        {
            string res = Lead.ToString() + index.ToString();
            foreach (var item in Brackets)
            {
                res += "(" + item.ToString() + ")";
            }
            return res;
        }
    }
}