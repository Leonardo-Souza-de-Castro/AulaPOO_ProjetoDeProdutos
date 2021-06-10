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
                                Console.WriteLine("O que fazer agora? \n 1 - Cadastrar Produto \n 2 - Listar Produtos \n 3 - Cadastrar Marcas \n 4 - Listar Marcas \n 0 - Deslogar");
                                string fazer = Console.ReadLine();

                                switch (fazer)
                                {
                                    case "1":
                                        reiniciar_menu = true;
                                        break;
                                    case "2":
                                        reiniciar_menu = true;
                                        break;
                                    case "3":
                                        reiniciar_menu = true;
                                        break;
                                    case "4":
                                        reiniciar_menu = true;
                                        break;
                                    case "0":
                                        Deslogar(usuario_logado);
                                        reiniciar_menu = false;
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
                        Console.WriteLine("Opção Invalida seu imbecil");
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
                string email = Console.ReadLine();
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