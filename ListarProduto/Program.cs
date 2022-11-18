using System;
using System.Data;
using System.Data.SqlClient;

namespace ListarProduto
{
    class Program
    {
        static void Main(string[] args)
        {
            string Chaveconexao = "Data Source=10.39.45.44;Initial Catalog=TI_Noite;User ID=Turma2022;Password=Turma2022@2022";




            /// <summary>
            /// Processo de consulta (SELECT )de CEP no banco de dados
            /// </summary>
            /// <param name="p_CEP"></param>
            /// <returns></returns>



            string p_Nome_Produto = "Cera Incolor";



            DataSet DataSetProduto = new DataSet();
            try
            {
                SqlConnection Conexao = new SqlConnection(Chaveconexao);
                Conexao.Open();
                string wQuery = $"select * from Produto where Nome_Produto = '{p_Nome_Produto}'";
                SqlDataAdapter adapter = new SqlDataAdapter(wQuery, Conexao);
                adapter.Fill(DataSetProduto);
                // Conexao.Open();



                foreach (DataRow linha in DataSetProduto.Tables[0].Rows)
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
