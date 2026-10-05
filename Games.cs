namespace ProjectEuler
{
    internal class Games
    {
    }
    internal class Poker
    {
        public Poker() { }/*
        0* High Card: Highest value card.
        1* One Pair: Two cards of the same value.
        2* Two Pairs: Two different pairs.
        3* Three of a Kind: Three cards of the same value.
        4* Straight: All cards are consecutive values.
        5* Flush: All cards of the same suit.
        6* Full House: Three of a kind and a pair.
        7* Four of a Kind: Four cards of the same value.
        8* Straight Flush: All cards are consecutive values of same suit.
        9* Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.*/

        public bool P1Wins(string[] p1, string[] p2)
        {
            int score1 = 0;
            HashSet<char> suits = new HashSet<char>();
            Dictionary<char, int> NoOfCards = new Dictionary<char, int>();
            SortedSet<int> Values = new SortedSet<int>();
            int[] Values1 = new int[5];
            foreach (var card in p1)
            {
                suits.Add(card[1]);
                if (NoOfCards.ContainsKey(card[0]))
                {
                    NoOfCards[card[0]]++;
                }
                else
                {
                    NoOfCards.Add(card[0], 1);
                }
            }
            int index = 0;
            foreach (var pair in p1)
            {
                try
                {
                    Values.Add(int.Parse(pair[0].ToString()));
                    Values1[index] = int.Parse(pair[0].ToString());
                }
                catch
                {
                    if (pair[0] == 'T')
                    {
                        Values.Add(10);
                        Values1[index] = 10;
                    }
                    else if (pair[0] == 'J')
                    {
                        Values.Add(11);
                        Values1[index] = 11;
                    }
                    else if (pair[0] == 'Q')
                    {
                        Values.Add(12);
                        Values1[index] = 12;
                    }
                    else if (pair[0] == 'K')
                    {
                        Values.Add(13);
                        Values1[index] = 13;
                    }
                    else if (pair[0] == 'A')
                    {
                        Values.Add(14);
                        Values1[index] = 14;
                    }
                }
                index++;
            }
            if (NoOfCards.ContainsValue(2))
            {
                if (NoOfCards.ContainsValue(3))
                {
                    score1 = 6;
                }
                else
                {
                    score1 = 1;
                }
                int counter = 0;
                foreach (var item in NoOfCards)
                {
                    if (item.Value == 2)
                    {
                        counter++;
                    }
                }
                if (counter == 2 & score1 < 2)
                {
                    score1 = 2;
                }
            }
            if (NoOfCards.ContainsValue(3))
            {
                if (score1 < 3)
                {
                    score1 = 3;
                }
            }
            if (NoOfCards.ContainsValue(4))
            {
                score1 = 7;
            }
            if (Values.Count() == 5)
            {
                bool finished = true;
                for (int i = 0; i < 4; i++)
                {
                    if (Values.ElementAt(i) + 1 != Values.ElementAt(i + 1))
                    {
                        finished = false;
                        break;
                    }
                }
                if (Values.ElementAt(0) == 10 & suits.Count() == 1 & finished)
                {
                    score1 = 9;
                }
                else if (suits.Count() == 1 & finished)
                {
                    score1 = 8;
                }
                else if (score1 < 4 & finished)
                {
                    score1 = 4;
                }

            }
            if (suits.Count() == 1 & score1 < 5)
            {
                score1 = 5;
            }

            suits.Clear();
            NoOfCards.Clear();
            Values.Clear();
            int score2 = score1;
            score1 = 0;
            int[] Values2 = new int[5];
            Array.Sort(Values1);

            foreach (var card in p2)
            {
                suits.Add(card[1]);
                if (NoOfCards.ContainsKey(card[0]))
                {
                    NoOfCards[card[0]]++;
                }
                else
                {
                    NoOfCards.Add(card[0], 1);
                }
            }
            index = 0;
            foreach (var pair in p2)
            {
                try
                {
                    Values.Add(int.Parse(pair[0].ToString()));
                    Values2[index] = int.Parse(pair[0].ToString());
                }
                catch
                {
                    if (pair[0] == 'T')
                    {
                        Values.Add(10);
                        Values2[index] = 10;
                    }
                    else if (pair[0] == 'J')
                    {
                        Values.Add(11);
                        Values2[index] = 11;
                    }
                    else if (pair[0] == 'Q')
                    {
                        Values.Add(12);
                        Values2[index] = 12;
                    }
                    else if (pair[0] == 'K')
                    {
                        Values.Add(13);
                        Values2[index] = 13;
                    }
                    else if (pair[0] == 'A')
                    {
                        Values.Add(14);
                        Values2[index] = 14;
                    }
                }
                index++;
            }
            if (NoOfCards.ContainsValue(2))
            {
                if (NoOfCards.ContainsValue(3))
                {
                    score1 = 6;
                }
                else
                {
                    score1 = 1;
                }
                int counter = 0;
                foreach (var item in NoOfCards)
                {
                    if (item.Value == 2)
                    {
                        counter++;
                    }
                }
                if (counter == 2 & score1 < 2)
                {
                    score1 = 2;
                }
            }
            if (NoOfCards.ContainsValue(3))
            {
                if (score1 < 3)
                {
                    score1 = 3;
                }
            }
            if (NoOfCards.ContainsValue(4))
            {
                score1 = 7;
            }
            if (Values.Count() == 5)
            {
                bool finished = true;
                for (int i = 0; i < 4; i++)
                {
                    if (Values.ElementAt(i) + 1 != Values.ElementAt(i + 1))
                    {
                        finished = false;
                        break;
                    }
                }
                if (Values.ElementAt(0) == 10 & suits.Count() == 1 & finished)
                {
                    score1 = 9;
                }
                else if (suits.Count() == 1 & finished)
                {
                    score1 = 8;
                }
                else if (score1 < 4 & finished)
                {
                    score1 = 4;
                }

            }
            if (suits.Count() == 1 & score1 < 5)
            {
                score1 = 5;
            }
            (score1, score2) = (score2, score1);
            Array.Sort(Values2);

            if (score1 > score2)
            {
                return true;
            }
            else if (score1 < score2)
            {
                return false;
            }
            else
            {
                if (score1 == 0 || score1 == 4 || score1 == 5 || score1 == 8)
                {
                    for (int i = 4; i >= 0; i--)
                    {
                        if (Values1[i] > Values2[i])
                        {
                            return true;
                        }
                        else if (Values1[i] < Values2[i])
                        {
                            return false;
                        }
                    }
                    Console.WriteLine("tohle by se nemelo stat");
                    return true;
                }
                else if (score1 == 1 || score1 == 3 || score1 == 7)
                {
                    int value1 = 0;
                    int value2 = 0;
                    for (int i = 0; i < 4; i++)
                    {
                        if (Values1[i] == Values1[i + 1])
                        {
                            value1 = Values1[i];
                        }
                        if (Values2[i] == Values2[i + 1])
                        {
                            value2 = Values2[i];
                        }
                    }
                    if (value1 > value2)
                    {
                        return true;
                    }
                    else if (value1 < value2)
                    {
                        return false;
                    }
                    else
                    {
                        for (int i = 4; i > 0; i--)
                        {
                            if (Values1[i] > Values2[i])
                            {
                                return true;
                            }
                            if (Values1[i] < Values2[i])
                            {
                                return false;
                            }
                        }
                        Console.WriteLine("tohle by se nemelo stat");
                        return true;
                    }
                }
                else if (score1 == 2)
                {
                    int value1 = 0;
                    int value2 = 0;
                    int value11 = 0;
                    int value22 = 0;
                    for (int i = 4; i >= 0; i--)
                    {
                        if (Values1[i] == Values1[i - 1])
                        {
                            if (value1 == 0)
                            {
                                value1 = Values1[i];
                            }
                            else
                            {
                                value11 = Values1[i];
                            }
                        }
                        if (Values2[i] == Values2[i - 1])
                        {
                            if (value2 == 0)
                            {
                                value2 = Values2[i];
                            }
                            else
                            {
                                value22 = Values2[i];
                            }
                        }
                    }
                    if (value1 > value2)
                    {
                        return true;
                    }
                    else if (value1 < value2)
                    {
                        return false;
                    }
                    else
                    {
                        if (value11 > value22)
                        {
                            return true;
                        }
                        else if (value11 < value22)
                        {
                            return false;
                        }
                        else
                        {
                            for (int i = 5; i < 0; i++)
                            {
                                if (Values1[i] > Values2[i])
                                {
                                    return true;
                                }
                                if (Values1[i] < Values2[i])
                                {
                                    return false;
                                }
                            }
                            Console.WriteLine("tohle by se nemelo stat");
                            return true;
                        }
                    }
                }
                else if (score1 == 6)
                {
                    int value1 = 0;
                    int value2 = 0;
                    int value11 = 0;
                    int value22 = 0;
                    for (int i = 4; i >= 2; i--)
                    {
                        if (Values1[i] == Values1[i - 1] & Values1[i] == Values1[i - 2])
                        {
                            value1 = Values1[i];
                        }
                        if (Values2[i] == Values2[i - 1] & Values2[i] == Values2[i - 2])
                        {
                            value2 = Values2[i];
                        }
                    }
                    if (Values1[0] == value1)
                    {
                        value11 = Values1[4];
                    }
                    else
                    {
                        value11 = Values1[0];
                    }
                    if (Values2[0] == value2)
                    {
                        value22 = Values2[4];
                    }
                    else
                    {
                        value22 = Values2[0];
                    }
                    if (value1 > value2)
                    {
                        return true;
                    }
                    else if (value1 < value2)
                    {
                        return false;
                    }
                    else
                    {
                        if (value1 > value2)
                        {
                            return true;
                        }
                        else if (value1 < value2)
                        {
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("this should not happen");
                        }
                    }
                }
                Console.WriteLine("this should not happen");
                return true;
            }
        }

    }
    internal class Sudoku
    {
        int[,] plan = new int[9, 9];
        public Sudoku(string[] text)
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    plan[i, j] = int.Parse(text[i][j].ToString());
                }
            }
        }
        public bool EachCell()
        {
            bool done = false;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (plan[i, j] == 0)
                    {
                        HashSet<int> opt = new HashSet<int>();
                        HashSet<int> val = new HashSet<int>();
                        for (int k = 0; k < 9; k++)
                        {
                            val.Add(plan[i, k]);
                            val.Add(plan[k, j]);
                        }
                        for (int k = (i / 3) * 3; k < (i / 3) * 3 + 3; k++)
                        {
                            for (int i1 = (j / 3) * 3; i1 < (j / 3) * 3 + 3; i1++)
                            {
                                val.Add(plan[k, i1]);
                            }
                        }
                        for (int k = 0; k < 10; k++)
                        {
                            if (!val.Contains(k))
                            {
                                opt.Add(k);
                            }
                        }
                        if (opt.Count == 1)
                        {
                            plan[i, j] = opt.First();
                            done = true;
                        }
                    }
                }
            }
            return done;
        }
        public override string ToString()
        {
            string res = "";
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    res += plan[i, j];
                }
                res += "\n";
            }
            return res;
        }
        public bool Done()
        {
            if (plan[0, 0] != 0 && plan[0, 1] != 0 && plan[0, 2] != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Rows()
        {
            HashSet<int>[,] opt = new HashSet<int>[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    opt[i, j] = new HashSet<int>();
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (plan[i, j] == 0)
                    {
                        HashSet<int> val = new HashSet<int>();
                        for (int k = 0; k < 9; k++)
                        {
                            val.Add(plan[i, k]);
                            val.Add(plan[k, j]);
                        }
                        for (int k = (i / 3) * 3; k < (i / 3) * 3 + 3; k++)
                        {
                            for (int i1 = (j / 3) * 3; i1 < (j / 3) * 3 + 3; i1++)
                            {
                                val.Add(plan[k, i1]);
                            }
                        }
                        for (int k = 0; k < 10; k++)
                        {
                            if (!val.Contains(k))
                            {
                                opt[i, j].Add(k);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i++)
            {
                HashSet<int> Options = new HashSet<int>();
                for (int j = 0; j < 9; j++)
                {
                    foreach (var item in opt[i, j])
                    {
                        Options.Add(item);
                    }
                }
                int index;
                foreach (var item in Options)
                {
                    index = -1;
                    for (int j = 0; j < 9; j++)
                    {
                        if (opt[i, j].Contains(item))
                        {
                            if (index > -1)
                            {
                                index = -1;
                                break;
                            }
                            else
                            {
                                index = j;
                            }
                        }
                    }
                    if (index > -1)
                    {
                        plan[i, index] = item;
                    }
                }
            }
        }
        public void Columns()
        {
            HashSet<int>[,] opt = new HashSet<int>[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    opt[i, j] = new HashSet<int>();
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (plan[i, j] == 0)
                    {
                        HashSet<int> val = new HashSet<int>();
                        for (int k = 0; k < 9; k++)
                        {
                            val.Add(plan[i, k]);
                            val.Add(plan[k, j]);
                        }
                        for (int k = (i / 3) * 3; k < (i / 3) * 3 + 3; k++)
                        {
                            for (int i1 = (j / 3) * 3; i1 < (j / 3) * 3 + 3; i1++)
                            {
                                val.Add(plan[k, i1]);
                            }
                        }
                        for (int k = 0; k < 10; k++)
                        {
                            if (!val.Contains(k))
                            {
                                opt[i, j].Add(k);
                            }
                        }
                    }
                }
            }
            for (int j = 0; j < 9; j++)
            {
                HashSet<int> Options = new HashSet<int>();
                for (int i = 0; i < 9; i++)
                {
                    foreach (var item in opt[i, j])
                    {
                        Options.Add(item);
                    }
                }
                int index;
                foreach (var item in Options)
                {
                    index = -1;
                    for (int i = 0; i < 9; i++)
                    {
                        if (opt[i, j].Contains(item))
                        {
                            if (index > -1)
                            {
                                index = -1;
                                break;
                            }
                            else
                            {
                                index = i;
                            }
                        }
                    }
                    if (index > -1)
                    {
                        plan[index, j] = item;
                    }
                }
            }
        }
        public void Blocks()
        {
            HashSet<int>[,] opt = new HashSet<int>[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    opt[i, j] = new HashSet<int>();
                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (plan[i, j] == 0)
                    {
                        HashSet<int> val = new HashSet<int>();
                        for (int k = 0; k < 9; k++)
                        {
                            val.Add(plan[i, k]);
                            val.Add(plan[k, j]);
                        }
                        for (int k = (i / 3) * 3; k < (i / 3) * 3 + 3; k++)
                        {
                            for (int i1 = (j / 3) * 3; i1 < (j / 3) * 3 + 3; i1++)
                            {
                                val.Add(plan[k, i1]);
                            }
                        }
                        for (int k = 0; k < 10; k++)
                        {
                            if (!val.Contains(k))
                            {
                                opt[i, j].Add(k);
                            }
                        }
                    }
                }
            }
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    HashSet<int> Options = new HashSet<int>();
                    for (int k = 0; k < 3; k++)
                    {
                        for (int i1 = 0; i1 < 3; i1++)
                        {
                            foreach (var item in opt[i + k, j + i1])
                            {
                                Options.Add(item);
                            }
                        }
                    }
                    (int, int) index;
                    int n = 0;
                    foreach (var item in Options)
                    {
                        index = (-1, -1);
                        n = 0;
                        for (int k = 0; k < 3; k++)
                        {
                            for (int i1 = 0; i1 < 3; i1++)
                            {
                                if (opt[i, j].Contains(item))
                                {
                                    n++;
                                    index = (i + k, j + i1);
                                }
                            }
                        }
                        if (n == 1)
                        {
                            plan[index.Item1, index.Item2] = item;
                        }
                    }
                }
            }
        }
        public int Value()
        {
            int result = 0;
            result += plan[0, 0] * 100;
            result += plan[0, 1] * 10;
            result += plan[0, 2];
            return result;
        }
    }
}