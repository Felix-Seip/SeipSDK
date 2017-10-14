namespace RuntimeFunctionParser.Classes.Calculus.Integration
{
    public class Interval
    {
        private double LowerBoundary { get; set; }
        private double UpperBoundary { get; set; }

        public enum EBoundary
        {
            eBoundaryLower,
            eBoundaryUpper
        }

        public double this[EBoundary boundary]
        {
            get
            {
                switch (boundary)
                {
                    case EBoundary.eBoundaryLower:
                        return LowerBoundary;
                    case EBoundary.eBoundaryUpper:
                        return UpperBoundary;
                }
                return 0;
            }
        }

        public Interval(double lowerBoundary, double upperBoundary)
        {
            LowerBoundary = lowerBoundary;
            UpperBoundary = upperBoundary;
        }
    }
}
