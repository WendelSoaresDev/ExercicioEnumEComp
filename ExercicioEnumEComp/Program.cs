using System;
using System.Globalization;
using ExercicioEnumEComp.Entities;
using ExercicioEnumEComp.Entities.Enums;
namespace ExercicioEnumEComp
{
    class Program
    {
        public static void Main(String[] args)
        {
            Console.Write("Enter department's name: ");
            string deptname = Console.ReadLine();
            Console.WriteLine("\nEnter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("\nLevel (Junior/MidLevel/Senior)");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine()); //convertendo para string
            Console.Write("\nBase Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            //instanciando o objeto worker com um outro objeto ligado (departament)
            Departament dept = new Departament(deptname);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++ )
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                Console.Write("Date DD/MM/YYYY: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(hours):");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours); //instanciando o contrato com os parametros do segundo construtor 

                worker.AddContract(contract); //adicionando contrato ao trabalhador

            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YYYY)");
            string monthAndYear = Console.ReadLine();

            int month = int.Parse(monthAndYear.Substring(0, 2)); //posição[0], quantos caracteres[2]
            int year = int.Parse(monthAndYear.Substring(3)); // quando não coloco o segundo parametro ele pega todo o resto

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament.Name);
            Console.WriteLine("income for: " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));

        }
    }
}