/*
 A – Rispondi alle seguenti domande argomentando la risposta:

    1) Che cos’è un oggetto?
        
        Un oggetto è un'entità concreta creata a partire da una classe,  un'istanza unica con caratteristiche (attributi) e comportamenti (metodi) definiti dalla classe. 
        È la realizzazione pratica di un modello astratto (la classe).

    2) Che cos’è una classe?
        
        è un modello astratto che descrive un pezzo di realtà, con sue caratteristiche (attributi) e comportamenti (metodi) 
        
    3) Quali sono gli operatori di confronto?
    
        particolari tipologie di operatori che vengono utilizzati per confrontare variabili:

            * ( == , != )  => per stringhe,numeri, date, oggetti
            * ( <, >, <=, >= )  => per numeri, date, oggetti comparabili

    4) Cosa si intende per istanza?
        
        La creazione effettiva di un oggetto basato su una classe.
        
    5) Cos’è un attributo?
        
        è una caratteristica di una classe.

        In altre parole, un attributo è una variabile che viene definita all'interno di una classe e che descrive lo stato di un'istanza di quella classe.

    6) Cos’è un metodo e a cosa serve?
        
        Un metodo è una funzione che è definita all'interno di una classe e descrive un comportamento o un'azione che un'istanza di quella classe può compiere.
        
    7) Qual è la firma di un metodo?
        
        la firma di un metodo comprende i dati di input (parametri) che vengono passati al metodo, ma anche il nome del metodo, la quantità e il tipo degli argomenti.

    8) Definisci la differenza tra un metodo statico e un metodo d’istanza.
        
        metodo d'istanza: metodo che opera sull'istanza di una classe, quindi ha bisogno che venga prima definita l'istanza per poter essere chimato tramite la stessa.
                          Ha accesso agli attributi e ai metodi dell'oggetto specifico su cui viene invocato.

        metodo statico: non dipende da alcuna istanza della classe ma appartiene alla classe stessa. Non ha bisogno di un oggetto specifico per essere invocato ma 
                        può essere invocato sulla classe e non ha accesso agli attributi dell'istanza

    9) Che cos’è un costruttore?

         Un costruttore è un metodo speciale di una classe che ha il compito di inizializzare un oggetto al momento della sua creazione.

    10) A cosa serve l’operatore new?

        Viene usato per allocare memoria per un nuovo oggetto
--------------------------------------------------------------------------


    B – Esercizi C#

        1) Sviluppare un programma che rispetti i seguenti requisiti:
            o L'utente potrà digitare 2 numeri da tastiera
            o Ne verrà eseguita la moltiplicazione
            o Si visualizzerà il risultato in console

        2) Sviluppare un programma che:
            o Presi in input da tastiera due numeri con la virgola, ne restituisce la somma
            o Richiesti in input da tastiera nome e cognome, restituisce: "Il tuo nome è <nome>, il tuo cognome è <cognome>
            o Presi in input da tastiera 4 numeri interi, restituisce la loro somma moltiplicata per 10
            o Presa in input da tastiera una stringa, la restituisce tra parentesi quadre utilizzando l’interpolazione di stringhe

        3) Definire una classe che rappresenti il conto corrente. Ogni istanza deve contenere il codice IBAN
        (27 caratteri alfanumerici), il nome, il cognome e il codice fiscale del titolare, il saldo e lo
        scoperto (il massimo saldo passivo ammesso). Definire inoltre i metodi per accedere a ciascuno
        di tali valori, per assegnare un nuovo scoperto, per modificare il saldo dopo un versamento e un
        prelievo.

        4) Creare una classe che rappresenti una automobile e dotarla degli attributi che si reputino
        necessari. Nella classe dovranno inoltre essere presenti dei metodi necessari per eseguire le
        seguenti azioni:
            a. Mostrare i litri di carburante rimasto
            b. Mostrare i chilometri percorsi
            c. Simulare un viaggio (percorrere quindi un certo quantitativo di km e diminuire il
            livello di carburante nel serbatoio). Consiglio: potrebbe essere utile inserire un
            attributo che indichi il consumo per chilometri percorso
            d. Rifornire il serbatoio dell’auto di un quantitativo in litri

        5) Creare almeno due istanze della classe Automobile e mostrare qualche esempio.
*/

using System.Text.RegularExpressions;

