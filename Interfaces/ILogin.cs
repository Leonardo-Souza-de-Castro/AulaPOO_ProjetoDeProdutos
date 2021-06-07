using AulaPOO_ProjetoDeProdutos.Classes;

namespace AulaPOO_ProjetoDeProdutos.Interfaces
{
    public interface ILogin
    {
        string Logar(Usuario usuario);
        string Deslogar(Usuario usuario);
    }
}