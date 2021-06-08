using System;
using AulaPOO_ProjetoDeProdutos.Interfaces;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Login : ILogin
    {
        private bool Logado = false;

        private bool tentar_novamente = true;

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

        public void Logar(Usuario usuario)
        {
            do
            {
                Console.Write("Insira seu Email: ");
                string email = Console.ReadLine();
                var resposta = usuario.usuarios.FindAll(item => item.Email == email).ToString();
                Console.WriteLine(resposta);
                Console.Write("Insira sua Senha: ");
                string senha = Console.ReadLine();
                string resposta_1 = usuario.usuarios.FindAll(item => item.Senha == senha).ToString();
                    if (resposta == email && resposta_1 == senha)
                    {
                        Console.WriteLine("Usuario logado com sucesso!!");
                        Logado = true;
                        tentar_novamente = false;
                    }
                    else if (resposta != email && resposta_1 == senha)
                    {
                        Console.WriteLine("Email errado, por favor tente novamente");
                        Logado = false;
                        tentar_novamente = true;
                    }
                    else if (resposta == email && resposta_1 != senha)
                    {
                        Console.WriteLine("Senha errada, por favor tente novamente");
                        Logado = false;
                        tentar_novamente = true;
                    }
                    else if (resposta != email && resposta_1 != senha)
                    {
                        Console.WriteLine("Senha e Email errados por favor verifique se você ja se cadastrou");
                        Logado = false;
                        tentar_novamente = true;
                    }
               
            } while (tentar_novamente);
        }
    }
}