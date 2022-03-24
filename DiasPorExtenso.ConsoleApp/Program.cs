using System;

namespace DiasPorExtenso.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeltaDias deltaDias = new DeltaDias();
            Console.WriteLine("Tempo entre datas 1.0.");
            do
            {
                Console.WriteLine("\n Insira a data no seguinte molde ( dd/mm/aaaa): ");
                string data = Console.ReadLine();
                deltaDias.EscreverDeltaPorExtenso(data);
            } while (true);
        }
    }
    internal class DeltaDias
    {
        public string stringDataDeAbertura;
        public DateTime dataDeAbertura;
        public TimeSpan delta;
        public double deltadias;
        public int totanos = 0;
        public int totdias = 0;
        public int totmesses = 0;
        public int totsemanas = 0;




        public void EscreverDeltaPorExtenso(string stringDataDeAbertura)
        {
            DeltaDias novaData = new DeltaDias();
            novaData.dataDeAbertura = converteStrParaData(stringDataDeAbertura);
            novaData.delta = CalculandoDelta(novaData.dataDeAbertura);
            novaData.deltadias = ConvertDelta(novaData.delta);

            Console.WriteLine(novaData.deltadias);

            CaldulandoDiasSemanasMessesAnos(novaData);
            //saída final 
        }

        //----------------------  Metodos Auxiliares  ------------------------

        public DateTime converteStrParaData(string stringDataDeAbertura)
        {
            dataDeAbertura = Convert.ToDateTime(stringDataDeAbertura);
            return dataDeAbertura;
        }

        public TimeSpan CalculandoDelta(DateTime dataDeAbertura)
        {
            delta = DateTime.Today - dataDeAbertura;
            return delta;
        }
        public double ConvertDelta(TimeSpan delta)
        {
            deltadias = delta.TotalDays;
            return deltadias;
        }

        private static void CaldulandoDiasSemanasMessesAnos(DeltaDias novaData)
        {
            // --------------------------  ANOS  ---------------------------
            do
            {
                if (novaData.deltadias >= 365)
                {
                    novaData.deltadias = novaData.deltadias - 365;
                    novaData.totanos++;
                }
            } while (novaData.deltadias < 365);
            
            // -------------------------- MESSES  ---------------------------
            do
            {
                if (novaData.deltadias >= 30)
                {
                    novaData.deltadias = novaData.deltadias - 30;
                    novaData.totmesses++;
                }
            } while (novaData.deltadias < 30);

            // -------------------------- Semanas  --------------------------
            do
            {
                if (novaData.deltadias >= 7)
                {
                    novaData.deltadias = novaData.deltadias - 7;
                    novaData.totsemanas++;
                }
            } while (novaData.deltadias < 7);

            // --------------------------  DIAS ----------------------------
            do
            {
                if (novaData.deltadias >= 1)
                {
                    novaData.deltadias = novaData.deltadias - 1;
                    novaData.totdias++;
                }
            } while (novaData.deltadias < 1);
        }
    }
}
