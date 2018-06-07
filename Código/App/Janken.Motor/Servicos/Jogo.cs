using Janken.Motor.Entidades;
using System;
using System.Collections.Generic;

namespace Janken.Motor.Servicos
{
    /// <summary>
    /// No Janken-pon, os jogadores devem simultaneamente esticar a mão, na qual cada um formou um símbolo (que significa pedra, papel ou tesoura). 
    /// Então, os jogadores comparam os símbolos para decidir quem ganhou, da seguinte forma:
    /// 
    /// 1. Pedra ganha da tesoura (amassando-a ou quebrando-a);
    ///    • A pedra é simbolizada por um punho fechado;
    /// 2. Tesoura ganha do papel (cortando-o);
    ///    • A tesoura é simbolizada por dois dedos esticados;
    /// 3. Papel ganha da pedra (embrulhando-a);
    ///    • O papel é simbolizado pela mão aberta.
    /// 
    ///  Caso dois jogadores façam o mesmo gesto, ocorre um empate, e geralmente se joga de novo até desempatar.
    ///  OBSERVAÇÂO: Neste desafio se ambos os jogadores jogarem mesmo movimento, o primeiro jogador é o vencedor.
    /// </summary>
    public static class Jogo
    {
        #region Propriedades

        private const string Pedra = "R";
        private const string Papel = "P";
        private const string Tesoura = "S";
        private static int WrongNumberOfPlayersError { get; set; }
        private static int NoSuchStrategyError { get; set; }

        #endregion

        #region Metódos

        /// <summary>
        /// REGRAS (Desafio 01):
        /// 1. Se o número de jogadores não for igual a 2, incremente WrongNumberOfPlayersError e critique "número errado de jogadores".
        /// 2. Se a estratégia de qualquer jogador for diferente de "R", "P" ou "S" (não diferencia maiúsculas de minúsculas), incremente NoSuchStrategyError e critique "Erro de estratégia".
        /// 3. Senão devolva o nome e o movimento do jogador vencedor. Se ambos os jogadores jogarem mesmo movimento, o primeiro jogador é o vencedor.
        /// </summary>
        /// <param name="jogadores">Lista de jogadores</param>
        public static Jogador rps_game_winner(List<Jogador> jogadores)
        {
            Jogador JogadorVencedor = null;

            if (jogadores == null || jogadores.Count != 2)
            {
                WrongNumberOfPlayersError++;
                Console.WriteLine("Número errado de jogadores.");
            }
            else if (!ValidarMovimento(jogadores[0].Movimento) && !ValidarMovimento(jogadores[1].Movimento))
            {
                NoSuchStrategyError++;
                Console.WriteLine("Erro de estratégia.");
            }
            else
            {
                JogadorVencedor = Resultado(jogadores);
            }

            return JogadorVencedor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="listaCompetidores"></param>
        public static void rps_tournament_winner(Array listaCompetidores)
        {
            List<Jogador> vencedores = new List<Jogador>();
            List<Jogador> partida = new List<Jogador>();

            foreach (Jogador jogadores in listaCompetidores)
            {
                partida.Add(jogadores);

                if (partida.Count == 2)
                {
                    Jogador vencedor = rps_game_winner(partida);

                    if (vencedor != null)
                        vencedores.Add(vencedor);

                    partida.Clear();
                }
            }

            if (vencedores.Count > 1)
            {
                rps_tournament_winner(vencedores.ToArray());
            }
        }

        private static Jogador Resultado(List<Jogador> jogadores)
        {
            Jogador jogador1 = jogadores[0];
            Jogador jogador2 = jogadores[1];

            if (jogador1.Movimento.Equals(Pedra, StringComparison.CurrentCultureIgnoreCase)   && jogador2.Movimento.Equals(Tesoura, StringComparison.CurrentCultureIgnoreCase) ||
                jogador1.Movimento.Equals(Papel, StringComparison.CurrentCultureIgnoreCase)   && jogador2.Movimento.Equals(Pedra, StringComparison.CurrentCultureIgnoreCase)   ||
                jogador1.Movimento.Equals(Tesoura, StringComparison.CurrentCultureIgnoreCase) && jogador2.Movimento.Equals(Papel, StringComparison.CurrentCultureIgnoreCase)   ||
                jogador1.Movimento.Equals(jogador2.Movimento, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine($"Jogador {jogador1.Nome} ganhou do jogador {jogador2.Nome} ({jogador1.Movimento} > {jogador2.Movimento})");
                return jogador1;
            }
            else
            {
                Console.WriteLine($"Jogador {jogador2.Nome} ganhou do jogador {jogador1.Nome} ({jogador2.Movimento} > {jogador1.Movimento})");
                return jogador2;
            }
        }

        private static bool ValidarMovimento(string movimento)
        {
            return movimento.Equals(Pedra, StringComparison.CurrentCultureIgnoreCase) ||
                   movimento.Equals(Papel, StringComparison.CurrentCultureIgnoreCase) ||
                   movimento.Equals(Tesoura, StringComparison.CurrentCultureIgnoreCase);
        }

        #endregion
    }
}
