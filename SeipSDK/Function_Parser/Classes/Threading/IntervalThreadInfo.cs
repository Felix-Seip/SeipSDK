namespace RuntimeFunctionParser.Classes.Threading
{
    public class IntervalThreadInfo
    {
        public double IntervalDividedByN { get; private set; }
        public int StartIndex { get; private set; }
        public IntervalThreadInfo(double bMinusADividedByN, int startIndex = 1)
        {
            IntervalDividedByN = bMinusADividedByN;
            StartIndex = startIndex;
        }
    }
}
