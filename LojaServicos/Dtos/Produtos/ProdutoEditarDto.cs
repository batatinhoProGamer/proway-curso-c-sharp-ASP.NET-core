namespace LojaServicos.Dtos.Produtos
{
    public class ProdutoEditarDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}
