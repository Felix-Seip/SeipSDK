namespace Math_Collection.LinearAlgebra.Matrices
{
    public class ProjectionsMatrix : Matrix
    {
        public ProjectionsMatrix()
        {
            double[,] array = new double[4, 4];

            //Set up the projections matrix.
            array[0, 0] = 1; array[1, 0] = 0; array[2, 0] = 0; array[3, 0] = 0;
            array[0, 1] = 0; array[1, 1] = 1; array[2, 1] = 0; array[3, 1] = 0;
            array[0, 2] = 0; array[1, 2] = 0; array[2, 2] = 0; array[3, 2] = -1 / 10;
            array[0, 3] = 0; array[1, 3] = 0; array[2, 3] = 0; array[3, 3] = 1;
            Values = array;
        }

    }
}