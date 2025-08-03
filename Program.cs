using System;
namespace Exercicios
{

    public delegate string P1(int Valor,int Valor2);
    /*
     3. Jogo de Pedra, Papel e Tesoura com IA Simples
Descrição:
Implemente um jogo contra o computador, mas o computador tenta adivinhar seu padrão anterior.
Você precisa armazenar histórico e melhorar a IA a cada rodada.


    */

    public class Jogo
    {
        enum Jogadas { Pedra, Papel, Tesoura };
        public static List<int> IA_Story = new List<int>();

        public static void Main()
        {
            Console.Clear();

            bool sucesso = true;
            bool Modo_IA = false;
            int count = 0;
            int pedra = 0;
            int papel = 0;
            int tesoura = 0;
            string MaisUsados;
            int ValorAnterior=-1;
            int Jogada;
            int Victorias = 0;
            int Derrotas=0;
            int Empate = 0;




            Console.WriteLine("Benvindo ao jogo da Pedra a tesoura \n quer Jogar se sim Prima 1 se não prima qualquer tecla: ");
            sucesso = int.TryParse(Console.ReadLine(), out int Resposta);
            

            while (sucesso && Resposta==1)
            {


                if (sucesso)
                {


             

                    while (true)
                    {
                        Console.WriteLine("Digite : \nPedra[0] \nPapel[1] \nTesoura[2] ");
                        bool sucesso_ = int.TryParse(Console.ReadLine(), out Jogada);
                        Console.WriteLine();
                        if (sucesso_ && Jogada >= 0 && Jogada <= 2)
                        { break; }
                        Console.WriteLine("Digite um valor Aceitavel de 0 a 2 \n Quer Consitinuar? Prima qualquer tecla");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    

                    if (Jogada != ValorAnterior)
                    {
                        count = 1;
                        ValorAnterior = Jogada;
                    }
                    else
                        count++;
                        



                    

                   

                        if (count > 3)
                            Modo_IA = true;

                        if (!Modo_IA)
                        {
                            int Valor = 0;
                            Random random = new();
                            Valor = random.Next(0, 3);
                            P1 p1 = Vencedor;
                            Console.Clear();
                            Console.WriteLine("Voce Jogou:{0} \nEu jogei: {1}", (Jogadas)Jogada, (Jogadas)Valor);
                            Console.WriteLine("\t\tResultado \n \t\t{0}", p1(Valor, Jogada));
                        if (p1(Valor, Jogada) == "Parabens Voce Venceu")
                            Victorias++;
                        else if (p1(Valor, Jogada) == "Ouh Voce Perdeu")
                            Derrotas++;
                        else
                            Empate++;

                            IA_Story.Add(Jogada);
                        }




                        if (Modo_IA)
                        {


                            foreach (int c in IA_Story)
                            {

                                if (c == 0)
                                    pedra++;
                                if (c == 1)
                                    papel++;
                                if (c == 2)
                                    tesoura++;


                            }

                            if (count < 4)
                            {
                                pedra = 0;
                                papel = 0;
                                tesoura = 0;
                            }

                            MaisUsados = (pedra, papel, tesoura) switch
                            {
                                var (p, l, t) when p == l && l == t => "Igual",
                                var (p, l, t) when p > t && p > l => "Pedra",
                                var (p, l, t) when t > p && t > l => "Tesoura",
                                var (p, l, t) when l > p && l > t => "Papel",

                                _ => "Dois_Valore_iguais"

                            };

                            int Valor = 0;

                            Valor = TratarDados(MaisUsados);
                            P1 p1 = Vencedor;
                            Console.Clear();
                            Console.WriteLine("Voce Jogou:{0} \nEu jogei: {1}", (Jogadas)Jogada, (Jogadas)Valor);
                            Console.WriteLine("\t\tResultado \n \t\t{0}", p1(Valor, Jogada));
                           

                             if (p1(Valor, Jogada) == "Parabens Voce Venceu")
                            Victorias++;
                        else if (p1(Valor, Jogada) == "Ouh Voce Perdeu")
                            Derrotas++;
                        else
                            Empate++;
                            IA_Story.Add(Jogada);




                        }






                  


                }

            }



        }

        public static string Vencedor(int Pc, int Jogador)
        => (Pc, Jogador) switch
        {
            var (J, P) when J == P => "Empate",
            (1, 2) or (2, 0) or (0, 1) => "Parabens Voce Venceu",
            (1, 0) or (2, 1) or (0, 2) => "Ouh Voce Perdeu",

            _ => "Erro"

        };

        public static int TratarDados(string Valor)
        {
            int random = 0;

            if (Valor == "Igual")
            {
                Random r1 = new();
                random = r1.Next(0, 3);

            }
            else if (Valor == "Pedra")
            {
                random = 1;

            }
            else if (Valor == "Papel")
            {
                random = 2;

            }
            else if (Valor == "Tesoura")
            {
                random = 0;

            }
            else
            {
                    Random r1 = new();
                    random = r1.Next(0, 3);

            }



            return random;
      
          } 
             











    }
    }




