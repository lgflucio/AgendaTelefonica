using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AgendaTelefonica.Data;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.Controllers
{
    public class ContatosController : Controller
    {
        private AgendaContext db = new AgendaContext();

        // GET: Contatos
        public ActionResult Index()
        {
            //FAZ A CONSULTA NO BANCO DE DADOS NA TABELA DE CONTATOS
            List<Contatos> _contatos = db.Contatos.ToList();

            return View(_contatos);
        }

        // GET: Contatos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FAZ A CONSULTA NO BANCO DE DADOS E VALIDA SE EXISTE O REGISTRO PARA EXIBIR
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // GET: Contatos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contatos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Telefone,Email,DataCriacao,Modificado,Ativo")] Contatos contatos)
        {
            //VERIFICA SE O CORPO DA PAGINA ESTA DE ACORDO COM O ESPERADO DO METODO
            if (ModelState.IsValid)
            {
                //CRIA O NOVO CONTATO NO BANCO DE DADOS
                contatos.DataCriacao = DateTime.Now;
                contatos.Ativo = true;
                db.Contatos.Add(contatos);
                //COMMIT AS ALTERACOES NO BANCO DE DADOS
                db.SaveChanges();
                //RETORNA PARA A PAGINA PRINCIPAL APÓS CRIACAO DO CONTATO NO BANCO
                return RedirectToAction("Index");
            }

            return View(contatos);
        }

        // GET: Contatos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FAZ A CONSULTA NO BANCO DE DADOS E VALIDA SE EXISTE O REGISTRO PARA EXIBIR
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // POST: Contatos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Telefone,Email,DataCriacao,Modificado,Ativo")] Contatos contatos)
        {
            if (ModelState.IsValid)
            {
                //ATUALIZA OS DADOS DO CONTATO NO BANCO DE DADOS SETANDO A TABELA DE CONTATOS COMO MODIFICADA
                contatos.Modificado = DateTime.Now;
                db.Entry(contatos).State = EntityState.Modified;
                //COMMIT A ALTERACAO NO BANCO DE DADOS NA TABELA DE CONTATO
                db.SaveChanges();
                //VOLTA PARA PAGINA PRINCIPAL
                return RedirectToAction("Index");
            }
            return View(contatos);
        }

        // GET: Contatos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //FAZ A CONSULTA NO BANCO DE DADOS E VALIDA SE EXISTE O REGISTRO PARA EXIBIR
            Contatos contatos = db.Contatos.Find(id);
            if (contatos == null)
            {
                return HttpNotFound();
            }
            return View(contatos);
        }

        // POST: Contatos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //FAZ A CONSULTA NO BANCO DE DADOS E VALIDA SE EXISTE O REGISTRO PARA PODER DE FATO EXCLUIR UM REGISTRO VALIDO
            Contatos contatos = db.Contatos.Find(id);

            //FAZ A DELEÇÃO DO CONTATO DO BANCO DE DADOS
            db.Contatos.Remove(contatos);
            //COMMIT A REMOCAO DO CONTATO DO BANCO DE DADOS
            db.SaveChanges();
            //RETORNA PARA PAGINA PRINCIPAL
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            //DESCONECTA O BANCO PARA NAO FICAR COM UMA CONEXAO ATIVA DESNECESSARIAMENTE.
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
