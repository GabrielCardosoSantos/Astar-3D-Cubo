using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar
{
    public class Quadrado
    {
        int custo;
        int heuristica;
        int g;
        Quadrado pai;
        public Tuple<int, int, int> pos;

        public Quadrado(int x, int y, int z, int custo)
        {
            pos = new Tuple<int, int, int>(x, y, z);
            this.custo = custo;
        }

        public void ExibeCaminho(Quadrado q)
        {
            if (q == null) return;

            ExibeCaminho(q.pai);
            Console.WriteLine(q.pos);
        }

        public int Heuristica { get => heuristica; set => heuristica = value; }
        public int Custo { get => custo; set => custo = value; }
        public int G { get => g; set => g = value; }
        public Quadrado Pai { get => pai; set => pai = value; }
    }
}
