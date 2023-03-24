namespace CsAntiCheat.Exmplos
{
    public class PessoaJuridica : Cliente
    {

        public override string BuscarInfoCliente()
        {
            return base.BuscarInfoCliente();
        }

        protected override string BuscaInfoClient2()
        {
            throw new NotImplementedException();
        }
    }
}
