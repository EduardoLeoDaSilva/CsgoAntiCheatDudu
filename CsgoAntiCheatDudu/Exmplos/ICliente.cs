namespace CsAntiCheat.Exmplos
{
    public interface ICliente
    {
        public void CriarCliente(string cliente);
        public void DeletarClient(string cliente);
        public List<Cliente> BuscarCliente(string cliente);
        public void AtualizarCliente(string cliente);
    }
}
