using System;
using System.Collections.Generic;
using AulaPOO_ProjetoDeProdutos.Interfaces;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Usuario : IUsuario
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public static DateTime Now { get; }
        public List<Usuario> usuarios = new List <Usuario>();
        public int i {get; set;}


        public string Cadastrar(Usuario usuario)
        {
            usuarios.Add(usuario);
            return "Usuario cadastrado com sucesso";
        }

        public string Deletar(Usuario usuario)
        {
            Console.WriteLine("Digite o nome de usuario a ser deletado");
            string usuario_deletar = Console.ReadLine();
            usuarios.RemoveAll(usuario => usuario.Nome == usuario_deletar);
            return $@"Usuario: {usuario_deletar}, foi removido do sistema";
        }
    }
}