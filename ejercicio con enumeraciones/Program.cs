using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ejercicio_con_enumeraciones
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombreJugador1, nombreJugador2;
            int primerTurno;

            Console.Write("Jugador 1 escoje tu nombre: ");
            nombreJugador1 = Console.ReadLine();

            Jugador jugador1 = new Jugador(nombreJugador1, 1000);

            jugador1.EscogerPersonaje();
            jugador1.EscogerArma();

            Console.Write("Jugador 2 escoje tu nombre: ");
            nombreJugador2 = Console.ReadLine();

            Jugador jugador2 = new Jugador(nombreJugador2, 1000);

            jugador2.EscogerPersonaje();
            jugador2.EscogerArma();

            primerTurno = Batalla.TirarDados();

            if (primerTurno == 1)
            {
                Console.WriteLine($"{jugador1.Nombre} empieza primero!\n");
                Batalla.SimularBatalla(jugador1, jugador2 );
            }
            else
            {
                Console.WriteLine($"{jugador2.Nombre} empieza primero!\n");
                Batalla.SimularBatalla(jugador2, jugador1);
            }
        }
    }

    enum Personajes
    { 
        Escudero, 
        Arquero, 
        Caballero
    }

    enum Armas
    {
        Espada,
        Arco,
        Martillo
    }

    class Jugador
    {
        string nombre;
        int salud;
        int ataque;
        int defensa;
        Personajes personajeEscogido;
        Armas armaEquipada;

        Random random = new Random();

        public string Nombre { get => nombre; set => nombre = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        internal Personajes PersonajeEscogido { get => personajeEscogido; set => personajeEscogido = value; }
        internal Armas ArmaEquipada { get => armaEquipada; set => armaEquipada = value; }

        public Jugador(string nombrePa, int saludPa)
        {
            nombre = nombrePa;
            salud = saludPa;
        }

        public void EscogerPersonaje()
        {
            int opcion;

            Console.Clear();

            do
            {
                Console.WriteLine("1. Escudero");
                Console.WriteLine("2. Arquero");
                Console.WriteLine("3. Caballero");

                Console.Write($"\n{Nombre}, escoge un personaje: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        personajeEscogido = Personajes.Escudero;
                        ResumenPersonajeEscogido();
                        break;

                    case 2:
                        personajeEscogido = Personajes.Arquero;
                        ResumenPersonajeEscogido();
                        break;

                    case 3:
                        personajeEscogido = Personajes.Caballero;
                        ResumenPersonajeEscogido();
                        break;

                    default:
                        Console.WriteLine("Opcion no valida, intentar de nuevo");
                        break;
                }
            }
            while (opcion < 1 || opcion > 3);

        }

        public void ResumenPersonajeEscogido()
        {
            Console.WriteLine($"{Nombre}, ahora eres \"{personajeEscogido}\"");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void EscogerArma()
        {
            int opcion;
            Console.Clear();

            do
            {
                Console.WriteLine("1. Espada (Ataque: 130, Defensa: 40)");
                Console.WriteLine("2. Arco (Ataque: 140, Defensa: 30)");
                Console.WriteLine("3. Martillo (Ataque: 150, Defensa: 20)");

                Console.Write($"{Nombre}, escoje un arma: ");
                opcion = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        armaEquipada = Armas.Espada;
                        ValoresAtaqueDefensaArmas();
                        ResumenArmaEscogida();
                        break;

                    case 2:
                        armaEquipada = Armas.Arco;
                        ValoresAtaqueDefensaArmas();
                        ResumenArmaEscogida();
                        break;

                    case 3:
                        armaEquipada = Armas.Martillo;
                        ValoresAtaqueDefensaArmas();
                        ResumenArmaEscogida();
                        break;

                    default:
                        Console.WriteLine("Opcion no valida, intentar de nuevo");
                        break;
                }
            }
            while (opcion < 1 || opcion > 3);
        }

        public void ResumenArmaEscogida()
        {
            Console.WriteLine($"{Nombre}, tu arma equipada es \"{armaEquipada}\"\nAtaque: {ataque}\nDefensa: {defensa}");
            Console.WriteLine("\nPresiona cualquier tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public void ValoresAtaqueDefensaArmas()
        {
            switch (armaEquipada)
            {
                case Armas.Espada:
                    Ataque = 130;
                    Defensa = 40;
                    break;

                case Armas.Arco:
                    Ataque = 140;
                    Defensa = 30;
                    break;

                case Armas.Martillo:
                    Ataque = 150;
                    Defensa = 20;
                    break;
            }
        }
        public void Atacar()
        {
            Console.WriteLine($"\n¡{personajeEscogido} {Nombre} ataca con su {armaEquipada}!\n");
        }

        public void Defender()
        {
            Console.WriteLine($"n¡{personajeEscogido} {Nombre} se defiende con su {armaEquipada}!\n");
        }

        public void EscogerAtacarDefender()
        {
            int opcion;

            do
            {
                Console.WriteLine("1. Atacar");
                Console.WriteLine("2. Defender");
                Console.Write($"\n [{personajeEscogido} {Nombre}], elige una opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Atacar();
                        break;

                    case 2:
                        Defender();
                        break;

                    default:
                        Console.WriteLine("Opcion invalida, intenta de nuevo");
                        break;
                }
            }
            while (opcion < 1 || opcion > 2);
        }

        public void ResumenJugador()
        {
            Console.WriteLine($"[{personajeEscogido} {Nombre}] Salud: {salud} / [{armaEquipada}] Ataque: {ataque} / Defensa: {defensa}");
        }

        public void CalcularDaño(int ataqueOtroJugadorPa)
        {
            int dañoRecibido;
            int ataqueSorpresa;

            ataqueSorpresa = random.Next(-15, 16);

            dañoRecibido = ataqueOtroJugadorPa - Defensa + ataqueSorpresa;

            Salud -= dañoRecibido;

        }
    }

    class Batalla
    {
        static Random rand = new Random();
        public static int TirarDados()
        {
            Console.WriteLine("Presione cualquier tecla para tirar los dados y determina quien comienza...");
            Console.ReadKey();
            Console.Clear();

            int primerTurno;
            primerTurno = rand.Next(1,3);

            return primerTurno;
        }

        public static void SimularBatalla(Jugador jugador1Pa, Jugador jugador2Pa)
        {
            int ronda = 1;
            Console.WriteLine("¡La batalla ha comenzado!");
            Console.WriteLine($"RONDA {ronda}\n");

            jugador1Pa.ResumenJugador();
            jugador2Pa.ResumenJugador();

            Console.WriteLine($"\n{jugador1Pa.PersonajeEscogido} {jugador2Pa.PersonajeEscogido}, empieza a atacar!");
            Console.ReadKey();
            jugador1Pa.Atacar();

            jugador2Pa.CalcularDaño(jugador1Pa.Ataque);

            jugador2Pa.EscogerAtacarDefender();
            jugador1Pa.CalcularDaño(jugador2Pa.Ataque);

            for (ronda = 2; ronda <=5; ronda++)
            {
                Console.WriteLine($"RONDA {ronda}\n");
                jugador1Pa.ResumenJugador();
                jugador2Pa.ResumenJugador();

                jugador1Pa.EscogerAtacarDefender();
                jugador2Pa.CalcularDaño(jugador1Pa.Ataque);

                jugador2Pa.EscogerAtacarDefender();
                jugador1Pa.CalcularDaño(jugador2Pa.Ataque);

                Console.WriteLine("--------------------------------");
            }
            Console.WriteLine("\n¡La batalla a terminado!\n");
            jugador1Pa.ResumenJugador();
            jugador2Pa.ResumenJugador();

            if (jugador1Pa.Salud > jugador2Pa.Salud)
            {
                Console.WriteLine($"\n¡{jugador1Pa.Nombre} ha ganado la batalla!");
            }
            else
            {
                Console.WriteLine($"\n¡{jugador2Pa.Nombre} ha ganado la batalla!");
            }
        }
    }
}
