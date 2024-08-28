using System.ComponentModel;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { 
            this.Hospedes = new List<Pessoa>();
        }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            this.Hospedes = new List<Pessoa>();
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (this.Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                throw new WarningException("O número de hospedes é maior que a capacidade da suíte.");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return this.Hospedes.Count > 0 ? this.Hospedes.Count : 0;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = this.Suite.ValorDiaria * this.DiasReservados;

            if (this.DiasReservados >= 10)
            {
                valor -= valor * 0.1M;
            }

            return valor;
        }
    }
}