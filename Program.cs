namespace ChMI;

class Program
{
    
    private static int countOfRoots;

    static double Function(double x)
    {
        return Math.Cos(x * x - x + 1);
    }

    static void Main(string[] args)
    {
        double[] segments = GetAllSegments(-3, 3);

        for(int i = 1; i < segments.Length; i++)
        {
            if (Math.Sign(Function(segments[i - 1])) != Math.Sign(Function(segments[i])))
            {
                FindRoot(segments[i - 1], segments[i]);
            }
        }
        
        Console.WriteLine("Count of roots: " + countOfRoots);
    }

    private static double[] GetAllSegments(double a, double b)
    {
        double step = 0.01;

        List<double> segments = new List<double>();

        while(a < b)
        {
            segments.Add(a);
            a += step;
        }

        return segments.ToArray();
    }
    
    private static void FindRoot(double x0, double x1)
    {
        double tolerance = 0.001;

        while (Math.Abs(Function(x1)) >= tolerance)
        {
            double x2 = x1 - (Function(x1) * (x1 - x0)) / (Function(x1) - Function(x0));

            if (Math.Sign(x1) != Math.Sign(x2))
            {
                x0 = x1;
            }
            else
            {
                x1 = x2;
            }
        }
        Console.WriteLine("The root of the function is approximately: {0}", x1);
        countOfRoots++;
    }
}