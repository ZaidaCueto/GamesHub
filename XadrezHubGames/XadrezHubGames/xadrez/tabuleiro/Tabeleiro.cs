namespace tabuleiro
{
    public class Tabeleiro
    {
        public int linhas { get; set; }
        public int colunas { get; set; }
        private Peca[,] pecas;

        public Tabeleiro(int linha, int coluna)
        {
            this.linhas = linha;
            this.colunas = coluna;
            pecas = new Peca[linha, coluna];
        }

        public Peca peca(int linha, int coluna)
        {
            return pecas[linha, coluna];
        }
    }
}