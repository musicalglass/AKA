// Matrix.cs
//  Implementing an Overloaded Operator
using System;

class Matrix3D
{
    // its a 3D matrix
    public const int DIMSIZE = 3;
    private double[,] matrix = new double[DIMSIZE, DIMSIZE];

    // allow callers to initialize
    public double this[int x, int y]
    {
        get { return matrix[x, y]; }
        set { matrix[x, y] = value; }
    }

    // let user add matrices
    public static Matrix3D operator +(Matrix3D mat1, Matrix3D mat2)
    {
        Matrix3D newMatrix = new Matrix3D();

        for (int x=0; x < DIMSIZE; x++)
            for (int y=0; y < DIMSIZE; y++)
                newMatrix[x, y] = mat1[x, y] + mat2[x, y];

        return newMatrix;
    }
}

class MatrixTest
{
    // used in the InitMatrix method.
    public static Random rand = new Random();

    // test Matrix3D
    static void Main()
    {
        Matrix3D mat1 = new Matrix3D();
        Matrix3D mat2 = new Matrix3D();

        // init matrices with random values
        InitMatrix(mat1);
        InitMatrix(mat2);

        // print out matrices
        Console.WriteLine("Matrix 1: ");
        PrintMatrix(mat1);
        Console.WriteLine("Matrix 2: ");
        PrintMatrix(mat2);

        // perform operation and print out results
        Matrix3D mat3 = mat1 + mat2;

        Console.WriteLine();
        Console.WriteLine("Matrix 1 + Matrix 2 = ");
        PrintMatrix(mat3);
    }

    // initialize matrix with random values
    public static void InitMatrix(Matrix3D mat)
    {
        for (int x=0; x < Matrix3D.DIMSIZE; x++)
            for (int y=0; y < Matrix3D.DIMSIZE; y++)
                mat[x, y] = rand.NextDouble();
    }

    // print matrix to console
    public static void PrintMatrix(Matrix3D mat)
    {
        Console.WriteLine();
        for (int x=0; x < Matrix3D.DIMSIZE; x++)
        {
            Console.Write("[ ");
            for (int y=0; y < Matrix3D.DIMSIZE; y++)
            {
                // format the output
                Console.Write("{0,8:#.000000}", mat[x, y]);

                if ((y+1 % 2) < 3)
                    Console.Write(", ");
            }
            Console.WriteLine(" ]");
        }
        Console.WriteLine();
    }
}

