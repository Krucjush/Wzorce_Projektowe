using System;

class Program
{
    private char winChar;

    public char winPerson
    {
        get { return winChar; }
        set { winChar = value; }
    }

    private bool hasWon;

    public bool isWin
    {
        get { return hasWon; }
        set { hasWon = value; }
    }

    private bool isX;

    public bool isY
    {
        get { return isX; }
        set { isX = value; }
    }

    public List<char> Box { get; } = new List<char> { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' '};
    public void WriteBoard()
    {
        Console.WriteLine(" {0} | {1} | {2} ", Box[1], Box[2], Box[3]);
        Console.WriteLine(" --------- ");
        Console.WriteLine(" {0} | {1} | {2} ", Box[4], Box[5], Box[6]);
        Console.WriteLine(" --------- ");
        Console.WriteLine(" {0} | {1} | {2} ", Box[7], Box[8], Box[9]);
    }

    public void CheckWin()
    {
        if (Box[1] == 'X' || Box[1] == 'Y')
        {
            if ((Box[2] == 'X' || Box[2] == 'Y') && Box[1] == Box[2])
            {
                if ((Box[3] == 'X' || Box[3] == 'Y') && Box[1] == Box[3])
                {
                    IsWinner(Box[3]);
                }
            }
            if ((Box[4] == 'X' || Box[4] == 'Y') && Box[1] == Box[4])
            {
                if ((Box[7] == 'X' || Box[7] == 'Y') && Box[1] == Box[7])
                {
                    IsWinner(Box[7]);
                }
            }
            if ((Box[5] == 'X' || Box[5] == 'Y') && Box[1] == Box[5])
            {
                if ((Box[9] == 'X' || Box[9] == 'Y') && Box[1] == Box[9])
                {
                    IsWinner(Box[9]);
                }
            }
        }
        if (Box[2] == 'X' || Box[2] == 'Y')
        {
            if ((Box[5] == 'X' || Box[5] == 'Y') && Box[2] == Box[5])
            {
                if ((Box[8] == 'X' || Box[8] == 'Y') && Box[1] == Box[8])
                {
                    IsWinner(Box[8]);
                }
            }
        }
        if (Box[3] == 'X' || Box[3] == 'Y')
        {
            if ((Box[6] == 'X' || Box[6] == 'Y') && Box[3] == Box[6])
            {
                if ((Box[9] == 'X' || Box[9] == 'Y') && Box[3] == Box[9])
                {
                    IsWinner(Box[9]);
                }
            }
            if ((Box[5] == 'X' || Box[5] == 'Y') && Box[3] == Box[5])
            {
                if (Box[7] == 'X' || Box[7] == 'Y' && Box[3] == Box[7])
                {
                    IsWinner(Box[7]);
                }
            }
        }
        if (Box[4] == 'X' || Box[4] == 'Y')
        {
            if ((Box[5] == 'X' || Box[5] == 'Y') && Box[4] == Box[5])
            {
                if (Box[6] == 'X' || Box[5] == 'Y')
                {
                    XWinner();
                }
            }
        }
        if (Box[7] == 'X')
        {
            if (Box[8] == 'X')
            {
                if (Box[9] == 'X')
                {
                    XWinner();
                }
            }
        }

        // 123, 456, 789, 147, 258, 369, 159, 357
        //if ((Box[1] == 'X') && (Box[2] == 'X') && (Box[3] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[4] == 'X') && (Box[5] == 'X') && (Box[6] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[7] == 'X') && (Box[8] == 'X') && (Box[9] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[1] == 'X') && (Box[4] == 'X') && (Box[7] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[2] == 'X') && (Box[4] == 'X') && (Box[8] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[3] == 'X') && (Box[6] == 'X') && (Box[9] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //} // 159, 357
        //if ((Box[1] == 'X') && (Box[5] == 'X') && (Box[9] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[3] == 'X') && (Box[5] == 'X') && (Box[7] == 'X'))
        //{
        //    isWin = true;
        //    winPerson = 'X';
        //    return;
        //}
        //if ((Box[1] == 'Y') && (Box[2] == 'Y') && (Box[3] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[4] == 'Y') && (Box[5] == 'Y') && (Box[6] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[7] == 'Y') && (Box[8] == 'Y') && (Box[9] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[1] == 'Y') && (Box[4] == 'Y') && (Box[9] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[2] == 'Y') && (Box[5] == 'Y') && (Box[8] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[3] == 'Y') && (Box[6] == 'Y') && (Box[9] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //} // 159, 357
        //if ((Box[1] == 'Y') && (Box[5] == 'Y') && (Box[9] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
        //if ((Box[3] == 'Y') && (Box[5] == 'Y') && (Box[7] == 'Y'))
        //{
        //    isWin = true;
        //    winPerson = 'Y';
        //    return;
        //}
    }
    public void IsWinner(char winner)
    {
        isWin = true;
        winPerson = winner;
        return;
    }

