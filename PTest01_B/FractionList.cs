using System;

namespace PTest01_B
{
    public class FractionList
    {
        //public Fraction _header;
        //public Fraction _trailer;

        public Fraction Head { get; set; }
        public Fraction Tail { get; set; }
        public int CurrentLevel { get; set; }

        public FractionList()
        {
            Head = new Fraction(0, 1, null, null);
            Tail = new Fraction(1, 1, Head, null);
            Head.Next = Tail;
            CurrentLevel = 1;
        }
        private bool AddBetween(Fraction prev, Fraction next, int level)
        {
            if (next == null) return false;
            int resultNum = prev.Numerator + next.Numerator;
            int resultDen = prev.Denominator + next.Denominator;
            if (resultDen > level) return false;
            Console.WriteLine($"CurrentLevel: {CurrentLevel}\ninsert {resultNum}/{resultDen} level:{level} condition:{resultDen}");
            var newFraction = new Fraction(resultNum, resultDen, prev, next);
            prev.Next = newFraction;
            next.Prev = newFraction;
            CurrentLevel++;
            this.PrintFractionList();
            return true;
        }

        public void FareyExtend(int level)
        {
            var temp = Head;
            for (int i = CurrentLevel; i < level; i++)
            {
                while (temp != null)
                {
                    if (!AddBetween(temp, temp.Next,level))
                        temp = temp.Next;
                    else temp = temp.Next.Next;
                }

                temp = Head;
            }
        }
        public void PrintFractionList()
        {
            var temp = Head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Numerator}/{temp.Denominator} ");
                temp = temp.Next;
            }
        }
    }
}