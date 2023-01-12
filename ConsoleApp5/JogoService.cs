using ConsoleApp5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class JogoService
    {

        public List<Carta> cartas = new List<Carta>();
        public List<Jogadores> jogadores = new List<Jogadores>();


        public void Baralho()
        {
            Dictionary<string, int> nomeValor = new Dictionary<string, int>()
        {
             {"Ás", 1},
             {"Dois", 2},
             {"Três", 3},
             {"Quatro", 4},
             {"Cinco", 5},
             {"Seis", 6},
             {"Sete", 7},
             {"Oito", 8},
             {"Nove", 9},
             {"Dez", 10},
             {"Dama", 10},
             {"Valete", 10},
             {"Rei", 10}
        };

            string[] naipe = { "Ouro", "Espada", "Copas", "Paus" };

            int cont = 0;

            for (int i = 0; i < naipe.Length; i++)
            {
                foreach (var item in nomeValor)
                {
                    cartas.Add(new Carta { Nome = item.Key, Naipe = naipe[i], Valor = item.Value });
                    //Console.WriteLine( cartas[cont].Nome + " De " + cartas[cont].Naipe + " | " + "Valor: " + cartas[cont].Valor);
                    cont++;
                }
            }
        }

        public void Embaralhar()
        {
            Random random = new Random();
            cartas = cartas.OrderBy(x => random.Next()).ToList();
            foreach (var carta in cartas)
            {
                //Console.WriteLine(carta.Nome + " de " + carta.Naipe + " = " + carta.Valor);
            }
            //Console.ReadKey(); 
        }
        public void CriarJogadores()
        {
            Console.WriteLine("Digite o número de jogadores: ");
            int numeroJogadores = int.Parse(Console.ReadLine());
            for (int i = 0; i < numeroJogadores; i++)
            {
                jogadores.Add(new Jogadores());
                Console.WriteLine("Digite o nome do jogador  " + (i + 1));
                jogadores[i].Nome = Console.ReadLine();
            }

        }
        public void DistribuirCartas()
        {
            foreach (var jogador in jogadores)
            {

                jogador.Cartas = new List<Carta>();
                for (int i = 0; i < 2; i++)
                {
                    jogador.Cartas.Add(cartas[i]);
                    cartas.RemoveAt(i);
                    Console.WriteLine(jogador.Nome + ": " + jogador.Cartas[i].Nome + " de " + jogador.Cartas[i].Naipe);
                }
            }
        }
        public void Jogar()
        {
            Baralho();
            Embaralhar();
            CriarJogadores();
            DistribuirCartas();

            foreach (var jogador in jogadores)
            {
                string escolha = String.Empty;
                do
                {
                    if (jogador.PontuacaoComputada > 21)
                    {
                        Console.WriteLine("O jogador " + jogador.Nome + " ultrapassou a pontuação.");
                        break;
                    }
                    else if (jogador.PontuacaoComputada == 21)
                    {
                        Console.WriteLine("O jogador " + jogador.Nome + " atingiu 21 pontos e venceu.");
                        return;
                        break;
                    }
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("Pontuação de " + jogador.Nome + ": " + jogador.PontuacaoComputada);
                    Console.WriteLine("-------------------------------------------------------------------");
                    Console.WriteLine("É a vez do jogador " + jogador.Nome);
                    Console.WriteLine("Você quer mais uma carta? (s/n)");
                    escolha = Console.ReadLine();
                    if (escolha == "s")
                    {
                        Carta novaCarta = cartas[0];
                        jogador.Cartas.Add(novaCarta);
                        cartas.RemoveAt(0);
                        Console.WriteLine("O jogador " + jogador.Nome + " recebeu a carta " + novaCarta.Nome + " de " + novaCarta.Naipe);
                        Console.WriteLine("Nova pontuação: " + jogador.PontuacaoComputada);
                    }
                } while (escolha == "s");
                if (escolha == "n")
                    Console.WriteLine("O jogador " + jogador.Nome + " decidiu parar com " + jogador.PontuacaoComputada + " pontos.");
            }
            VerificarVencedor();
        }
        public void VerificarVencedor()
        {
            Jogadores jogadorVencedor = null;
            int maiorDiferenca = int.MaxValue;
            foreach (var jogador in jogadores)
            {
                if (jogador.PontuacaoComputada <= 21)
                {
                    int diferenca = Math.Abs(21 - jogador.PontuacaoComputada);
                    if (diferenca < maiorDiferenca)
                    {
                        jogadorVencedor = jogador;
                        maiorDiferenca = diferenca;
                    }
                }
            }
            if (jogadorVencedor != null)
            {
                Console.WriteLine("O vencedor é: " + jogadorVencedor.Nome + " com " + jogadorVencedor.PontuacaoComputada + " pontos.");
            }
            else
            {
                Console.WriteLine("-------------------------------------------------------------------");
                Console.WriteLine("Nenhum dos jogadores possui pontuação menor ou igual a 21.");
            }
        }
    }
}



