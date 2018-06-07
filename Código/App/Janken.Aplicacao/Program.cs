using Janken.Motor.Entidades;
using Janken.Motor.Servicos;
using System;
using System.Collections.Generic;

namespace Janken.Aplicacao
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Clear();
                PrimeiroDesafio();

                Console.ReadKey();

                Console.Clear();
                SegundoDesafio();

                Console.ReadKey();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }



        private static void PrimeiroDesafio()
        {
            List<Jogador> Jogadores = new List<Jogador>();
            string Nome = null;
            string Movimento = null;
            int QuantidadeJogador = 1;

            while (QuantidadeJogador <= 2)
            {
                Console.Clear();
                Console.WriteLine($"Jogador {QuantidadeJogador}");
                Console.Write("Digite seu nome: ");
                Nome = Console.ReadLine();

                Console.Clear();
                Console.WriteLine("Escolha um movimento:");
                Console.WriteLine("[R] - Pedra");
                Console.WriteLine("[P] - Papel");
                Console.WriteLine("[S] - Tesoura");
                Console.Write("Digite a opção: ");
                Movimento = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(Nome) || !string.IsNullOrWhiteSpace(Movimento))
                {
                    Jogadores.Add(new Jogador()
                    {
                        Nome = Nome,
                        Movimento = Movimento
                    });
                }
                QuantidadeJogador++;
            }

            Console.Clear();
            Jogo.rps_game_winner(Jogadores);
        }

        private static void SegundoDesafio()
        {
            Console.WriteLine("Iniciar o Campeonato");

            //TODO: Nota pessoal: houve dificuldade em montar um array tridimensional, porém é mais legível, se fosse uma lista talves a lógica fosse mais rápida.
            Jogador[,,] ListaJogadores =
            {
                {
                    {
                        new Jogador() { Nome = "Armando", Movimento = "P" },
                        new Jogador() { Nome = "Dave", Movimento = "S" }
                    },
                    {
                        new Jogador() { Nome = "Richard", Movimento = "R" },
                        new Jogador() { Nome = "Michael", Movimento = "S" }
                    }
                },
                {
                    {
                        new Jogador() { Nome= "Allen", Movimento = "S" },
                        new Jogador { Nome = "Omer", Movimento = "P" }
                    },
                    {
                        new Jogador() { Nome = "David E.", Movimento = "R" },
                        new Jogador() { Nome = "Richard X.", Movimento = "P" }
                    }
                }
            };

            Console.ReadKey();
            Console.Clear();

            Jogo.rps_tournament_winner(ListaJogadores);
        }

        /// <summary>
        /// TODO: Obsoleto, documentação não solicitou.
        /// </summary>
        /// <returns></returns>
        private static List<List<List<Jogador>>> Campeonato()
        {
            List<Jogador> Jogadores = null;
            List<List<Jogador>> GrupoJogadores = null;
            List<List<List<Jogador>>> ListaCampeonato = new List<List<List<Jogador>>>();

            GrupoJogadores = new List<List<Jogador>>();
            Jogadores = new List<Jogador>()
            {
                new Jogador() { Nome = "Armando", Movimento = "P" },
                new Jogador() { Nome = "Dave", Movimento = "S" }
            };
            GrupoJogadores.Add(Jogadores);

            Jogadores = new List<Jogador>()
            {
                new Jogador() { Nome = "Richard", Movimento = "R" },
                new Jogador() { Nome = "Michael", Movimento = "S" }
            };
            GrupoJogadores.Add(Jogadores);
            ListaCampeonato.Add(GrupoJogadores);

            GrupoJogadores = new List<List<Jogador>>();
            Jogadores = new List<Jogador>()
            {
                new Jogador { Nome= "Allen", Movimento = "S" },
                new Jogador { Nome = "Omer", Movimento = "P" }
            };
            GrupoJogadores.Add(Jogadores);

            Jogadores = new List<Jogador>()
            {
                new Jogador() { Nome = "David E.", Movimento = "R" },
                new Jogador() { Nome = "Richard X.", Movimento = "P" }
            };
            GrupoJogadores.Add(Jogadores);
            ListaCampeonato.Add(GrupoJogadores);

            return ListaCampeonato;
        }
    }
}
