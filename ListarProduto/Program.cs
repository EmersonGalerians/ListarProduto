using System;
using System.Data;
using System.Data.SqlClient;
using Listar_lib;


namespace ListarProduto
{
    class Program
    {
        static void Main(string[] args)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=TI_Noite;User ID=Turma2022;Password=Turma2022@2022";

            string p_Nome_Produto = "Poste do Jax";

            DataSet loja = new DataSet();
            try
            {
                switch () { 
                
                
                }
                SqlConnection Conexao = new SqlConnection(Chaveconexao);
                Conexao.Open();
                string wQuery = $"select * from Produto where Nome_Produto = '{p_Nome_Produto}'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(loja);
                // Conexao.Open();


           
                foreach (DataRow linha in loja.Tables[0].Rows)
                {
                    Console.WriteLine(linha["Nome_Produto"]);
                }



            }
            catch (Exception)
            {



                throw;
            }
        }
    }
}
