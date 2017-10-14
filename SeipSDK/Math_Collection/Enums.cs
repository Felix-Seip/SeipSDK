namespace Math_Collection
{
    public class Enums
    {
        public enum EIntervalFeature
        {
            /// <summary>
            /// { x | a < x < b }
            /// </summary>
            eOpen = 0,
            /// <summary>
            /// { x | a <= x <= b }
            /// </summary>
            eClosed,
            /// <summary>
            /// { x | a < x <= b }
            /// </summary>
            eLeftOpenRightClosed,
            /// <summary>
            /// { x | a <= x < b }
            /// </summary>
            eLeftClosedRightOpen
        }

        public enum ELGSType
        {
            /// <summary>
            /// Default value. LGS is not solved yet
            /// </summary>
            eNotSolved,
            /// <summary>
            /// LGS have no solution
            /// </summary>
            eUnsolvable,
            /// <summary>
            /// LGS have just one unique solution
            /// </summary>
            eUnique,
            /// <summary>
            /// LGS have infinite solutions
            /// </summary>
            eInfinite
        }

        public enum ESolveAlgorithm
        {
            /// <summary>
            /// Uses the algorithm that is best for the given input
            /// </summary>
            eAutomatic,
            /// <summary>
            /// Solves the LGS only approximated
            /// </summary>
            eApproximated,
            /// <summary>
            /// Solves the LGS with the Gramersche Rule
            /// https://de.wikipedia.org/wiki/Cramersche_Regel
            /// </summary>
            eDeterminant,
            /// <summary>
            /// Solves the LGS with the Gauß Algorithm
            /// https://de.wikipedia.org/wiki/Gau%C3%9Fsches_Eliminationsverfahren
            /// </summary>
            eGaussianElimination,
			/// <summary>
			/// Solves the LGS with the Jacobi Algorithm (Iterativ method)
			/// <seealso cref="Gesamtschrittverfahren"/>
			/// </summary>
			eJacobi,
			/// <summary>
			/// Solves the LGS with the Gauß-Seidel Algorithm
			/// <seealso cref="Einzelschrittverfahren"/>
			/// </summary>
			eGaußSeidel
			
        }

        public enum EExtrema
        {
            /// <summary>
            /// Minimum Extrema of a function
            /// </summary>
            eMinimum,
            /// <summary>
            /// Maximum Extrema of a function
            /// </summary>
            eMaximum
        }

		public enum ECompareResult
		{
			/// <summary>
			/// Represents the compare result for two same objects
			/// </summary>
			eSame,
			/// <summary>
			/// Represents the compare result for bigger object
			/// </summary>
			eBigger,
			/// <summary>
			/// Represents the compare result for smaller object
			/// </summary>
			eSmaller
		}

    }
}
