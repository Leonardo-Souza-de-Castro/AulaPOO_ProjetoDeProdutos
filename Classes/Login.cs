using System;
using AulaPOO_ProjetoDeProdutos.Interfaces;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Login : ILogin
    {
        private bool Logado = false;

        private bool tentar_novamente = true;

        private bool recomecar_menu1 = true;

        private bool reiniciar_menu = true;

        Usuario usuario = new Usuario();
        Usuario usuario_logado = new Usuario();

        Produto produto = new Produto();

        Marca marca = new Marca();

        public string email = null;
        public Login(int i)
        {
            do
            {
                Console.WriteLine("O que deseja fazer? \n 1 - Cadastrar \n 2 - Login \n 3 - Deletar Usuario");
                string resposta = Console.ReadLine();


                switch (resposta)
                {
                    case "1":
                        Usuario usuario_dados = new Usuario();
                        usuario_dados.Codigo = i++;
                        Console.WriteLine("Qual seu Nome");
                        usuario_dados.Nome = Console.ReadLine();
                        Console.WriteLine("Qual seu Email");
                        usuario_dados.Email = Console.ReadLine();
                        Console.WriteLine("Qual sua Senha");
                        usuario_dados.Senha = Console.ReadLine();
                        usuario_dados.Data_cadastro = DateTime.Now;
                        Console.WriteLine($@"A data do cadastro foi {usuario_dados.Data_cadastro}");

                        usuario.Cadastrar(usuario_dados);

                        usuario_logado = usuario_dados;

                        recomecar_menu1 = true;
                        break;
                    case "2":
                        Console.Clear();

                        if (usuario.usuarios.Count > 0)
                        {
                            Logar();
                            recomecar_menu1 = false;
                            do
                            {
                                Console.WriteLine("O que fazer agora? \n1 - Cadastrar Produto \n2 - Listar Produtos \n3 - Cadastrar Marcas \n4 - Listar Marcas \n5 - Deletar Produto \n6 - Deletar Marca \n0 - Deslogar");
                                string fazer = Console.ReadLine();

                                switch (fazer)
                                {
                                    case "1":
                                        if (marca.listaMarcas.Count > 0)
                                        {
                                            Console.WriteLine($"Qual o nome do produto?");
                                            string Nome = Console.ReadLine();
                                            Console.WriteLine($"Qual o preço do produto?");
                                            float preco = float.Parse(Console.ReadLine());

                                            marca.Listar();
                                            Console.WriteLine("Qual o nome da marca que você deseja?");
                                            string resposta_nome = Console.ReadLine();

                                            string marca_escolhida = marca.listaMarcas.Find(item => item.NomeMarca == resposta_nome).NomeMarca;
                                            Usuario user = usuario.usuarios.Find(item => item.Email == email);
                                            Produto cadastrar_produto = new Produto(Nome, preco, marca_escolhida, user);
                                            produto.Cadastrar(cadastrar_produto);
                                            reiniciar_menu = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Por favor cadastre uma marca antes");
                                            reiniciar_menu = true;
                                        }

                                        break;
                                    case "2":
                                        if (produto.ListaProdutos.Count > 0)
                                        {
                                            produto.Listar();
                                            reiniciar_menu = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Cadastre um produto antes de listar");
                                            reiniciar_menu = true;
                                        }

                                        break;
                                    case "3":
                                        Console.WriteLine("Qual o nome da marca?");
                                        string nome_marca = Console.ReadLine();

                                        Marca cadastrar_marca = new Marca(nome_marca);

                                        marca.Cadastrar(cadastrar_marca);
                                        reiniciar_menu = true;
                                        break;
                                    case "4":
                                        if (marca.listaMarcas.Count > 0)
                                        {
                                            marca.Listar();
                                            reiniciar_menu = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Cadastre uma marca antes de listar");
                                            reiniciar_menu = true;
                                        }
                                        break;
                                    case "5":
                                        if (produto.ListaProdutos.Count > 0)
                                        {
                                            produto.Deletar();
                                            reiniciar_menu = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Cadastre um produto antes de deletar");
                                            reiniciar_menu = true;
                                        }
                                        break;
                                    case "6":
                                        if (marca.listaMarcas.Count > 0)
                                        {
                                            marca.Deletar();
                                            reiniciar_menu = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Cadastre uma marca antes de deletar");
                                            reiniciar_menu = true;
                                        }
                                        break;
                                    case "0":
                                        Deslogar(usuario_logado);
                                        reiniciar_menu = false;
                                        recomecar_menu1 = true;
                                        break;
                                    default:
                                        reiniciar_menu = true;
                                        break;
                                }
                            } while (reiniciar_menu);
                        }
                        else
                        {
                            Console.WriteLine("Pelo visto você ainda não se cadastro, se cadastre antes de logar");
                            recomecar_menu1 = true;
                        }

                        break;
                    case "3":
                        usuario.Deletar();
                        recomecar_menu1 = true;
                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        break;
                }
            } while (recomecar_menu1);


        }
        public void Deslogar(Usuario usuario)
        {
            if (Logado == true)
            {
                Console.WriteLine($@"{usuario.Nome} deslogado com sucesso");
            }
            else
            {
                Console.WriteLine("Se logue antes de deslogar");
            }
        }

        public void Logar()
        {
            do
            {
                Console.Write("Insira seu Email: ");
                email = Console.ReadLine();
                Console.Write("Insira sua Senha: ");
                string senha = Console.ReadLine();

                Usuario usuario_procurado = usuario.usuarios.Find(item => item.Email == email && item.Senha == senha);
                if (usuario_procurado != null)
                {
                    Console.WriteLine("Logado com Sucesso");
                    tentar_novamente = false;
                    Logado = true;
                }
                else
                {
                    Console.WriteLine("Algo esta errado tente novamente");
                    tentar_novamente = true;
                    Logado = false;
                }
            } while (tentar_novamente);
        }
    }
}