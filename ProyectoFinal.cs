// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.Linq;

class Persona
{
    public string Nombre { get; set; }
    public string Cedula { get; set; }

    public Persona(string nombre, string cedula)
    {
        Nombre = nombre;
        Cedula = cedula;
    }
}

class Materia
{
    public string Nombre { get; set; }
    public string Codigo { get; set; }
    public double Nota { get; set; }

    public Materia(string nombre, string codigo, double nota)
    {
        Nombre = nombre;
        Codigo = codigo;
        Nota = nota;
    }
}

class Estudiante : Persona
{
    public string Matricula { get; set; }
    public List<Materia> Materias { get; set; }

    public Estudiante(string nombre, string cedula, string matricula) : base(nombre, cedula)
    {
        Matricula = matricula;
        Materias = new List<Materia>();
    }

    public void AgregarMateria(Materia materia)
    {
        Materias.Add(materia);
    }

    public double CalcularPromedio()
    {
        if (Materias.Count == 0)
            return 0;
        return Materias.Average(m => m.Nota);
    }

    public void MostrarResumen()
    {
        Console.WriteLine($"Estudiante: {Nombre} - Cédula: {Cedula} - Matrícula: {Matricula}");
        foreach (var materia in Materias)
        {
            Console.WriteLine($"Materia: {materia.Nombre}, Código: {materia.Codigo}, Nota: {materia.Nota}");
        }
        Console.WriteLine($"Promedio final: {CalcularPromedio():F2}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Estudiante est1 = new Estudiante("María González", "001-1234567-8", "2023-001");

        est1.AgregarMateria(new Materia("Matemáticas", "MAT101", 85));
        est1.AgregarMateria(new Materia("Programación I", "INF102", 90));
        est1.AgregarMateria(new Materia("Historia", "HIS103", 78));

        est1.MostrarResumen();
    }
}