using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace ItensLOL.Itens
{
    class ItensDeJogo
    {
        string ChaveConexao = "Data Source=10.39.45.44;Initial Catalog=Senac2022;Persist Security Info=True;User ID=Turma2022;Password=Turma2022@2022";
        public DataSet List_LOL(string p_lol) {
            DataSet DataSetlol = new DataSet();

            try {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * '%{p_lol}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(DataSetlol);
                Conexao.Close();
            }
            catch (Exception) { }
            return DataSetlol;
        }
        public void Apagar_lol(string p_lol)
        {
            try {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                String oQueryDelete = $"deletar este intem'{p_lol}'";
                SqlCommand Cmd = new SqlCommand(oQueryDelete, Conexao);
                Conexao.Close();
            }
            catch (Exception) { }
        }
        public void Alterar_lol(
            string p_grupo,
            string p_nome,
            string p_descricao,
            string p_codigo,
            string p_idProduto
            )
        {
            try {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                String oQueryUpdate = "" +
                    $"grupo{p_grupo}" +
                    $"nome{p_nome}" +
                    $"descrição{p_descricao}" +
                    $"código{p_codigo}" +
                    $"idProduto{p_idProduto}";
                SqlCommand Cmd = new SqlCommand(oQueryUpdate, Conexao);
                Cmd.ExecuteNonQuery();
                Conexao.Close();

            }
            catch (Exception) { }

        }
        public void Adicionar_lol(
            string p_grupo,
            string p_nome,
            string p_descricao,
            string p_codigo,
            string p_idProduto
            ) {
            try {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                String oQueryInsert = "Inserir Item" +
                    $"([grupo]      " +
                    $",[nome]       " +
                    $",[descricao]  " +
                    $",[codigo]     " +
                    $",[idproduto]) " +
                    $"VALUES        " +
                    $"'{p_grupo}" +
                    $"'{p_nome}" +
                    $"'{p_descricao}" +
                    $"'{p_codigo}" +
                    $"'{p_idProduto}";
                SqlCommand Cmd = new SqlCommand(oQueryInsert, Conexao);
                Cmd.ExecuteNonQuery();
                Conexao.Close();
            }
            catch (Exception) {

            }
        }
        public Loja Pesquisar_lol(string p_lol) {
            DataSet loja = new DataSet();

            Console.WriteLine(p_lol);
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * from Customer_List where Name like '%{p_CEP}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(loja);
                Conexao.Close();

            }
            catch (Exception) {

            }
        }
        private void add_cep(Loja loja) {
            DataSet DataSetPesquisa = new DataSet();
            DataSetPesquisa = List_LOL(loja.idProduto);

            if (DataSetPesquisa.Tables[0].Rows.Count == 0)
            {
                Adicionar_lol(
                    loja.grupo,
                    loja.nome,
                    loja.descricao,
                    loja.codigo,
                    loja.idProduto
                    );
            }
            else {
                Console.WriteLine($"Ja existe dados para esse item {loja.idProduto}" +
                    $"quantidade de registro {DataSetPesquisa.Tables[0].Rows.Count.ToString()}");
            }

        }
    }

}
