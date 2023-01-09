using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class JogoService
    {

        public class Carta
        {
            public string Nome { get; set; }
            public string Naipe { get; set; }
            public int? Valor { get; set; }
        }


        public void Baralho()
        {
            string[] nome = { "Ás", "Dois", "Três", "Quatro", "Cinco", "Seis", "Sete", "Oito", "Nove", "Dez", "Dama", "Valete", "Rei" };
            string[] naipe = { "Ouro", "Espada", "Copas", "Paus" };
            int[] valores = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10 };
            List<Carta> cartas = new List<Carta>();
            int cont = 0;

            for (int i = 0; i < naipe.Length; i++)
            {
                for (int j = 0; j < nome.Length; j++)
                {
                    cartas.Add(new Carta { Nome = nome[j], Naipe = naipe[i] });
                    //Console.WriteLine("Nome: " + cartas[cont].Nome + " | " + "Naipe: " + cartas[cont].Naipe);
                    cont++;
                }
            }

            Embaralhar(cartas);
        }

        public void Embaralhar(List<Carta> cartas)
        {
            Random random = new Random();
            Carta[] cartasEmbaralhadas;
            cartasEmbaralhadas = cartas.OrderBy(x => random.Next()).ToArray();
            foreach (var carta in cartasEmbaralhadas)
            {
                Console.WriteLine(carta.Nome + " de " + carta.Naipe);
            }
            Console.ReadKey();
        }
    }
}
