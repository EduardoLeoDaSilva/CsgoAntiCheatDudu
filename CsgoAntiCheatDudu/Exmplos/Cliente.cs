namespace CsAntiCheat.Exmplos
{
    public abstract class Cliente
    {
        public string Nome { get; set; }
        public string Id { get; set; }

        protected abstract string BuscaInfoClient2();


        public virtual string BuscarInfoCliente()
        {
            return "Cliente cadastrado";
        }
    }
}
