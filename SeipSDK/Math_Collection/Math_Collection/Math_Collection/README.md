## Math_Collection

This project contains all implemented classes and calculations.

### Class-Overview

* Analysis
    - AnalysisBase

* Basics
    - Basics
    - Interval

* LinearAlgebra
    - LGS
    - LinearAlgebraOperations
    
* LinearAlgebra.Vectors
    - Vector
    
* LinearAlgebra.Matrices
    - Matrices
        + Matrix
        + ProjectionMatrix
        + RotationsMatrix
        + TranslationsMatrix

* Statistic
    - Polynominal Regression  


### Feature Overview

| Method | in Class | Static | Description | Return Value |
| ------ |:--------:|:------:|:-----------:| ------------:|
| Derivation_Approximation | AnalysisBase | Y | Calculates an approximated derivation value at a specific point | double |
| ExtremaApproximatedWithFibonacciMethod | AnalysisBase | Y | Calculates an approximated extrema from a function with the fibonacci method | Vector |
| Compare | Basics | Y | Compares two objects to each other | ECompareResult |
| DegreesToRadians | Basics | Y | Transforms degree values into radian values | double |
| FibonacciSequence | Basics | Y | Calculates the fibonacci sequence numbers | int |
| Solve | LGS | N | Solves a system with linear equations | Vector |
| AddVectorToVector | LinearAlgebraOperations | Y | Adds two vectors together | Vector |
| SubtractVectorFromVector | LinearAlgebraOperations | Y | Subtracts two vectors | Vector |
| MultiplyVectorWithVector | LinearAlgebraOperations | Y | Multiplies two vectors | Vector |
| MultiplyVectorWithScalar | LinearAlgebraOperations | Y | Multiplies a vector with a scalar value | Vector |
| CalculateDotProduct | LinearAlgebraOperations | Y | Calculates the dot product of two vectors | double |
| CalculateCrossProduct | LinearAlgebraOperations | Y | Calculates the cross product of two vectors | Vector |
| MultiplyMatrixWithMatrix | LinearAlgebraOperations | Y | Multiplies two matrices together | Matrix |
| MultiplyMatrixWithVector | LinearAlgebraOperations | Y | Multiplies a matrix with a vector | Vector |
| MultiplyMatrixWithScalar | LinearAlgebraOperations | Y | Multiplies a matrix with a scalar value | Matrix |
| MultiplyMatrixWithItself | LinearAlgebraOperations | Y | Multiplies a matrix a bounch of time with itself | Matrix |
| TransposeMatrix | LinearAlgebraOperations | Y | Creates the transposed version of the matrix | Matrix |
| CalculateInverseMatrix | LinearAlgebraOperations | Y | Calculates the inverse matrix | Matrix |
| CreateRegression | PolynominalRegression | Y | Calculates a regression polynominal with a given degree | Function |
