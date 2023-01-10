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
        public List<Jogadores> usuarios = new List<Jogadores>();

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
                    //Console.WriteLine("Nome: " + cartas[cont].Nome + " | " + "Naipe: " + cartas[cont].Naipe + " | " + "Valor: " + cartas[cont].Valor);
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
                usuarios.Add(new Jogadores());
                Console.WriteLine("Digite o nome do jogador  " + (i + 1));
                usuarios[i].Nome = Console.ReadLine();
            }

        }
        public void DistribuirCartas()
        {
            foreach (var jogador in usuarios)
            {
                for (int i = 0; i < 2; i++)
                {
                    jogador.Cartas = new List<Carta>();
                    jogador.Cartas.Add(cartas[i]);
                    jogador.Pontuacao = cartas[i].Valor;
                    jogador.Cartas.Add(cartas[i + 1]);
                    jogador.Pontuacao += cartas[i + 1].Valor;
                    cartas.RemoveAt(i);
                    cartas.RemoveAt(i+ 1);
                    Console.WriteLine(jogador.Nome + ": " + jogador.Cartas[i].Nome + jogador.Cartas[i].Naipe + jogador.Pontuacao);
                }
            }
        }

        public void Jogar()
        {
            while (true)
            {
                foreach (var jogador in usuarios)
                {

                }
            }
        }


    }
}



//public void PedirCarta()
//{
//    Carta.Add(cartas);
//    Pontuacao += carta.Valor;
//}
//public void Parar()
//{
//    if (Pontuacao > 21)
//    {
//        Console.WriteLine("Você perdeu");
//    }
//    else if (Pontuacao == 21)
//    {
//        Console.WriteLine("Você ganhou");
//    }
//    else
//    {
//        Console.WriteLine("A rodada terminou");
//    }






