using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    class Menu
    {
        DAO acesso;
        public int opcao;
        public int codigo;

        public Menu()
        {
            acesso = new DAO();
        }//fim do construtor

        public void MostrarMenu()
        {
            try
            {
                Console.WriteLine("--------- MENU -----------\n" +
                                 "Escolha uma das opções abaixo: " +
                                 "\n1. Inserir" +
                                 "\n2. Consultar Tudo" +
                                 "\n3. Consultar Nome" +
                                 "\n4. Consultar Telefone" +
                                 "\n5. Consultar Endereço" +
                                 "\n6. Atualizar" +
                                 "\n7. Excluir" +
                                 "\n8. Sair");
                opcao = Convert.ToInt32(Console.ReadLine());
            }catch(Exception e)
            {
                Console.WriteLine("Algo deu errado!" + e);
            }
        }//fim do método

        public void Operacao()
        {
            do
            {
                MostrarMenu();

                switch (opcao)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("-------- Cadastrar ----------");
                        Console.WriteLine("Informe o seu nome: ");
                        string nome = Console.ReadLine();
                        Console.WriteLine("Informe o seu telefone: ");
                        string telefone = Console.ReadLine();
                        Console.WriteLine("Informe o seu endereço: ");
                        string endereco = Console.ReadLine();
                        //passar para método
                        acesso.Inserir(nome, telefone, endereco);
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("-------- Consultar Tudo ----------");
                        //passar para método
                        acesso.ConsultarTudo();
                        break;
                    case 3:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("-------- Consultar Nome ----------");
                            Console.WriteLine("Informe o código da pessoa que deseja consultar");
                            codigo = Convert.ToInt32(Console.ReadLine());
                            //passar para método
                            Console.WriteLine("Nome: " + acesso.ConsultarNome(codigo));
                        }catch(Exception e)
                        {
                            Console.WriteLine("Algo deu errado!" + e);
                        }
                        break;
                    case 4:
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("-------- Consultar Telefone ----------");
                            Console.WriteLine("Informe o código da pessoa que deseja consultar");
                            codigo = Convert.ToInt32(Console.ReadLine());
                            //passar para método
                            Console.WriteLine("Telefone: " + acesso.ConsultarTelefone(codigo));
                        }catch(Exception e)
                        {
                            Console.WriteLine("Algo deu errado!" + e);
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("-------- Consultar Endereço ----------");
                        Console.WriteLine("Informe o código da pessoa que deseja consultar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //passar para método
                        Console.WriteLine("Endereço: " + acesso.ConsultarEndereco(codigo));
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("-------- Atualizar ----------");

                        Console.WriteLine("Informe o código da pessoa que deseja Atualizar");
                        codigo = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Informe o campo que deseja atualizar");
                        string campo = Console.ReadLine();

                        Console.WriteLine("Informe o novo dado");
                        string novoDado = Console.ReadLine();
                        //passar para método
                        acesso.Atualizar(campo, novoDado, codigo);
                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("-------- Deletar ----------");

                        Console.WriteLine("Informe o código da pessoa que deseja deletar");
                        codigo = Convert.ToInt32(Console.ReadLine());
                        //passar para método
                        acesso.Deletar(codigo);
                        break;
                    case 8:
                        Console.Clear();
                        Console.WriteLine("Obrigado!!!");
                        break;
                    default:
                        Console.WriteLine("Código informado não existe!");
                        break;
                }//fim do switch
            } while (opcao != 8);
        }//fim do operacao
    }//fim da classe menu
}//fim do projeto TESTE
