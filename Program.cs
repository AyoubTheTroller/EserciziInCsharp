using System.Globalization;

class Program{
    public static void Main(string[] args){
        START:
        Console.WriteLine("Enter the number of exercise to be tried:\n"
                        +"1: Ordinare un array di numeri in ordine decrescente.\n"
                        +"2: Trovare il numero più grande in un array.\n"
                        +"3: Calcolare la somma degli elementi in un array.\n"
                        +"4: Verificare se una parola è un'anagramma di un'altra.\n"
                        +"5: Invertire una stringa inserita dall'utente.\n"
                        +"6: Verificare se un numero inserito dall'utente è primo.\n"
                        +"7: Implementare la sequenza di Fibonacci e stampare i primi n numeri.\n"
                        +"8: Creare un semplice calcolatore di conversione valuta (con input da console).\n"
                        +"9: Generare una password casuale e mostrarla.\n"
                        +"10: Implementare una calcolatrice con le operazioni di base (+, -, *, /) basata sull'input dell'utente.\n"
                        +"11: Creare un programma di gestione delle attività giornaliere (aggiunta e visualizzazione attività tramite console).\n"
                        +"12: Simulare il lancio di un dado e mostrare il risultato, tenendo traccia delle frequenze.\n"
                        +"13: Creare una lista 'TODO' con aggiunta e rimozione di attività tramite console.\n"
                        +"14: Calcolare l'età in giorni, mesi e anni date due date inserite dall'utente.\n"
                        +"15: Implementare un convertitore di unità di misura (es. da cm a pollici) con input dell'utente.\n"
                        +"16: Creare un generatore di acronimi da una frase inserita dall'utente.\n"
                        +"17: Costruire un sistema di prenotazione per una piccola azienda (prenotazione e visualizzazione tramite console).\n"
                        +"18: Simulare un gioco di carte come il blackjack, consentendo all'utente di giocare tramite console. (oppure IA vs IA)\n"
                        +"19: Creare un'applicazione di chat testuale tra più utenti (simulando più console) con messaggi scambiati.\n"
                        +"20: Implementare un sistema di gestione di una biblioteca virtuale, consentendo la ricerca e visualizzazione dei libri tramite console.\n");
        
        START1:
        string? input = Console.ReadLine();
        
        if (int.TryParse(input, out int choice))
        {
            switch (choice)
            {
                case 1:
                    Exercise1 ex1 = new Exercise1();
                    ex1.populateAndSortArrayByUser();
                    break;
                case 2:
                    Exercise2 ex2 = new Exercise2();
                    ex2.getLargestNumberInArray();
                    break;
                case 3:
                    Exercise3 ex3 = new Exercise3();
                    ex3.getSumOfArray();
                    break;
                case 4:
                    Exercise4 ex4 = new Exercise4();
                    ex4.isAnagram();
                    break;
                case 5:
                    Exercise5 ex5 = new Exercise5();
                    ex5.invertString();
                    break;
                case 6:
                    Exercise6 ex6 = new Exercise6();
                    ex6.isPrimeNumber();
                    break;
                case 7:
                    Exercise7 ex7 = new Exercise7();
                    ex7.printFibonacciSequence();
                    break;
                case 8:
                    Exercise8 ex8 = new Exercise8();
                    ex8.convertCurrency();
                    break;
                case 9:
                    Exercise9 ex9 = new Exercise9();
                    ex9.generateRandomPassword();
                    break;
                case 10:
                    Exercise10 ex10 = new Exercise10();
                    ex10.EnterExpression();
                    break;
                case 11:
                    Exercise11 ex11 = new Exercise11();
                    ex11.manageActivities();
                    break;
                case 12:
                    Exercise12 ex12 = new Exercise12();
                    ex12.simulateDiceThrows();
                    break;
                case 14:
                    Exercise14 ex14 = new Exercise14();
                    ex14.calculateDates();
                    break;
                case 15:
                    Exercise15 ex15 = new Exercise15();
                    ex15.manageConversion();
                    break;
                case 16:
                    Exercise16 ex16 = new Exercise16();
                    ex16.manageAcronyms();
                    break;
                case 17:
                    Exercise17 ex17 = new Exercise17();
                    ex17.manageBookings();
                    break;
                case 18:
                    Exercise18 ex18 = new Exercise18();
                    ex18.playBlackJack();
                    break;
                case 19:
                    Exercise19 ex19 = new Exercise19();
                    ex19.initializeSession();
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Invalid input, please enter a number.");
            goto START1;
        }
        if (wannaKeepGoing() == true) goto START;
    }

    public static bool wannaKeepGoing(){
        Console.WriteLine("Do you want to keep trying other exercises? y or n");
        string? input = Console.ReadLine();
        return input == "y";
    }
}
