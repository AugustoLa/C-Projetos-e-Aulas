﻿using tabuleiro;
using xadrez;
using xadrez_Console;

Tabuleiro tab = new Tabuleiro(8, 8);


try
{
    PartidaDeXadrez partida = new PartidaDeXadrez();
    while (!partida.terminada)
    {
        try
        {
            Console.Clear();
            Tela.imprimirPartida(partida);
            Console.WriteLine();
            Console.Write("Origem: ");
            Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeOrigem(origem);

            bool[,] posicoesPossives = partida.tab.peca(origem).movimentosPossiveis();
            Console.Clear();
            Tela.imprimirTabuleiro(partida.tab, posicoesPossives);
            Console.WriteLine();
            Console.Write("Destino: ");
            Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
            partida.validarPosicaoDeDestino(origem, destino);

            partida.realizaJogada(origem, destino);
        }

        catch (TabuleiroException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}


catch (TabuleiroException e)
{
    Console.WriteLine(e.Message);
}