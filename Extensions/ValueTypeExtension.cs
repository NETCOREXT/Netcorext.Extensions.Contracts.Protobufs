namespace Netcorext.Contracts.Protobufs;

public static class ValueTypeExtension
{
    private static readonly int Fill = (int)Math.Pow(10, 8);
    
    public static ProtobufDecimal ToProtobufDecimal(this decimal value)
    {
        var precision = (long)Math.Truncate(value);
        var scale = (int)((value - precision) * Fill);

        return new ProtobufDecimal
               {
                   Precision = Math.Abs(precision),
                   Scale = Math.Abs(scale),
                   Minus = value < 0
               };
    }

    public static decimal ToDecimal(this ProtobufDecimal value)
    {
        var precision = Math.Abs(value.Precision);
        var scale = (decimal)Math.Abs(value.Scale) / Fill;
        var absValue = precision + scale;

        return value.Minus ? 0 - absValue : absValue;
    }
}