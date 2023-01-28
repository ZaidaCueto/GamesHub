namespace tabuleiro
{
    public class Tabeleiro
    {
        public int linha  { get; set; }
        public int coluna { get; set; }
        private Peca[,] peca;

        public Tabeleiro(int linha, int coluna )
        {
            this.linha = linha;
            this.coluna = coluna;
           peca = new Peca[linha, coluna];
        }
    }
}