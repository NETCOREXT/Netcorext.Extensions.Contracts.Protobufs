namespace Netcorext.Contracts.Protobufs;

public static class ValueTypeExtension
{
    public static ProtobufDecimal ToProtobufDecimal(this decimal value)
    {
        var decimalString = value.ToString("##################0.0#########").Split('.');
        var precision = Math.Abs(long.Parse(decimalString[0]));
        var scale = Math.Abs(int.Parse(decimalString[1]));

        return new ProtobufDecimal
               {
                   Precision = precision,
                   Scale = scale,
                   Minus = value < 0
               };
    }

    public static decimal ToDecimal(this ProtobufDecimal value)
    {
        var precision = Math.Abs(value.Precision);
        var scale = Math.Abs(value.Scale);
        var scaleLength = scale.ToString().Length;
        var scaleFactor = (decimal)Math.Pow(10, scaleLength);
        var absValue = precision + scale / scaleFactor;

        return value.Minus ? 0 - absValue : absValue;
    }
}