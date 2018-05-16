using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar
{
    public class Cubo
    {
        int tam;
        int qtd;

        List<Quadrado> obstaculos;
        public Cubo(int t)
        {
            tam = t;
            qtd = Convert.ToInt32(Math.Pow(tam, 3));
            obstaculos = new List<Quadrado>();
        }

        public void GeraObstaculos()
        {
            int n;
            List<Quadrado> posicoes = new List<Quadrado>();
            Random r = new Random();

            for (int x = 1; x < tam + 1; x++)
            {
                for (int y = 1; y < tam + 1; y++)
                {
                    for (int z = 1; z < tam + 1; z++)
                    {
                        posicoes.Add(new Quadrado(x, y, z, 0));
                    }
                }
            }

            while (obstaculos.Count < Convert.ToInt32((qtd * 65) / 100))
            {
                n = r.Next(posicoes.Count);
                obstaculos.Add(posicoes[n]);
                posicoes.RemoveAt(n);
            }
            posicoes.Clear();
        }

        public List<Quadrado> Obstaculos { get => obstaculos; set => obstaculos = value; }
        public int Tam { get => tam; set => tam = value; }
    }
}
