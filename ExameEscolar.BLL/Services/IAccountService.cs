using System;
using System.Collections.Generic;
using System.Text;
using ExameEscolar.ViewModels;

namespace ExameEscolar.BLL.Services
{
    public interface IAccountService
    {
        LoginViewModel Login(LoginViewModel vm);
        bool AddProfessor(UsuarioViewModel vm);
        PaginaDeResultado<UsuarioViewModel> GetAllProfessor(int paginaNumero, int paginaTamanho);
    }
}
