namespace DevFreela.Core.Entidades
{
    public abstract class EntidadeBase
    {
        protected EntidadeBase()
        {
            DataCriacao = DateTime.Now;
            EstaDeletado = false;
        }

        public int Id { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public bool EstaDeletado { get; private set; }

        public void MarcarComoDeletado()
        {
            EstaDeletado = true;
        }
    }
}