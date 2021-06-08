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
            Console.WriteLine("O que deseja fazer? \n 1 - Cadastrar \n 2 - Logar ");
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
                usuario.Data_cadastro = DateTime.Now;
                Console.WriteLine($@"A data do cadastro foi {usuario.Data_cadastro}"); 
                usuario.Cadastrar(usuario);
                repetir = true;
                    break;
                case "2":
                login.Logar(usuario);
                repetir = false;
                /* Aqui entra a parte dos menus para cadastro de marca e produto, delete de usuario e deslogar */
                    break;
                default:
                Console.WriteLine("Opção não encontrada digite algo valido");
                repetir = true;
                    break;
            }
            } while (repetir);
        }
    }
}
