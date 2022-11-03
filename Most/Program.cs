using System;


public interface ITelewizor
{

    int Kanal { get; set; }
    void Wlacz();
    void Wylacz();
    void ZmienKanal(int kanal);
    void SprawdzKanal();
}



public class TvLg : ITelewizor
{

    public TvLg()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }
    private static string tv = "Telewizor LG -";

    public void Wlacz()
    {
        Console.WriteLine($"{tv} włączam się.\n");
    }

    public void Wylacz()
    {
        Console.WriteLine($"{tv} wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
        Console.WriteLine($"{tv} zmieniam kanał: {Kanal}\n");
    }
    public void SprawdzKanal()
    {
        Console.WriteLine($"Sprawdź kanał - bieżący kanał: {Kanal}\n");
    }

}



public class TvXiaomi : ITelewizor
{
    public TvXiaomi()
    {
        this.Kanal = 1;
    }

    public int Kanal { get; set; }
    private static string tv = "Telewizor Xiaomi -";

    public void Wlacz()
    {
        Console.WriteLine($"{tv} włączam się.");
    }

    public void Wylacz()
    {
        Console.WriteLine($"{tv} wyłączam się.");
    }

    public void ZmienKanal(int kanal)
    {
        Kanal = kanal;
        Console.WriteLine($"{tv} zmieniam kanał: {Kanal}");
    }
    public void SprawdzKanal()
    {
        Console.WriteLine($"Sprawdź kanał - bieżący kanał: {Kanal}\n");
    }
}



public abstract class PilotAbstrakcyjny
{

    private ITelewizor tv;

    public PilotAbstrakcyjny(ITelewizor tv)
    {
        this.tv = tv;
    }

    public void Wlacz()
    {
        tv.Wlacz();
    }
    public void Wylacz()
    {
        tv.Wylacz();
    }
    public void ZmienKanal(int kanal)
    {
        tv.ZmienKanal(kanal);
    }

}



public class PilotHarmony : PilotAbstrakcyjny
{

    public PilotHarmony(ITelewizor tv) : base(tv) { }
    private static string pilot = "Pilot Harmony -";

    public void DoWlacz()
    {
        Console.WriteLine($"{pilot} włącz telewizor...");
        Wlacz();
    }

    public void DoWylacz()
    {
        Console.WriteLine($"{pilot} wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine($"{pilot} zmienia kanał...");
        ZmienKanal(kanal);
    }
}

public class PilotLG : PilotAbstrakcyjny
{
    public PilotLG(ITelewizor tv) : base(tv) { }
    private static string pilot = "Pilot LG -";

    public void DoWlacz()
    {
        Console.WriteLine($"{pilot} zmienia kanał...");
        Wlacz();
    }
    public void DoWylacz()
    {
        Console.WriteLine($"{pilot} wyłącz telewizor...");
        Wylacz();
    }
    public void DoZmienKanal(int kanal)
    {
        Console.WriteLine($"{pilot} zmienia kanał...");
        ZmienKanal(kanal);
    }
}



class MainClass
{
    public static void Main(string[] args)
    {

        ITelewizor tv = new TvLg();
        var pilotHarmony = new PilotHarmony(tv);
        var pilotLG = new PilotLG(tv);

        pilotHarmony.DoWlacz();
        tv.SprawdzKanal();
        pilotLG.DoZmienKanal(100);
        tv.SprawdzKanal();
        pilotHarmony.DoWylacz();
    }
}