using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;

namespace Teste
{
    class DAO
    {
        public string dados;
        public string resultado;
        private MySqlConnection conexao;
        public int[] codigo;
        public string[] nome;
        public string[] telefone;
        public string[] endereco;
        public int i;
        public int contador;
        public string msg;
        //public DataSet conexaoDataSet;
        //Construtor
        public DAO()
        {
            //conexaoDataSet = new DataSet();
            conexao = new MySqlConnection("server=localhost;DataBase=bancoDeDados;Uid=root;Password=;");
            try
            {
                conexao.Open();//Tentando abrir a conexão com o BD
                Console.WriteLine("Entrei");
                Console.ReadLine();//Manter o Promp Aberto
            }
            catch(Exception excecao)
            {
                Console.WriteLine("Algo deu errado\n\n" + excecao);
                Console.ReadLine();//Manter o Promp Aberto
                conexao.Close();
            }//fim da tentativa de conexão com o BD     
        }//fim do construtor

        //Inserir 
        public void Inserir(string nome, string telefone, string endereco)
        {
            try
            {
                //Guardando na variável dados, todos os dados da parte Value do Insert
                dados = "'','" + nome + "','" + telefone + "','" + endereco + "'";
                resultado = "Insert into Pessoa(codigo, nome, telefone, endereco) values(" + dados + ")";
                //Executando o insert no BD
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();
                //Mostrar em tela o resultado da operação
                Console.WriteLine(resultado + "Linhas Afetadas");
                Console.ReadLine();//Deixar o Prompt Aberto
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }//fim do método Inserir

        public void PreencherVetor()
        {
            string query = "select * from pessoa";//Comando para consultar os dados do BD

            //Criando os vetores 
            codigo = new int[10];
            nome = new string[10];
            telefone = new string[10];
            endereco = new string[10];

            //instanciar = dar valores iniciais nos vetores
            for(int i=0;i < 10; i++)
            {
                codigo[i] = 0;
                nome[i] = "";
                telefone[i] = "";
                endereco[i] = "";
            }//fim da Repetição

            //Criar o comando para a coleta
            MySqlCommand cmd = new MySqlCommand(query, conexao);
            //Comando de leitura dos dados
            MySqlDataReader dataReader = cmd.ExecuteReader();
            i = 0;
            contador = 0;
            while (dataReader.Read())
            {
                codigo[i] = Convert.ToInt32(dataReader["codigo"]);
                nome[i] = dataReader["nome"] + "";
                telefone[i] = dataReader["telefone"] + "";
                endereco[i] = dataReader["endereco"] + "";
                contador++;
                i++;
            }//fim do while

            //Fechar o dataReader
            dataReader.Close();
        }//fim do selecionarTudo

        public void ConsultarTudo()
        {
            //Preencher o vetor
            PreencherVetor();
            msg = "";
            for(int i = 0; i < contador; i++)
            {
                msg += "\nCódigo: " + codigo[i] + ", Nome: " + nome[i] +
                      ", Telefone: " + telefone[i] + ", Endereço: " + endereco[i];
            }
            Console.WriteLine(msg);
            Console.ReadLine();
        }//fim do consultar tudo

        public string ConsultarNome(int cod)
        {
            PreencherVetor();
            for(int i = 0; i < contador; i++)
            {
                if(cod == codigo[i])
                {
                    return nome[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarNome

        public string ConsultarTelefone(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return telefone[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarTelefone

        public string ConsultarEndereco(int cod)
        {
            PreencherVetor();
            for (int i = 0; i < contador; i++)
            {
                if (cod == codigo[i])
                {
                    return endereco[i];
                }
            }//fim do for
            return "Código não encontrado!";
        }//fim do consultarEndereco

        public void Atualizar(string campo, string novoDado, int codigo)
        {
            try
            {
                resultado = "update pessoa set " + campo + " = '" + novoDado +
                            "' where codigo = '" + codigo + "'";

                //Executar o comando MySQL Command
                MySqlCommand sql = new MySqlCommand(resultado, conexao);
                resultado = "" + sql.ExecuteNonQuery();

                //Mostro o resultado
                Console.WriteLine(resultado + " Linhas afetadas ");
            }
            catch(Exception e)
            {
                Console.WriteLine("\n\n\nErro: " + e);
            }
        }//fim do método

        public void Deletar(int codigo)
        {
            resultado = "delete from pessoa where codigo = " + codigo;
            //Executar esse comando na base
            MySqlCommand sql = new MySqlCommand(resultado, conexao);
            resultado = "" + sql.ExecuteNonQuery();
            //Mensagem...
            Console.WriteLine(resultado + " Linhas Deletadas");
        }//fim do método deletar
    }//fim da classe
}//fim do projeto
