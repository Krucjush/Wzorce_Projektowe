using System;
using System.Collections.Generic;

public interface Kompozyt
{
    void Renderuj();
    void DodajElement(Kompozyt element);
    void UsunElement(Kompozyt element);
}

public class Lisc : Kompozyt
{

    public string nazwa { get; set; }

    public void Renderuj()
    {
        Console.WriteLine($"{nazwa} renderowanie...");
    }
    public Lisc(string nazwa)
    {
        this.nazwa = nazwa;
    }

    public void DodajElement(Kompozyt element)
    {
        throw new InvalidOperationException("Nie można dodawać elementów do liści");
    }
    public void UsunElement(Kompozyt element)
    {
        throw new InvalidOperationException("Nie można usuwać elementów z liści");
    }

}


public class Wezel : Kompozyt
{

    private List<Kompozyt> Lista = new List<Kompozyt>();

    public string nazwa { get; set; }

    public Wezel(string nazwa)
    {
        this.nazwa = nazwa;
    }
    
    public void DodajElement(Kompozyt element)
    {
        Lista.Add(element);
    }

    public void Renderuj()
    {
        Console.WriteLine($"{nazwa} rozpoczęcie renderowania");
        foreach (var item in Lista)
        {
            item.Renderuj();
        }
        Console.WriteLine($"{nazwa} zakończenie renderowania");
    }

    public void UsunElement(Kompozyt element)
    {
        Lista.Remove(element);
    }
}


class MainClass
{
    public static void Main(string[] args)
    {

        var korzen = new Wezel("Korzeń");
        korzen.DodajElement(new Lisc("Liść 1.1"));

        var wezel2 = new Wezel("Węzeł 2");
        wezel2.DodajElement(new Lisc("Liść 2.1"));
        wezel2.DodajElement(new Lisc("Liść 2.2"));
        wezel2.DodajElement(new Lisc("Liść 2.3"));
        korzen.DodajElement(wezel2 as Wezel);

        var wezel3 = new Wezel("Węzeł 3");
        wezel3.DodajElement(new Lisc("Liść 3.1"));
        wezel3.DodajElement(new Lisc("Liść 3.2"));

        var wezel33 = new Wezel("Węzeł 3.3");
        wezel33.DodajElement(new Lisc("Liść 3.3.1"));
        wezel3.DodajElement(wezel33 as Wezel);
        korzen.DodajElement(wezel3 as Wezel);

        korzen.Renderuj();
    }
}