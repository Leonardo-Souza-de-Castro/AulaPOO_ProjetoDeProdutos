using AulaPOO_ProjetoDeProdutos.Interfaces;
using System;
using System.Collections.Generic;

namespace AulaPOO_ProjetoDeProdutos.Classes
{
    public class Produto : IProduto
    {
        public int CodigoProduto { get; set; }
        public string NomeProduto { get; set; }
        public DateTime DataCadastroP { get; set; }
        public float Preco { get; set; }
        public string marca { get; set; }
        public string user7 { get; set; }

        public List<Produto> ListaProdutos = new List<Produto>();

        Usuario us = new Usuario();

        public Produto()
        {

        }
        public Produto(string _nome, float _preco, string mar, Usuario user)
        {
            this.NomeProduto = _nome;
            this.DataCadastroP = DateTime.Now;
            this.Preco = _preco;
            this.marca = mar;
            Random cod = new Random();
            this.CodigoProduto = cod.Next(0, 9999);
            this.user7 = user.Nome;
        }
        public string Cadastrar(Produto produto)
        {
            ListaProdutos.Add(produto);
            return "Produto cadastrado com sucesso!";
        }

        public void Listar()
        {
            foreach (Produto item in ListaProdutos)
            {
                Console.WriteLine($@" 
                ============================================
                |Nome: {item.NomeProduto}
                ============================================
                |Código: {item.CodigoProduto}
                ============================================
                |Data de cadastro: {item.DataCadastroP}
                ============================================
                |Marca: {item.marca}
                ============================================
                |Preço: {item.Preco:C2}
                ============================================
                |Usuário: {item.user7}
                ============================================");

                Console.WriteLine("\n");
            }
        }

        public void Deletar()
        {
            foreach (var item in ListaProdutos)
            {
                Console.WriteLine($"\nProdutos Cadastrados: {item.NomeProduto} \n");
            }

            Console.WriteLine("Digite o nome do produto a ser deletado");
            string produto_deletar = Console.ReadLine();
            ListaProdutos.RemoveAll(item => item.NomeProduto == produto_deletar);
            Console.WriteLine($@"Produto: {produto_deletar}, foi removido do sistema");
        }
    }
}