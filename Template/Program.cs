using System;

namespace Template
{
    class Program
    {
        static void Main(string[] args)
        {
            ScoringAlgoritm algoritm;

            Console.WriteLine("Mans");
            algoritm = new MensScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Woman");
            algoritm = new WomensScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.WriteLine("Children");
            algoritm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algoritm.GenerateScore(8, new TimeSpan(0, 2, 34)));

            Console.ReadLine();
        }
    }

    abstract class ScoringAlgoritm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);
            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);

        public abstract int CalculateReduction(TimeSpan time);

        public abstract int CalculateBaseScore(int hits);
    }

    class MensScoringAlgorithm : ScoringAlgoritm
    {
        #region Overrides of ScoringAlgoritm

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        #endregion
    }

    class WomensScoringAlgorithm : ScoringAlgoritm
    {
        #region Overrides of ScoringAlgoritm

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }

        #endregion
    }

    class ChildrensScoringAlgorithm : ScoringAlgoritm
    {
        #region Overrides of ScoringAlgoritm

        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }

        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }

        public override int CalculateBaseScore(int hits)
        {
            return hits * 80;
        }

        #endregion
    }
}
