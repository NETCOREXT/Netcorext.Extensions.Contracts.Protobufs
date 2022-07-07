using System.Globalization;

namespace Netcorext.Contracts.Protobufs;

public static class ValueTypeExtension
{
    public static ProtobufDecimal ToProtobufDecimal(this decimal value)
    {
        var decimalString = value.ToString("##################0.0#########").Split('.');
        var precision = long.Parse(decimalString[0]);
        var scale = int.Parse(decimalString[1]);
        
        return new ProtobufDecimal
               {
                   Precision = precision,
                   Scale = scale
               };
    }

    public static decimal ToDecimal(this ProtobufDecimal value)
    {
        var precision = value.Precision;
        var scale = value.Scale;
        var scaleLength = value.Scale.ToString().Length;
        var scaleFactor = (decimal)Math.Pow(10, scaleLength);

        return precision + scale / scaleFactor;
    }
}