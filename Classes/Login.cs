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
                Console.Write("Insira sua Senha: ");
                string senha = Console.ReadLine();
                Usuario usuario_encontrado = usuario.usuarios.Find(item => item.Senha == senha && item.Email == email);
                Console.WriteLine(email, senha, usuario_encontrado);
                    if (usuario_encontrado != null)
                    {
                        Console.WriteLine("Usuario encontrado!");
                    }else
                    {
                        Console.WriteLine("Usuario ou senha incorretos");
                    }
               
            } while (tentar_novamente);
        }
    }
}