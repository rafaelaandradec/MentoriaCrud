using MentoriaCrud.Models;
using MentoriaCrud.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentoriaCrud.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioReposit _usuarioReposit;

        public UsuarioController(IUsuarioReposit usuarioReposit)
        {
            _usuarioReposit = usuarioReposit;
        }

        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioReposit.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario = _usuarioReposit.BuscarPorID(id);
            return View(usuario);
        }


        public IActionResult ExcluirConfirma(int id)
        {
            UsuarioModel usuario = _usuarioReposit.BuscarPorID(id);
            return View(usuario);
        }

        public IActionResult Excluir(int id)
        {

            try
            {
                bool excluido = _usuarioReposit.Excluir(id);

                if (excluido) TempData["MensagemSucesso"] = "Usuário excluído com sucesso!";
                else TempData["MensagemErro"] = "Não foi possível realizar esta ação, por favor tente novamente!";
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possivel excluir o usuário, atualize a págine e tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }

        }


        //Aqui o método recebe e registra as informações de um usuário
        [HttpPost]
        public IActionResult Criar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioReposit.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Não foi possível cadastrar o usuário, atualize a página e tente novamente! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }


        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    usuario = _usuarioReposit.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso!";
                    return RedirectToAction("Index");
                }

                return View(usuario);
            }
            catch (Exception)
            {
          
                TempData["MensagemErro"] = $"Não foi possível atualizar o usuário, recarregue a página e tente novamente!";
                return RedirectToAction("Index");
            }
        }
    }
}