﻿using System;
using tabuleiro;
using Pxadrez;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaXadrez partida = new PartidaXadrez();
                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.printTela(partida.tab);
                    Console.WriteLine();
                    Console.WriteLine("Turno: " + partida.turno);
                    Console.WriteLine("Jogador: " + partida.jogadorAtual);
                    Console.WriteLine("Origem: ");                
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaodeOrigem(origem);

                    bool[,] posicoesPosiveis = partida.tab.peca(origem).movimentosPossiveis();

                    Console.Clear();
                    Tela.printTela(partida.tab, posicoesPosiveis);

                    Console.WriteLine();
                    Console.WriteLine("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                    partida.validarPosicaoDestino(origem, destino);

                    partida.realizaJogada(origem, destino);
                }
            }
            catch (Xadrez_Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
