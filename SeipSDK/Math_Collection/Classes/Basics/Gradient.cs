using Math_Collection.LinearAlgebra.Vectors;
using RuntimeFunctionParser;
using Math_Collection.Exceptions;
using System;
using System.Collections.Generic;

namespace Math_Collection.Analysis
{
    public class Gradient
    {
        public Dictionary<string, Derivative> Functions;
        public Function func;
        private bool PartialDerivative = false;

        public Derivative this[string variable]
        {
            get
            {
                Derivative delegateFunc;
                Functions.TryGetValue(variable, out delegateFunc);
                return delegateFunc;
            }
        }

        public Gradient()
        {
            Functions = new Dictionary<string, Derivative>();
        }

        public Gradient(Function function, bool partialDerivative)
        {
            PartialDerivative = partialDerivative;
            Functions = new Dictionary<string, Derivative>();
            func = function;
            for (int i = 0; i < 2; i++)
            {
                if (i == 0)
                {
                    Functions.Add("x", new Derivative(function, 0.00001));
                }
                else
                {
                    Functions.Add("y", new Derivative(function, 0.00001));
                }
            }
        }

        public Gradient(Gradient v)
        {
            Functions = v.Functions;
        }

        public Vector Solve(double x, double y)
        {
            if (Functions.Count > 2)
            {
                throw new GradientException("Vector valued functions with more than 2 functions are not supported yet.");
            }

            Vector results = new Vector(new double[Functions.Count]); //Currently only goes until 2 functions
            int i = 0;
            foreach (KeyValuePair<string, Derivative> value in Functions)
            {
                if (i == 0)
                {
                    results[i] = value.Value.Solve(x, y, PartialDerivative, true);
                }
                else
                {
                    results[i] = value.Value.Solve(x, y, PartialDerivative, false);
                }
                i++;
            }
            return results;
        }
    }
}