namespace csharp_C_D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ESERCIZIO 1
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("ESERCIZIO 1\n");

            Moltiplicazione();

            // ESERCIZIO 2
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("ESERCIZIO 2\n");

            double risultato = Somma();

            Console.WriteLine("\nLa somma sarà {0}\n", risultato);

            StampaStringa();

            int num1, num2, num3, num4;

            Console.WriteLine("\nInserire il primo numero:\n");

            while (!int.TryParse(Console.ReadLine(), out num1))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero");
            }

            Console.WriteLine("\nInserire il secondo numero:\n");

            while (!int.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero");
            }

            Console.WriteLine("\nInserire il terzo numero:\n");

            while (!int.TryParse(Console.ReadLine(), out num3))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero");
            }

            Console.WriteLine("\nInserire il quarto numero:\n");

            while (!int.TryParse(Console.ReadLine(), out num4))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero");
            }

            int risultato2 = SommaInteriConMolt(ref num1, ref num2, ref num3, ref num4);

            Console.WriteLine("\nLa somma dei quattro numeri moltiplicata per 10 sarà: {0}\n", risultato2);

            Console.WriteLine(InterpString());

            // ESERCIZIO 3
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("ESERCIZIO 3\n");


            ContoBancario conto = new ContoBancario("IT60X0542811101087055123456", "Luca", "Bianchi", "PFT567OIU77WW11", 3755, 780);

            // Mostra le informazioni del conto
            conto.MostraInfoConto();

            // Esegui un versamento
            Console.WriteLine("\nEsegui un versamento di 200...\n");
            conto.Versamento(200);
            conto.MostraInfoConto();

            // Esegui un prelievo (restituisce valore errato)
            Console.WriteLine("\nEsegui un prelievo di 5000...\n");
            conto.Prelievo(5000);
            conto.MostraInfoConto();

            // Assegna un nuovo scoperto
            Console.WriteLine("\nAssegna un nuovo scoperto di 1000...\n");
            conto.AssegnaScoperto(1000);
            conto.MostraInfoConto();

            // ESERCIZIO 4
            Console.WriteLine("---------------------------------------------------\n");
            Console.WriteLine("ESERCIZIO 4\n");

            // Creazione di due istanze della classe Automobile

            Automobile auto1 = new Automobile("Fiat", "Panda", 40, 0.06, 50);
            Automobile auto2 = new Automobile("Volkswagen", "Golf", 60, 0.07, 60);

            // Esempio di utilizzo per la prima automobile
            Console.WriteLine("Auto 1: Fiat Panda");
            auto1.MostraQuantCarburante();
            auto1.MostraNumKilo();
            auto1.FaiViaggio(300);
            auto1.MostraNumKilo();
            auto1.Rifornisci(10);
            auto1.MostraNumKilo();

            // Esempio di utilizzo per la seconda automobile
            Console.WriteLine("\nAuto 2: Volkswagen Golf");
            auto2.MostraQuantCarburante();
            auto2.MostraNumKilo();
            auto2.FaiViaggio(500);
            auto2.MostraQuantCarburante();
            auto2.Rifornisci(20);
            auto2.MostraQuantCarburante();


        }

        static void Moltiplicazione()
        {
            double num1, num2;

            Console.WriteLine("\nInserire primo numero con la virgola:\n");

            //Ciclo per verificare che il numero digitato abbia la parte decimale uguale a zero (quindi sia un intero)
            while (!double.TryParse(Console.ReadLine(), out num1) || num1 == Math.Floor(num1))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero con la virgola");
            }

            Console.WriteLine("\nInserire secondo numero con la virgola:\n");
            while (!double.TryParse(Console.ReadLine(), out num2) || num2 == Math.Floor(num2))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero con la virgola");
            }

            Console.WriteLine("\nValore1: {0} -- Valore2: {1} -- Prodotto: {2}\n", num1, num2, num1*num2);

        }

        static double Somma()
        {
            double num1, num2;

            Console.WriteLine("\nInserire primo numero con la virgola:\n");
            while (!double.TryParse(Console.ReadLine(), out num1) || num1 == Math.Floor(num1))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero con la virgola");
            }

            Console.WriteLine("\nInserire secondo numero con la virgola:\n");
            while (!double.TryParse(Console.ReadLine(), out num2) || num2 == Math.Floor(num2))
            {
                Console.WriteLine("Sintassi errata. Inserisci un numero con la virgola");
            }

            return num1 + num2;
        }

        static void StampaStringa()
        {
            Console.WriteLine("\nInserire il proprio nome:\n");
            string nome = Console.ReadLine();

            Console.WriteLine("\nInserire il proprio cognome:\n");
            string cognome = Console.ReadLine();

            Console.WriteLine("\nIl tuo nome è {0}, il tuo cognome è {1}\n", nome, cognome);
        }

        static int SommaInteriConMolt(ref int num1, ref int num2, ref int num3, ref int num4)
        {
            int risultato = (num1+num2+num3+num4) * 10;

            return risultato; 
        }

        static string InterpString()
        {
           
            Console.WriteLine("Inserisci una stringa:");
            string input = Console.ReadLine();

           
            string result = $"[{input}]";

            return ($"La stringa tra parentesi quadre è: {result}\n");

        }

    }

    public class ContoBancario
    {
        private string iban;

        private string nome;

        private string cognome;

        private string codicefiscale;

        private double saldo;

        private double scoperto;

        //Costruttore vuoto
        public ContoBancario() { }

        //Costruttore parametrizzato
        public ContoBancario(string iban, string nome, string cognome, string codicefiscale, double saldo, double scoperto)
        {
            this.iban = iban;
            this.nome = nome;
            this.cognome = cognome;
            this.codicefiscale = codicefiscale;
            this.saldo = saldo;
            this.scoperto = scoperto;
        }

        // Metodo per assegnare un nuovo scoperto
        public void AssegnaScoperto(double nuovoScoperto)
        {
            this.scoperto = nuovoScoperto;
        }

        // Metodo per modificare il saldo dopo un versamento
        public void Versamento(double importo)
        {
            //se l'importo da versare è negativo
            if (importo <= 0)
            {
                Console.WriteLine("L'importo del versamento deve essere positivo.\n");
                return;  // Non proseguire con il prelievo
            }

            this.saldo += importo;
        }

        // Metodo per modificare il saldo dopo un prelievo
        public void Prelievo(double importo)
        {
            //se l'importo da prelevare è negativo
            if (importo <= 0)
            {
                Console.WriteLine("L'importo del prelievo deve essere positivo.\n");
                return;  // Non proseguire con il prelievo
            }

            //se l'importo da prelevare è maggiore dello scoperto
            if (this.saldo - importo < -this.scoperto)

            {
                Console.WriteLine("Saldo insufficiente, scoperto massimo superato.\n");
                return;  // Non proseguire con il prelievo
            }
            
            this.saldo -= importo;
        }

        // Metodo per ottenere informazioni sul conto corrente
        public void MostraInfoConto()
        {
            Console.WriteLine($"IBAN: {this.iban}");
            Console.WriteLine($"Nome: {this.nome}");
            Console.WriteLine($"Cognome: {this.cognome}");
            Console.WriteLine($"Codice Fiscale: {this.codicefiscale}");
            Console.WriteLine($"Saldo: {this.saldo}");
            Console.WriteLine($"Scoperto massimo: {this.scoperto}");
        }

    }

    public class Automobile
    {
        private string marca;

        private string modello;

        private double carburanterimasto;// Litri rimanenti nel serbatoio

        private double chilometripercorsi; // Chilometri percorsi

        private double capacitaserbatoio;// Capacità massima del serbatoio in litri

        private double consumoperkm; // Litri consumati per ogni km

        // Costruttore vuoto
        public Automobile () {}

        Automobile auto1 = new Automobile("Fiat", "Panda", 40, 0.06, 50);
        // Costruttore parametrizzato
        public Automobile(string marca, string modello, double carburanterimasto, double consumoperkm,double capacitaserbatoio)
        {
            this.marca = marca;
            this.modello = modello;
            this.chilometripercorsi = 0;
            this.capacitaserbatoio = capacitaserbatoio;
            this.consumoperkm = consumoperkm;
            this.carburanterimasto = carburanterimasto;
        }


        public void MostraQuantCarburante()
        {
            Console.WriteLine("La quantità di carburante disponibile è: {0} litri", this.carburanterimasto);
        }

        public void MostraNumKilo()
        {
            Console.WriteLine("Sono stati percorsi: {0} km", this.chilometripercorsi);
        }

        public void Rifornisci(double litri)
        {
            if (this.capacitaserbatoio + litri > this.capacitaserbatoio)
            {
                Console.WriteLine("Il serbatoio è troppo piccolo per il rifornimento richiesto.");
                this.carburanterimasto = this.capacitaserbatoio;
            }
            else
            {
                this.carburanterimasto += litri;
            }

            Console.WriteLine($"Serbatoio rifornito. Carburante attuale: {this.carburanterimasto} litri.");
        }

        public void FaiViaggio(double km)
        {
            double carburanteNecessario = km * this.consumoperkm;

            if (carburanteNecessario > this.carburanterimasto)
            {
                Console.WriteLine("Carburante insufficiente per il viaggio.");
            }
            else
            {
                //sottraggo il carburante necessario da quello rimasto
                this.carburanterimasto -= carburanteNecessario;

                //aumento il numero di chilometri percorsi
                this.chilometripercorsi += km;

                Console.WriteLine($"Viaggio di {km} km completato. Carburante rimanente: {this.carburanterimasto} litri.");
            }
        }

    }
}
