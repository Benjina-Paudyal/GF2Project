using System;           // namespace til console read og write
using System.IO;        // namespace til filen
using System.Threading; // namespace til delay forsinkelse


namespace GF2FinalProjekt
{
    class Program

    {


        static int CursorPositionX = 1, CursorPositionY = 2;

        const int TelLen = 8, PostNum = 4;  // TelLen: telefonnummeret skal være 8
                                            // PostNum:postnummer skal være 4

        const string filepath = @"/Users/bhaskarkhanal/Desktop/TestFolder/tec.txt"; // filepath ( path of your own file created in your computer) 




        /* funktionserklæring for at indstille markørpositionen og vise virksomhedens navn.
         Det er statisk og vil det ikke returnere noget */


        static void Position()
        {
            Console.SetCursorPosition(CursorPositionX, CursorPositionY);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("           Christian Mørk Information Systems - Gæste-registering   ");
            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.WriteLine();


        }



        /*  funktionserklæring for at kontrollere, om det indtastede telefonnummer er på 8 cifre og postnummeret er på 4 cifre

             Det er statisk og public streng typefunktion, der returnerer integer værdie*/



        static public String ReadN_ValidityCheck(int len)
        {
            char[] arr;         // character array 
            int a;
            bool status = false;  // boolen værdi indstillet til false
            string phone = " ";   // værdi indstillet tom, så ingen affaldsværdi tages af compiler


            while (status == false) // while løkke
            {
                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                phone = Console.ReadLine();
                if (phone.Length == len)
                {

                    arr = phone.ToCharArray(0, len); // nummer til karakter array for at kontrollere bit for bit og de samlede cifre
                    foreach (char c in arr)
                    {
                        a = c - '0';
                        if (a < 10 && a > -1)   // sammenligning af det indtastede antal, hvor det er mellem 0 og 9
                        {
                            status = true;
                        }
                        else
                        {
                            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                            Console.WriteLine("Indtast kun nummer");
                            status = false;
                            break;
                        }
                    }

                }
                else
                {
                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                    Console.WriteLine("Der skal være {0} cifre ", len);
                    status = false;
                }


            }
            return (phone);

        }



        /* funktionserklæring for at kontrollere, om e-mail-adressen indeholder specialtegn '@'
           Det er statisk og public streng typefunktion  */



        static public String ReadEmailID_N_CheckSpecialChar()
        {
            char[] arr;
            bool status = false;
            string emailID = " ";
            while (status == false)
            {
                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                emailID = Console.ReadLine();
                arr = emailID.ToCharArray(0, emailID.Length);
                foreach (char c in arr)
                {
                    if (c == '@')
                    {
                        status = true;
                        return (emailID);

                    }
                    else
                    {
                        status = false;
                    }
                }
                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                Console.WriteLine("Der skal være en speciel karakter '@' ");

            }

            return (emailID);

        }



        /*  funktionserklæring for at kontrollere, om det indtastede telefonnummer er allerede i filen
            Hvis nummer er allerede i filen kan man ikke oprettes og omvendt
            Det er statisk og public boolean typefunktion, der returnerer string */

        static public bool tlfnummercheck(string nummer)
        {

            bool status = false;
            if (File.Exists(filepath))
            {
                String[] readData = File.ReadAllLines(filepath);

                foreach (string line in readData)
                {
                    if (!line.Contains(nummer))
                    {

                        status = false;

                    }
                    else
                    {
                        Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                        Console.WriteLine("Du er allerede registreret");
                        status = true;
                        return status;

                    }
                }
            }
            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.WriteLine("Ok, kan oprettes!");
            return status;
        }




        /* funktionserklæring at tage information fra gæste
         Det er statisk og publik streng type funktion */



        static public String information()

        {

            string tlfnummer, fornavn, efternavn, adresse, postnr, by, email, køn, alder;
            bool status;                                            // boolen declaration

            Console.ForegroundColor = ConsoleColor.Green;

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.WriteLine();
            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast dit telefon nummer :  ");
            tlfnummer = ReadN_ValidityCheck(TelLen);            // funktion opkald  
            status = tlfnummercheck(tlfnummer);                 // function opkald 
            if (status)
            {
                return "0";
            }

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast dit fornavn: ");
            fornavn = Console.ReadLine();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast dit efternavn: ");
            efternavn = Console.ReadLine();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast din adresse: ");
            adresse = Console.ReadLine();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast din post nummer: ");
            postnr = ReadN_ValidityCheck(PostNum);

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast din by: ");
            by = Console.ReadLine();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast din email: ");
            email = ReadEmailID_N_CheckSpecialChar();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast dit køn (m/k) : ");
            køn = Console.ReadLine();

            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Indtast din alder: ");
            alder = Console.ReadLine();

            string skrivetilfilen = tlfnummer + " ," + fornavn + "  " + efternavn + " ," + adresse + " ," + postnr + " ," + by + " ," + email + " ," + køn + " ," + alder; // string to be written in the datafile

            return (skrivetilfilen); // streng tilbage til funktionerne

        }

