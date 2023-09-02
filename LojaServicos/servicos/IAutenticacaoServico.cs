using LojaServicos.Dtos.Autenticacao;
using Microsoft.AspNetCore.Http;

namespace LojaServicos.servicos;

public interface IAutenticacaoServico
{
    void Autenticar(AutenticarDto autenticarDto, ISession session);
    void Sair(ISession session);
}