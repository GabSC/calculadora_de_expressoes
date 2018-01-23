using System;
using System.Collections.Generic;




namespace CalculadoraDeExpressoes
{
    class Calculadora
    {

        public Calculadora()
        {

          
            // inicializa o objeto preenchendo os conjuntos numericos e conjuntos de operandos

            ConjuntoNumerico = new HashSet<char>();

            ConjuntoNumerico.Add('0');
            ConjuntoNumerico.Add('1');
            ConjuntoNumerico.Add('2');
            ConjuntoNumerico.Add('3');
            ConjuntoNumerico.Add('4');
            ConjuntoNumerico.Add('5');
            ConjuntoNumerico.Add('6');
            ConjuntoNumerico.Add('7');
            ConjuntoNumerico.Add('8');
            ConjuntoNumerico.Add('9');

            ConjuntoOperadores = new HashSet<char>();

            ConjuntoOperadores.Add('+');
            ConjuntoOperadores.Add('-');
            ConjuntoOperadores.Add('*');
            ConjuntoOperadores.Add('/');


        }
        public String EntradaInfix;    
              
        HashSet<char> ConjuntoNumerico = null;

        HashSet<char> ConjuntoOperadores = null;

        public double Resultado { get; private set; }
        
       
        private int PrioridadeMaiorOuIgual(char c)
        {
            int ret = 0;

            switch (c)
            {
                case '(':
                    ret = 1;
                    break;

                case '+':
                    ret = 2;
                    break;
                case '-':
                    ret = 2;
                    break;
                case '*':
                    ret = 3;
                    break;
                case '/':
                    ret = 3;
                    break;

                default:
                    break;
            }

            return ret;
        } // método para verificar a prioridade de um operador, 1- é a mais baixa

        

        public void Calcular()
        {

            List<Object> postFixList = new List<Object>();
            Stack<Object> pilhaTemp = new Stack<Object>();

            int numDeAlgarismos = 0;
            for (int ind = 0; ind < EntradaInfix.Length; ind++)
            {


                if (ConjuntoNumerico.Contains(EntradaInfix[ind])) // o valor é um operando?
                {
                     //bloco de conversão de substring em int
                    if ((ind + 1) == EntradaInfix.Length) //estou no ultimo indice?
                    {



                        var numero = EntradaInfix.Substring(ind - numDeAlgarismos, numDeAlgarismos + 1); 
                        postFixList.Add(int.Parse(numero));
                        numDeAlgarismos = 0;
                    }
                    else
                    {

                        if (ConjuntoOperadores.Contains(EntradaInfix[ind + 1]) || EntradaInfix[ind+1].Equals(')')) //é um operador ou fechamento?
                        {

                            var numero = EntradaInfix.Substring(ind - numDeAlgarismos, numDeAlgarismos + 1);
                            postFixList.Add(int.Parse(numero));
                            numDeAlgarismos = 0;
                        }
                        else
                        {

                            numDeAlgarismos++;


                        }

                    }
                    // fim do bloco de conversão



                }
                else if (ConjuntoOperadores.Contains(EntradaInfix[ind])) // é um operador?
                {

                    while (pilhaTemp.Count != 0 && (PrioridadeMaiorOuIgual(Convert.ToChar(pilhaTemp.Peek())) >= PrioridadeMaiorOuIgual(EntradaInfix[ind])))
                    {
                        postFixList.Add(pilhaTemp.Pop());


                    }

                    pilhaTemp.Push(EntradaInfix[ind]);

                }
                else if (EntradaInfix[ind] == '(')
                {

                    pilhaTemp.Push(EntradaInfix[ind]);

                }
                else if (EntradaInfix[ind] == ')')
                {

                    while (pilhaTemp.Count != 0)
                    {

                        if (pilhaTemp.Peek().Equals('('))
                        {
                            pilhaTemp.Pop();

                            break;
                        }
                        else
                        {
                            postFixList.Add(pilhaTemp.Pop());


                        }

                    }

                }

            }


            while (pilhaTemp.Count != 0)
            {

                postFixList.Add(pilhaTemp.Pop());


            }



            if (pilhaTemp.Count != 0)
            {

                pilhaTemp.Pop();
            }



            for (int ind = 0; ind < postFixList.Count; ind++)
            {
      
                if (postFixList[ind].Equals('-'))
                {

                    Double dir = Convert.ToDouble(pilhaTemp.Pop());
                    Double esq = Convert.ToDouble(pilhaTemp.Pop());

                    pilhaTemp.Push(esq - dir);
                    

                }else if (postFixList[ind].Equals('+'))
                {
                    Double dir = Convert.ToDouble(pilhaTemp.Pop());
                    Double esq = Convert.ToDouble(pilhaTemp.Pop());



                    pilhaTemp.Push(esq + dir);
                    


                }
                else if (postFixList[ind].Equals('*'))
                {
                    Double dir = Convert.ToDouble(pilhaTemp.Pop());
                    Double esq = Convert.ToDouble(pilhaTemp.Pop());



                    pilhaTemp.Push(esq * dir);

                }
                else if(postFixList[ind].Equals('/'))
                {
                    Double dir = Convert.ToDouble(pilhaTemp.Pop());
                    Double esq = Convert.ToDouble(pilhaTemp.Pop());



                    pilhaTemp.Push(esq / dir);


                }else
                {

                    pilhaTemp.Push(postFixList[ind]);

                }


                
            }



            Console.WriteLine("Resultado: " + pilhaTemp.Pop());

        }

    }
}
