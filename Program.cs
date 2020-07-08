using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno[] alunos = new Aluno[5];
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine("1 - Inserir Aluno ");
            Console.WriteLine("2 - Listar Alunos ");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("x - Sair");

            string opcaoUsuario = Console.ReadLine();
            Aluno aluno = new Aluno();
            int indiceAluno = 0;

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        Console.WriteLine("Informe o nome do aluno: ");
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");
                        //aluno.Nota = decimal.Parse(Console.ReadLine());
                        if (decimal.TryParse(Console.ReadLine(), out decimal nota))
                        {
                            aluno.Nota = nota;
                        }
                        else
                        {
                            throw new ArgumentException("Valor da nota deve ser decimal.");
                        }
                        alunos[indiceAluno] = aluno;
                        indiceAluno++;
                        break;
                    case "2":
                        foreach (var a in alunos)
                        {
                            if (!string.IsNullOrEmpty(a.Nome))
                                Console.WriteLine($"O aluno {a.Nome} teve a nota {a.Nota}");
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
                        decimal mediaGeral = notaTotal / nrAlunos;
                        Conceito conceitoGeral;

                        if (mediaGeral < 2)
                        {
                            conceitoGeral = Conceito.E;
                        }
                        else if (mediaGeral < 4)
                        {
                            conceitoGeral = Conceito.D;
                        }
                        else if (mediaGeral < 6)
                        {
                            conceitoGeral = Conceito.C;
                        }
                        else if (mediaGeral < 8)
                        {
                            conceitoGeral = Conceito.B;
                        }
                        else
                        {
                            conceitoGeral = Conceito.A;
                        }

                        System.Console.WriteLine($"A média Geral é: {mediaGeral} | Conceito: {conceitoGeral}");
                        break;
                    default:
                        Console.WriteLine("Digite uma opcão válida.");
                        throw new ArgumentException("Digite uma opcão válida.");
                }
                Console.WriteLine("Informe a opção desejada: ");
                Console.WriteLine("1 - Inserir Aluno ");
                Console.WriteLine("2 - Listar Alunos ");
                Console.WriteLine("3 - Calcular média geral");
                Console.WriteLine("x - Sair");

                opcaoUsuario = Console.ReadLine();
            }
        }
    }
}
