using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astar
{
    public class Program
    {
        static Quadrado Posicao(List<Quadrado> obs, int tam)
        {
            int num1 = tam + 1, num2 = tam + 1, num3 = tam + 1;

            while (obs.Exists(n => n.pos.Item1 == num1 && n.pos.Item2 == num2 && n.pos.Item3 == num3) || (num1 > tam || num1 < 0) || (num2 > tam || num2 < 0) || (num3 > tam || num3 < 0))
            {
                Console.Write("X: ");
                num1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Y: ");
                num2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("Z: ");
                num3 = Convert.ToInt32(Console.ReadLine());
            }
            Quadrado q = new Quadrado(num1, num2, num3, 0);
            return (q);
        }

        static void Main(string[] args)
        {
            int tam = 0;
            Console.Write("Tamanho do cubo (Ex: 3) : ");
            tam = Convert.ToInt32(Console.ReadLine());

            Cubo cubo = new Cubo(tam);
            Console.WriteLine("65% de obstaculos gerados: ");
            cubo.GeraObstaculos();
            cubo.Obstaculos.ForEach(n => Console.WriteLine(n.pos));
            Console.WriteLine("Posição inicial: ");
            Quadrado q = Posicao(cubo.Obstaculos, tam);
            Console.WriteLine("Destino: ");
            Quadrado q1 = Posicao(cubo.Obstaculos, tam);

            Astar astar = new Astar(q, q1, cubo);
            astar.AstarEncontra();
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("Tamanho do cubo: " + tam);
            Console.WriteLine("Obstaculos: ");
            cubo.Obstaculos.ForEach(n => Console.WriteLine("  " + n.pos));
            Console.WriteLine("Posicao inicio - : " + astar.Origem.pos);
            Console.WriteLine("Posicao destino - : " + astar.Destino.pos);
            Console.WriteLine("Custo total - : " + astar.Estado.Custo);
            Console.WriteLine("Caminho percorrido :");

            if (astar.Estado.pos.Equals(astar.Destino.pos))
                Console.WriteLine("Possui solução desta origem");
            else
                Console.WriteLine("Não possui solução desta origem");

            astar.Estado.ExibeCaminho(astar.Estado);
            Console.ReadKey();
        }
    }
}
