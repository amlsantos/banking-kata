namespace Domain;

public class Date
{
    private readonly DateOnly _date;

    public Date(int year, int month, int day)
    {
        _date = new DateOnly(year, month, day);
    }

    public string AsString() => $"{_date.Day}.{_date.Month}.{_date.Year}";
}