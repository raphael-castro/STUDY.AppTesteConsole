using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        var dbSimulado = new SimuladorDB();

        // Consulta todos os alunos
        Console.WriteLine("Todos os Alunos:");
        var todosOsAlunos = dbSimulado.Alunos;
        foreach (var aluno in todosOsAlunos)
        {
            Console.WriteLine($"Aluno: {aluno.Nome}");
        }

        Console.WriteLine("\nCursos do João:");
        // Consulta todos os cursos de um aluno específico
        var cursosDoJoao = dbSimulado.Alunos.FirstOrDefault(a => a.Nome == "João")?.Cursos;
        if (cursosDoJoao != null)
        {
            foreach (var curso in cursosDoJoao)
            {
                Console.WriteLine($"Curso: {curso.Nome}");
            }
        }

        Console.WriteLine("\nAlunos em Matemática:");
        // Consulta alunos em um determinado curso
        var alunosMatematica = dbSimulado.Alunos.Where(a => a.Cursos.Any(c => c.Nome == "Matemática"));
        foreach (var aluno in alunosMatematica)
        {
            Console.WriteLine($"Aluno em Matemática: {aluno.Nome}");
        }
    }

    public class SimuladorDB
    {
        // List<Curso> = Tipo da propriedade: Lista que armazena objetos do tipo 'Curso'. / Cursos = Nome da propriedade: 'Cursos'.
        public List<Aluno> Alunos { get; set; }
        public List<Curso> Cursos { get; set; }

        public SimuladorDB()
        {
            // Inicializando as listas
            Alunos = new List<Aluno>();
            Cursos = new List<Curso>();

            // Preencher com dados simulados
            // Cursos = Este é o nome de uma lista que armazena objetos do tipo Curso
            // .Add = Este é um método das coleções do .NET que é usado para adicionar um novo elemento à coleção
            // new Curso =  está criando uma nova instância da classe Curso
            Cursos.Add(new Curso { CursoId = 1, Nome = "Matemática" });
            Cursos.Add(new Curso { CursoId = 2, Nome = "Português" });

            Alunos.Add(new Aluno { AlunoId = 1, Nome = "João", Cursos = new List<Curso> { Cursos[0], Cursos[1] } });
            Alunos.Add(new Aluno { AlunoId = 2, Nome = "Maria", Cursos = new List<Curso> { Cursos[1] } });
        }
    }

    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public List<Curso> Cursos { get; set; }
    }

    public class Curso
    {
        public int CursoId { get; set; }
        public string Nome { get; set; }
    }
}
