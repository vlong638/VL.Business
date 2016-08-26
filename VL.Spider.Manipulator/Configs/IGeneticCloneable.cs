namespace VL.Spider.Manipulator.Configs
{
    public interface IGeneticCloneable<T>
    {
        T Clone();
    }
    public interface IGeneticCloneable<T1,T2>
    {
        T1 Clone(T2 t2);
    }
}
