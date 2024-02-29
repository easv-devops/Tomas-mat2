namespace DefaultNamespace.MatCalculations;

public class MatTypes
{
    private ImatTypes _iMatTypes;

    
    public MatTypes(ImatTypes iMatTypes)
    {
        _iMatTypes = iMatTypes;

    }

    
    public double getValue(double a, double b)
    {
        return _iMatTypes.getValue( a, b);
    }


}