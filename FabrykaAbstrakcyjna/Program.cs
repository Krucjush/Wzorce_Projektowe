using System;
using System.Text;


interface ILetters
{
    public string ShowAlfa();
}

interface INums
{
    public string ShowNum();
}


class AlphabetFactory
{

    private SystemFactory systemFactory;

    public INums numbers;
    public ILetters letters;

    public AlphabetFactory(SystemFactory systemFactory)
    {
        this.systemFactory = systemFactory;
    }

    public void Generate()
    {
        numbers = systemFactory.CreateNum();
        letters = systemFactory.CreateAlfa();
    }

}


abstract class SystemFactory
{
    public abstract ILetters CreateAlfa();

    public abstract INums CreateNum();
}


class CyrylicaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new CyrylicaLetters();
    }

    public override INums CreateNum()
    {
        return new CyrylicaNumbers();
    }
}

class GrekaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new GrekaLetters();
    }

    public override INums CreateNum()
    {
        return new GrekaNumbers();
    }
}

class LacinkaFactory : SystemFactory
{
    public override ILetters CreateAlfa()
    {
        return new LacinkaLetters();
    }

    public override INums CreateNum()
    {
        return new LacinkaNumbers();
    }
}

class GrekaLetters : ILetters
{
    string letters;
    public GrekaLetters()
    {
        letters = "αβγδε";
    }
    public string ShowAlfa()
    {
        return letters;
    }
}

class GrekaNumbers : INums
{
    string numbers;

    public GrekaNumbers()
    {
        numbers = "αʹ βʹ γʹ";
    }

    public string ShowNum()
    {
        return numbers;
    }
}


class LacinkaLetters : ILetters
{
    string letters;

    public LacinkaLetters()
    {
        letters = "abcde";
    }

    public string ShowAlfa()
    {
        return letters;
    }

}

class LacinkaNumbers : INums
{
    string numbers;
    public LacinkaNumbers()
    {
        numbers = "I II III";
    }
    public string ShowNum()
    {
        return numbers;
    }
}

class CyrylicaLetters : ILetters
{
    string letters;
    public CyrylicaLetters()
    {
        letters = "абвгд";
    }
    public string ShowAlfa()
    {
        return letters;
    }
}

class CyrylicaNumbers : INums
{
    string numbers;
    public CyrylicaNumbers()
    {
        numbers = "1 2 3";
    }
    public string ShowNum()
    {
        return numbers;
    }
}


public class Application
{
    public static void Main(String[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        AlphabetFactory alphabet_lacinka = new AlphabetFactory(new LacinkaFactory());
        AlphabetFactory alphabet_cyrylica = new AlphabetFactory(new CyrylicaFactory());
        AlphabetFactory alphabet_greka = new AlphabetFactory(new GrekaFactory());

        alphabet_lacinka.Generate();
        alphabet_cyrylica.Generate();
        alphabet_greka.Generate();

        Console.WriteLine(alphabet_lacinka.letters.ShowAlfa() + " " + alphabet_lacinka.numbers.ShowNum());
        Console.WriteLine(alphabet_cyrylica.letters.ShowAlfa() + " " + alphabet_cyrylica.numbers.ShowNum());
        Console.WriteLine(alphabet_greka.letters.ShowAlfa() + " " + alphabet_greka.numbers.ShowNum());
    }
}

