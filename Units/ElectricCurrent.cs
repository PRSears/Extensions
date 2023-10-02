namespace Extender.Units;

public abstract class ElectricCurrent : Measure
{
    public override TOut ConvertTo<TOut>()
    {
        return base.ConvertTo<TOut, ElectricCurrent>();
    }    
}