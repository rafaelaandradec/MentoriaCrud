using MentoriaCrud.Data;
using MentoriaCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentoriaCrud.Repositorio
{
    public class UsuarioReposit : IUsuarioReposit
    { 

        private readonly BcoContext _bcoContext;

        public UsuarioReposit(BcoContext bcoContext)
        {
            this._bcoContext = bcoContext;
        }

        public UsuarioModel BuscarPorID(int id)
        {
            return _bcoContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        //Lista as informações do banco de dados
        public List<UsuarioModel> BuscarTodos()
        {
            return _bcoContext.Usuarios.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
        // Gravação no banco de dados
            _bcoContext.Usuarios.Add(usuario);
            _bcoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorID(usuario.Id);

            if (usuarioDB == null) throw new Exception("Alerta de erro ao atualizar usuário");

            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Telefone = usuario.Telefone;

            _bcoContext.Usuarios.Update(usuarioDB);
            _bcoContext.SaveChanges();

            return usuarioDB;
        }

        public bool Excluir(int id)
        {
            UsuarioModel usuarioDB = BuscarPorID(id);

            if (usuarioDB == null) throw new Exception("Alerta de erro ao excluir usuário");
            _bcoContext.Usuarios.Remove(usuarioDB);
            _bcoContext.SaveChanges();

            return true;
        }
        
    }
}