    public void NotVacantError()
    {
        _error = true;
        Console.WriteLine();
        Console.WriteLine("Error: box not vacant!");
        Console.WriteLine("Press any key to try again..");
        Console.ReadKey();
        return;
    }

    public void DisplayLoss()
    {
        Console.WriteLine();
        Console.WriteLine("No one won.");
        Console.ReadKey();
        Environment.Exit(1);
    }

    private bool hasError;

    public bool _error
    {
        get { return hasError; }
        set { hasError = value; }
    }

    static void Main()
    {
        int moveCount = 0; // check loss
        char askMove; // display X or Y in question
        int selTemp;
        Program prog = new Program();
        prog._error = false;
        prog.isY = true;
        Console.WriteLine(" -- Tic Tac Toe -- ");
        Console.Clear();
        while (!prog.isWin)
        {
            if (moveCount == 9)
            {
                prog.DisplayLoss();
            }
            if ((prog.isY) == true) // if is X
            {
                askMove = 'X';
            }
            else
            {
                askMove = 'Y';
            }
            Console.Clear();
            prog.WriteBoard();
            Console.WriteLine();
            Console.WriteLine("What box do you want to place {0} in? (1-9)", askMove);
            Console.Write("> ");
            selTemp = int.Parse(Console.ReadLine());
            switch (selTemp)
            {
                case 1:
                    if (prog.Box[1] == ' ')
                    {
                        prog.Box[1] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 2:
                    if (prog.Box[2] == ' ')
                    {
                        prog.Box[2] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 3:
                    if (prog.Box[3] == ' ')
                    {
                        prog.Box[3] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 4:
                    if (prog.Box[4] == ' ')
                    {
                        prog.Box[4] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 5:
                    if (prog.Box[5] == ' ')
                    {
                        prog.Box[5] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 6:
                    if (prog.Box[6] == ' ')
                    {
                        prog.Box[6] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 7:
                    if (prog.Box[7] == ' ')
                    {
                        prog.Box[7] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 8:
                    if (prog.Box[8] == ' ')
                    {
                        prog.Box[8] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                case 9:
                    if (prog.Box[9] == ' ')
                    {
                        prog.Box[9] = askMove;
                        moveCount++;
                    }
                    else
                    {
                        prog.NotVacantError();
                    }
                    break;
                default:
                    Console.WriteLine("Wrong selection entered!");
                    Console.WriteLine("Press any key to try again..");
                    Console.ReadKey();
                    prog._error = true;
                    break;
            }
            if (prog._error)
            {
                prog.CheckWin(); // if error, just check win
                prog._error = !prog._error;
            }
            else
            {
                prog.isY = !prog.isY; // flip boolean
                prog.CheckWin();
            }
        }
        Console.Clear();
        prog.WriteBoard();
        Console.WriteLine();
        Console.WriteLine("The winner is {0}!", prog.winPerson);
        Console.ReadKey();
    }
}