        /* main funktion*/

        static void Main(string[] args)
        {

            string password = "GF2projekt"; // indstil adgangskode til at se alle listen og søgte oplysninger fra filen            string valg;
            char svar;
            string skrivetilfilen, valg;
            Int16 counter = 15;         // counter indstillet til at udskrive 15 linjer med gemt information fra filen pr. side

            Position();                 // funktion opkald

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.WriteLine();
            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
            Console.Write("Hvad er dit navn?   ");
            string navn = Console.ReadLine();

            do
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                Console.WriteLine();
                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                Console.WriteLine("Hej {0},hvad vil du gøre : [o] Opret  [f] Find  [v] Vis alle  [q] Afslut", navn);

                valg = Console.ReadLine();
                valg.ToLower();



                switch (valg)
                {
                    case "o":                                       // switch case til opret og tilføj et ny tekst til en eksisterende fil
                        {
                            skrivetilfilen = information();
                            if (skrivetilfilen != "0")
                            {
                                StreamWriter file = new StreamWriter(filepath, true);
                                file.WriteLine(skrivetilfilen);
                                file.Close();
                                Console.Write("Nu er teksten gemt");
                            }
                        }
                        break;



                    case "f":                                       // switch case til at søge noget i filen  
                        {

                            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                            Console.WriteLine(" Indtast password:");
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                            string temp = Console.ReadLine();
                            Console.ResetColor();

                            if (temp == password)
                            {


                                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                Console.Write(" Hvad vil du søge efter :");
                                string search = Console.ReadLine();


                                String[] lines = File.ReadAllLines(filepath);   // læse alle linjer i filen for at søge efter den specifikke tekst
                                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                Console.WriteLine(" Fundet det du søgte efter : ");

                                foreach (String line in lines)
                                {


                                    if (line.Contains(search))
                                    {

                                        Console.WriteLine(line);
                                    }

                                }

                            }


                            else
                            {
                                Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                Console.WriteLine(" forkert kodeord ");
                            }

                        }
                        break;



                    case "v":                                       // switch case til at vise alle gemt inforamtion, 15 linjer per side fra filen
                        {
                            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                            Console.WriteLine(" Indtast password:");


                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                            string temp = Console.ReadLine();
                            Console.ResetColor();

                            if (temp == password)

                            {

                                if (File.Exists(filepath))
                                {
                                    String[] lines = File.ReadAllLines(filepath);    // læse alle linjer i filen
                                    var lineCount = File.ReadAllLines(filepath).Length; // optælling total linjer i filen

                                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                    Console.WriteLine();
                                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                    Console.WriteLine("Der er i alt {0} linier i filen", lineCount);
                                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                    Console.WriteLine();
                                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                    Console.WriteLine("Indholdet af filen er :");
                                    Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                    Console.WriteLine();

                                    foreach (String line in lines)          // for loop at viser linjer
                                    {
                                        counter--;

                                        Console.SetCursorPosition(CursorPositionX, CursorPositionY++);
                                        Console.WriteLine(line);

                                        if (counter == 0)
                                        {
                                            Console.SetCursorPosition(CursorPositionX, CursorPositionY + 3);
                                            Console.WriteLine(" Mere at vise, tryk en tast");
                                            Console.ReadKey();
                                            Console.Clear();
                                            counter = 15;
                                            CursorPositionY = 2;
                                        }
                                    }
                                }

                                else
                                {

                                    Console.Write("Filen eksisterer ikke :");

                                }
                            }

                            else
                            {

                                Console.WriteLine(" forkert kodeord ");
                            }

                        }

                        break;


                    case "q":                       // switch case hvis gæste vil ikke gør noget 
                        {
                            Console.SetCursorPosition(CursorPositionX, CursorPositionY + 1);
                            Console.WriteLine("       Tak for interesse i Christain Mørk Information Systems. Vi ses igen :)    ");

                        }
                        break;


                    default:

                        Console.SetCursorPosition(CursorPositionX, CursorPositionY++); // default switch case hvis indtast forkert key
                        Console.WriteLine(" forkert valge! prøv igen");

                        break;
                }


                Console.SetCursorPosition(CursorPositionX + 20, CursorPositionY + 60);
                Console.WriteLine(" Vil du gøre noget mere? j/n");

                svar = Console.ReadKey().KeyChar;

                Thread.Sleep(1000); // indstil forsinkelse, så gæsten kan se, om han skrev 'j' eller 'n'
                Console.Clear();
                CursorPositionY = 4;

            }
            while (svar == 'j');

        }



    }


}


