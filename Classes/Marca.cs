using AulaPOO_ProjetoDeProdutos.Interfaces;
using System;
using System.Collections.Generic;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Marca : IMarca
    {
        public int codigo { get; set; }
        public string NomeMarca { get; set; }
        public DateTime DataCadastro { get; set; }

        public List<Marca> listaMarcas = new List<Marca>();


        public Marca()
        {

        }

        public Marca(string name)
        {
            this.NomeMarca = name;
            Random cod = new Random();
            this.codigo = cod.Next(0, 9999);
            this.DataCadastro = DateTime.Now;
        }
        public string Cadastrar(Marca marcaCadastrar)
        {
            listaMarcas.Add(marcaCadastrar);
            return "Marca Cadastrada";
        }

        public string Deletar(Marca marcaDeletar)
        {
            listaMarcas.Remove(marcaDeletar);
            return "Marca deletada";
        }

        public void Listar()
        {
            Console.WriteLine("A lista de marcas está aqui");
            foreach (Marca item in listaMarcas)
            {
                Console.WriteLine($@"
                ======================================
                |     Código     | {item.codigo}
                ======================================
                |  Nome da marca | {item.NomeMarca}
                ======================================
                |Data de cadastro| {item.DataCadastro}
                ======================================
                ");
                Console.WriteLine("\n");
            }
        }
    }
}