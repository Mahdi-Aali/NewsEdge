using System.Globalization;

namespace NewsEdge.Utilities.Convertor;

public static class ConvertDateToPersion
{
    public static string ToShamsi(this DateTime datetime)
    {
        PersianCalendar pc = new();
        return pc.GetYear(datetime) + "/" + pc.GetMonth(datetime).ToString("00") + "/" + pc.GetDayOfMonth(datetime).ToString("00");
    }
}
