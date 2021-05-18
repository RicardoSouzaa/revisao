using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5]; // array alunos com 5 indices
            var indiceAluno = 0;
            string opcao = Opcoes();

            while (opcao.ToUpper() != "X")
            {
                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("informe o nome do aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do aluno:");

                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("O valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++;

                        break;

                    case "2":

                        foreach (var a in alunos)
                        {

                            if (!string.IsNullOrEmpty(a.Nome)) // se a string nome não for vazio ! nega.
                            {
                                Console.WriteLine($"Aluno: {a.Nome} - Nota: {a.Nota}");
                            }
                        }
                        break;

                    case "3":

                        decimal notaTotal = 0;
                        var nrAlunos = 0;

                        for (int i = 0; i < alunos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrAlunos++;
                            }
                        }

                        var mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral; // declarando ENUM conceito

                        if(mediaGeral < 3)
                        {
                            
                            conceitoGeral = Conceito.E;
                        }

                        else if(mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if(mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if(mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        Console.WriteLine($"Média geral: {mediaGeral} Conceito Geral: {conceitoGeral}");

                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcao = Opcoes();
            }
        }

        private static string Opcoes()
        {
            Console.WriteLine();
            Console.WriteLine("informe a opcao desejada");
            Console.WriteLine("1) inserir novo aluno");
            Console.WriteLine("2) Listar alunos");
            Console.WriteLine("3) calclar media geral");
            Console.WriteLine("X) sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            return opcao;
        }
    }
}
