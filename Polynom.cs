using System.Numerics;

namespace ProjectEuler
{
    internal class Polynom<T>
        where T : IAdditionOperators<T, T, T>, IMultiplyOperators<T, T, T>
    {
        private List<T> Coefs = new List<T>();
        public Polynom(List<T> coefs)
        {
            foreach (var coe in coefs)
            {
                Coefs.Add(coe);
            }
        }
        public T Evaluate(T value)
        {
            T power = value;
            T ans = Coefs[0];
            for (int i = 1; i < Coefs.Count; i++)
            {
                ans += power * Coefs[i];
                power *= value;
            }
            return ans;
        }
        public static Polynom<T> operator +(Polynom<T> a, Polynom<T> b)
        {
            Polynom<T> c;
            if (a.Coefs.Count < b.Coefs.Count)
            {
                c = new Polynom<T>(b.Coefs);

                for (int i = 0; i < a.Coefs.Count; i++)
                {
                    c.Coefs[i] += a.Coefs[i];
                }
            }
            else
            {
                c = new Polynom<T>(a.Coefs);

                for (int i = 0; i < b.Coefs.Count; i++)
                {
                    c.Coefs[i] += b.Coefs[i];
                }
            }
            return c;
        }
        public static Polynom<T> operator *(Polynom<T> a, Polynom<T> b)
        {
            Polynom<T> c = new Polynom<T>(new List<T>());
            for (int i = 0; i < a.Coefs.Count; i++)
            {
                for (int j = 0; j < b.Coefs.Count; j++)
                {
                    if (c.Coefs.Count - 1 < i + j)
                    {
                        c.Coefs.Add(a.Coefs[i] * b.Coefs[j]);
                    }
                    else
                    {
                        c.Coefs[i + j] += a.Coefs[i] * b.Coefs[j];
                    }
                }
            }
            return c;
        }
        public override string ToString()
        {
            string ans = "";
            for (int i = 0; i < this.Coefs.Count; i++)
            {
                ans += this.Coefs[i].ToString();
                ans += "x^";
                ans += i.ToString();
                if (i != Coefs.Count - 1)
                {
                    ans += "+";
                }
            }
            return ans;
        }
    }
}