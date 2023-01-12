using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Jogadores
    {
        public string Nome { get; set; }
        public List<Carta> Cartas { get; set; }
        public int PontuacaoComputada { get => Cartas.Sum(x => x.Valor); }
    }
}
