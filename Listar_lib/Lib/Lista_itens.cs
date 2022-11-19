using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Listar_lib.Itens
{
    public class Lista_itens
    {
        string ChaveConexao = "Data Source=10.39.45.44;Initial Catalog=TI_NOITE;Persist Security Info=True;User ID=Turma2022;Password=Turma2022@2022";
        public DataSet List_LOL(string tipo_pesquisa, string p_nome)
        {
            DataSet DataSetlol = new DataSet();

            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery =
                        $"SELECT p.id_produto " +
                        $",p.id_produto_grupo " +
                        $",p.Nome_produto " +
                        $",p.Descricao " +
                        $",p.Codigo_Interno " +
                        $",p.Data_Cadastro " +
                        $",p.Status " +
                        $",g.id_produto Grupo_id_produto " +
                        $", g.id_produto_grupo Grupo_id_produto_grupo " +
                        $", g.Nome_produto Grupo_Nome_produto " +
                        $", g.Descricao Grupo_Descricao " +
                        $", g.Codigo_Interno Grupo_Codigo_Interno " +
                        $", g.Data_Cadastro Grupo_Data_Cadastro " +
                        $", p.Status " +
                        $"FROM Produto p, Produto g " +
                        $"where p.id_produto_grupo = p.id_produto ";

                switch (tipo_pesquisa.ToUpper())
                {
                    case "PRODUTO":
                        wQuery = wQuery + $" and p.Nome_produto = '{p_nome}'"; 
                        break;
                    case "GRUPO":
                        wQuery = wQuery + $" and g.Nome_produto = '{p_nome}'";
                        break;
                    case "LISTA_PRODUTO":
                        wQuery = wQuery + $" and p.Nome_produto like '%{p_nome}%'";
                        break;
                    case "LISTA_GRUPO":
                        wQuery = wQuery + $" and g.Nome_produto like '%{p_nome}%'";
                        break;
                    default:
                        break;
                }

                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(DataSetlol);
                Conexao.Close();
            }
            catch (Exception) {
                throw;
            }
            return DataSetlol;
        }
        public void Apagar_lol(string p_lol)
        {
            try
            {
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
            try
            {
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
            )
        {
            try
            {
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
            catch (Exception)
            {

            }
        }
        public DataSet Pesquisar_lol(string p_lol)
        {
            DataSet loja = new DataSet();

            Console.WriteLine(p_lol);
            try
            {
                SqlConnection Conexao = new SqlConnection(ChaveConexao);
                Conexao.Open();
                string wQuery = $"select * from Customer_List where Name like '%{p_lol}%'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(loja);
                Conexao.Close();

            }
            catch (Exception)
            {

            }
            return loja;
        }
        private void add_cep(Loja loja)
        {
            DataSet DataSetPesquisa = new DataSet();
            //DataSetPesquisa = List_LOL(loja.idProduto);

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
            else
            {
                Console.WriteLine($"Ja existe dados para esse item {loja.idProduto}" +
                    $"quantidade de registro {DataSetPesquisa.Tables[0].Rows.Count.ToString()}");
            }

        }
    }

}
