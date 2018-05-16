using System;
using System.Collections.Generic;
using System.Linq;

namespace Astar
{  

    public class Astar
    {
        Cubo cubo;
        Quadrado origem;
        Quadrado estado;
        Quadrado destino;

        List<Quadrado> aberto;
        List<Quadrado> fechados;

        

        public Astar(Quadrado o, Quadrado d, Cubo c)
        {
            origem = o;
            estado = null;
            destino = d;
            cubo = c;
            fechados = new List<Quadrado>();
            aberto = new List<Quadrado>();
        }


        public int CalculaH(int x, int y, int z, int X, int Y, int Z) => (Math.Abs(X - x) + Math.Abs(Y - y) + Math.Abs(Z - z));

        public void AstarEncontra()
        {
            aberto.Add(origem);
            int g = 0;
            while(aberto.Count > 0)
            {
                var menor = aberto.Min(n => n.Heuristica);
                estado = aberto.First(n => n.Heuristica == menor);

                fechados.Add(estado);
                Console.WriteLine("Caminhando - " + estado.pos);
                aberto.Remove(estado);

                if (fechados.FirstOrDefault(n => n.pos.Equals(destino.pos)) != null)
                    break;

                List<Quadrado> adjacentes = BuscaVizinhos(estado.pos.Item1, estado.pos.Item2, estado.pos.Item3);
                g++;

                foreach(Quadrado q in adjacentes)
                {
                    if (fechados.Exists(n => n.pos.Equals(q.pos)))
                        continue;

                    if(!aberto.Exists(n => n.pos.Equals(q.pos)))
                    {
                        q.G = g;
                        q.Heuristica = CalculaH(q.pos.Item1, q.pos.Item2, q.pos.Item3, destino.pos.Item1, destino.pos.Item2, destino.pos.Item3);
                        q.Custo += q.G + q.Heuristica;
                        q.Pai = estado;
                        aberto.Insert(0, q);
                    }
                    else
                    {
                        if(g + q.Heuristica < q.Custo)
                        {
                            q.G = g;
                            q.Custo += q.G + q.Heuristica;
                            q.Pai = estado;
                        }
                    }                    
                }
            }
        }

        public List<Quadrado> BuscaVizinhos(int x, int y, int z)
        {
            Random r = new Random();

            List<Quadrado> posicoes = new List<Quadrado>();
            posicoes.Add(new Quadrado(x + 1, y, z, r.Next(10)));
            posicoes.Add(new Quadrado(x, y + 1, z, r.Next(10)));
            posicoes.Add(new Quadrado(x, y, z + 1, r.Next(10)));
            posicoes.Add(new Quadrado(x - 1, y, z, r.Next(10)));
            posicoes.Add(new Quadrado(x, y - 1, z, r.Next(10)));
            posicoes.Add(new Quadrado(x, y, z - 1, r.Next(10)));

            List<int> remover = new List<int>();
            for (int i = 0; i < posicoes.Count; i++)
            {
                if (posicoes[i].pos.Item1 < 1 || posicoes[i].pos.Item2 < 1 || posicoes[i].pos.Item3 < 1 || posicoes[i].pos.Item1 > cubo.Tam || posicoes[i].pos.Item2 > cubo.Tam || posicoes[i].pos.Item3 > cubo.Tam)
                {
                    posicoes.RemoveAt(i);
                    i--;
                }
                    
                else if (Cubo.Obstaculos.Any(n => n.pos.Equals(posicoes[i].pos)))
                {
                    posicoes.RemoveAt(i);
                    i--;
                }
            }
            //posicoes.Where(n => (n.pos.Item1 > 0 && n.pos.Item2 > 0 && n.pos.Item1 > 0) && (n.pos.Item1 <= cubo.Tam && n.pos.Item2 <= cubo.Tam && n.pos.Item1 <= cubo.Tam));
            //posicoes.Where(n => (Cubo.Obstaculos.FirstOrDefault(l => l.pos.Equals(n.pos))) != null);
            
            return posicoes;
        }

        public Quadrado Origem { get => origem; }
        public Quadrado Destino { get => destino; }
        public Cubo Cubo { get => cubo; set => cubo = value; }
        public Quadrado Estado { get => estado; set => estado = value; }
    }
}
