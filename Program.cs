using System;
using AulaPOO_ProjetoDeProdutos.Classes;

namespace AulaPOO_ProjetoDeProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            bool repetir = false;

            do
            {
            Usuario usuario = new Usuario();
            Login login = new Login();
            int i = 0;
            Console.WriteLine("O que deseja fazer? \n 1 - Cadastrar \n 2 - Deletar Cadastro \n 3 - Logar \n 4 - Deslogar");
            string resposta = Console.ReadLine();

            switch (resposta)
            {
                case "1":
                usuario.Codigo = i++;
                Console.WriteLine("Qual seu Nome");
                usuario.Nome = Console.ReadLine(); 
                Console.WriteLine("Qual seu Email");
                usuario.Email = Console.ReadLine(); 
                Console.WriteLine("Qual sua Senha");
                usuario.Senha = Console.ReadLine(); 
                usuario.Cadastrar(usuario);
                repetir = true;
                    break;
                case "2":
                usuario.Deletar(usuario);
                repetir = false;
                    break;
                case "3":
                login.Logar(usuario);
                repetir = true;
                    break;
                case "4":
                login.Deslogar(usuario);
                repetir = false;
                    break;
                default:
                    break;
            }
            } while (repetir);
        }
    }
}
