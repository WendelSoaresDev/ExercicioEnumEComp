using ExercicioEnumEComp.Entities.Enums;
using System.Collections.Generic;
namespace ExercicioEnumEComp.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public Double BasicSalary { get; set; }
        public Departament Departament { get; set; } //composição de objetos (assosciação entre 2 classes diferentes)
        public List<HourContract> Contracts { get; set; } = new List<HourContract>(); // instanciando a lista para garantir que ela não vai ser nula
        // Composição de objetos // criando tipo lista da class HourContract
        public Worker()
        {
           
        }

        public Worker(string name, WorkerLevel level, double basicSalary, Departament departament) // não se coloca no construtor listas
        {
            Name = name;
            Level = level;
            BasicSalary = basicSalary;
            Departament = departament;

        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BasicSalary;
            foreach(HourContract contract in Contracts) //percorrendo a lista do tipo HourContract que recebe o parametro contract na lista criada Contracts
            {
                if (contract.Date.Year == year && contract.Date.Month == month) //só entra os contratos que baterem com o mes e ano informado
                {
                    sum += contract.TotalValue();
                }

                
            }
            return sum;

        }
    }
}
