//Jenny Lund-Kallberg SUT21

using System;

namespace NumbersGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isRunning = true;          //Programmet fortsätter tills användaren väljer att avsluta
            Random random = new Random();

            while (isRunning)
            {   
                //Presenterar menyn

                Console.WriteLine("Välkommen! Jag tänker på ett nummer. Kan du gissa vilket?");
                Console.WriteLine("Välj svårighetsgrad:" +
                                    "\n\t[1] Lätt" +
                                    "\n\t[2] Medium" +
                                    "\n\t[3] Svår" +
                                    "\n\t[4] Avsluta");
                bool correct = Int32.TryParse(Console.ReadLine(), out int selection); //Felhantering om användaren skriver in annat än siffra
                while (!correct)
                {
                    Console.WriteLine("Du måste ange en siffra. Tryck på valfri tangent för att återgå till menyn."); //Felmeddelande till användaren
                    Console.ReadLine();
                    break;
                }
                {
                    Console.Clear();

                    switch (selection)
                    {
                        case 1:
                            int number = random.Next(1, 11);        //Intervall 1-10 för lätt nivå i spelet
                            int attempts = 6;                       //Antal gissningar = 6 för lätt nivå i spelet
                            Program.CheckGuess(number, attempts);   //Anropar metoden CheckGuess, jämför användarens
                                                                    //gissade tal mot slumpat tal.
                            break;

                        case 2:
                            number = random.Next(1, 26);            //Intervall 1-25 för medium nivå i spelet
                            attempts = 5;                           //Antal gissningar = 5 för medium nivå i spelet
                            Program.CheckGuess(number, attempts);
                            break;


                        case 3:
                            number = random.Next(1, 51);            //Intervall 1-50 för svår nivå i spelet
                            attempts = 3;                           //Antal gissningar = 3 för svår nivå i spelet
                            Program.CheckGuess(number, attempts);
                            break;

                        case 4:
                            isRunning = false;                      //Programmet avslutas
                            break;

                        default:
                            Console.WriteLine("Ange en siffra.");   //Felmeddelande
                            break;
                    }

                    Console.Clear();

                    if (correct)
                    {
                        Console.WriteLine("Vill du spela igen?" +
                                            "\n\tJa / Nej");
                        string playAgain = Console.ReadLine().ToUpper(); //Konverterar inläst text till versaler

                        Console.Clear();

                        if (playAgain == "NEJ" || playAgain == "N")     //Om användaren vill avsluta programmet
                        {
                            Console.WriteLine("Tack för att du spelade.");
                            isRunning = false;                          //Avslutar programmet
                            break;
                        }
                        else
                        {
                            correct = false;            //Programmet fortsätter köra
                        }
                    }
                }
            }

        }
        static void CheckGuess(int number, int attempts)    //Metod för att kontrollera om användarens tal stämmer överens
                                                            //med slumpat tal
        {
            bool correctNumber = false;                      //Fortsätter loopa till villkoret inte längre är falskt
            Console.WriteLine("Du har " + attempts + " försök på dig att gissa mitt hemliga tal." +
                              "\nGissa på ett nummer.");

            Int32.TryParse(Console.ReadLine(), out int usersNumber);

            for (int guess = 1; guess < attempts; guess++)  //Loopen fortsätter tills användarens antal gissningar tagit slut
                                                            //eller användaren gissat rätt
            {
                if (usersNumber == number)                  //Om användaren gissat rätt
                {
                    Program.CorrectGuess();                 //Metod som meddelar användaren att den gissat rätt
                    correctNumber = true;
                    Console.ReadLine();
                    break;
                }

                if (usersNumber + 1 == number || usersNumber - 1 == number) //Om användaren gissat en siffra ifrån slumpat nummer
                {
                    Console.WriteLine("Det bränns.");
                }

                else if (usersNumber > number)      //Om användaren gissat för högt  
                {
                    Program.ToHigh();               //Metod som anger att användaren gissat för högt

                }
                else if (usersNumber < number)      //Om användaren gissat för lågt    
                {
                    Program.ToLow();                //Metod som anger att användaren gissat för lågt
                }
                else
                {
                    Console.WriteLine("Jag förstår inte.");
                }

                Console.WriteLine("Försök igen.");
                usersNumber = Int32.Parse(Console.ReadLine()); //Konverterar användarens tal från sträng till integer
            }
            if (correctNumber == false && usersNumber != number) //Om användaren inte lyckas gissa rätt tal och antalet gissningar är slut
            {
                Console.WriteLine("Tyvärr du lyckades inte gissa talet på " + attempts + " försök. Rätt svar är " + number + ("."));
                Console.ReadLine();
            }
            if (correctNumber == false && usersNumber == number) //Om användaren lyckas gissa rätt tal på sista försöket
            {
                Program.CorrectGuess(); //Metod som anger att användaren gissat rätt
                correctNumber = true;
                Console.ReadLine();
            }
        }
        static void ToHigh() //Metod som slumpartat skriver ut olika meddelanden till användaren om den gissat för högt.
        {
            string[] toHigh = new string[] { "Oj då, det där var lite högt! ", "Hoppsan, nu tog du i lite väl mycket! ", "För högt! ",
                                             "Bra försök, men det var för högt. ", "Försök med ett lägre tal. "};
            Random random = new Random();
            int answerNumber = random.Next(0, 5);
            Console.Write(toHigh[answerNumber]);
        }
        static void ToLow() //Metod som slumpartat skriver ut olika meddelanden till användaren om den gissat för lågt.
        {
            string[] toLow = new string[] { "För lågt. ", "Fel. Testa ett högre tal. ", "Nä, nu gissade du för lågt. ",
                                            "Åh nej, ditt tal är för lågt. ", "Bättre kan du, försök med ett högre nummer. " };
            Random random = new Random();
            int answerNumber = random.Next(0, 5);
            Console.Write(toLow[answerNumber]);
        }
        static void CorrectGuess() //Metod som slumpartat skriver ut olika meddelanden till användaren om den gissat korrekt.
        {
            string[] correct = new string[] { "Woho! Du gjorde det!!!  ", "Snyggt jobbat, du gissade rätt! "
                                            , "Grattis, du klarade det! ", "Bravo, där satt den!" , "Oj, oj, oj, du gjorde det!" };
            Random random = new Random();
            int answerNumber = random.Next(0, 5);
            Console.Write(correct[answerNumber]);
        }
    }
}