using RuntimeFunctionParser.Classes.Parser;
using RuntimeFunctionParser.Classes.Threading;
using System.Collections.Generic;
using System.Threading;

namespace RuntimeFunctionParser.Classes.Calculus.Integration
{
    public class Integral
    {
        public Interval Interval { get; private set; }
        public Function IntegralBaseFunction { get; private set; }
        public double IntegralValue { get; private set; }

        private int _numberOfAreas; //This is n
        private int _numThreads = 4;
        private bool _threadsEnabled = false;

        public Integral(Interval interval, Function baseFunction, int numSteps, int threadCount, bool threadsEnabled)
        {
            Interval = interval;
            IntegralBaseFunction = baseFunction;
            _numberOfAreas = numSteps;
            _threadsEnabled = threadsEnabled;
            _numThreads = threadCount;
        }

        public void SolveIntegralNumerically()
        {
            double bMinusADividedByN = ((double)Interval[Interval.EBoundary.eBoundaryUpper] - (double)Interval[Interval.EBoundary.eBoundaryLower]) / (double)_numberOfAreas;
            //TODO: Implement Threads here
            if (_threadsEnabled)
            {
                ManualResetEvent resetEvent = new ManualResetEvent(false);
                int toProcess = _numThreads;

                // Start workers.
                for (int i = 0; i < _numberOfAreas; i += (_numberOfAreas / _numThreads))
                {
                    Thread thread = new Thread(delegate ()
                    {
                        lock (this)
                        {
                            IntegralValue += ApplyIntegralSummation(bMinusADividedByN, i);
                            if (Interlocked.Decrement(ref toProcess) == 0)
                            {
                                resetEvent.Set();
                            }
                        }
                    });
                    thread.Start();
                }
                // Wait for workers.
                resetEvent.WaitOne();
                return;
            }
            IntegralValue = ApplyIntegralSummation(bMinusADividedByN);
        }

        public double ApplyIntegralSummation(double bMinusADividedByN, int startIndex = 0)
        {
            lock(this)
            {
                double summation = 0;
                for (int k = startIndex; k <= _numberOfAreas; k++)
                {
                    summation += IntegralBaseFunction.Solve((double)Interval[Interval.EBoundary.eBoundaryLower] + (((double)k / (double)_numberOfAreas) * (double)((double)Interval[Interval.EBoundary.eBoundaryUpper] - (double)Interval[Interval.EBoundary.eBoundaryLower])), 0);
                }
                return summation * bMinusADividedByN;
            }
        }
    }
}
