using System;
using System.Data;
using System.Data.SqlClient;
using Listar_lib.Itens;


namespace ListarProduto
{
    class Program
    {
        static void Main(string[] args)
        {

            Lista_itens oLista = new Lista_itens();
            DataSet ListProuto = new DataSet();

            ListProuto = oLista.List_LOL("LISTA_PRODUTO", "MAN");

            foreach (DataRow linha in ListProuto.Tables[0].Rows)
            {
                Console.WriteLine(linha["Nome_Produto"]);
            }

        }
    }
}
