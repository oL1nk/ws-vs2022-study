using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Primeiro_Programa{
    class Program
    {
        static void Main(string[] args)
        {
            double largura, comprimento, precoMetroQuadrado, area, precoTotal;

            Console.WriteLine("Qual o tamanho da largura do terreno?");
            largura = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            
            Console.WriteLine("Qual o tamanho da comprimento do terreno?");
            comprimento = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Qual o valor por metro quadrado?");
            precoMetroQuadrado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            area = largura * comprimento;
            precoTotal = area * precoMetroQuadrado;
            Console.WriteLine("AREA: " + area . ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine("PRECO: " + precoTotal. ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}
