using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraDeExpressoes
{
    class Program
    {
        static void Main(string[] args)
        {

            Calculadora c = new Calculadora();



            Console.Write("Digite uma expressão aritimética para ser calculada: ");
            c.EntradaInfix = Console.ReadLine();
            

            c.Calcular();
            

            Console.ReadKey();
            
        }
    }
}
