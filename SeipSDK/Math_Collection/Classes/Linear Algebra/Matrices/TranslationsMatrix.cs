namespace Math_Collection.LinearAlgebra.Matrices
{
    public class TranslationsMatrix : Matrix
    {
        ///// <summary>
        ///// Creates a translation matrix
        ///// </summary>
        public TranslationsMatrix(double X, double Y)
        {
            Values = new double[,] { { 1, 0, X }, { 0, 1, Y }, { 0, 0, 1 } };
        }
    }
}
