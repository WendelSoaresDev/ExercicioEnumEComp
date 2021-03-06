

namespace ExercicioEnumEComp.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public Departament Departament { get; set; } // composição de objetos 
        public HourContract()
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hours)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hours;
        }

        //método

        public double TotalValue()
        {
            return ValuePerHour * Hours;
        }

    }
}
