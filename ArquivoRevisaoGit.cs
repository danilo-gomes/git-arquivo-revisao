using LibGit2Sharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GitNetCore
{
    public class ArquivoRevisaoGit
    {
        public void ObterPorHeadParent(string caminhoGit)
        {

            var repo = new Repository(@"D:\DATA\pipeline-sqbi");

            var blob = repo.Head.Tip[caminhoGit].Target as Blob;
            var blobAnterior = repo.Head.Tip.Parents.First()[caminhoGit].Target as Blob;

            string conteudoAtual = ObterConteudoArquivo(blob);
            string conteudoAnterior = ObterConteudoArquivo(blobAnterior);

        }

        public void ObterPorLookupSHA(string commit, string caminhoGit)
        {
            var repo = new Repository(@"D:\DATA\pipeline-sqbi");

            var controllerAnterior = repo.Lookup($"{commit}~1:{caminhoGit}") as Blob;
            string conteudoAnterior = ObterConteudoArquivo(controllerAnterior);

            var controller2CommitsAnteriores = repo.Lookup($"{commit}~2:{caminhoGit}") as Blob;
            string conteudo2CommitsAnteriores = ObterConteudoArquivo(controller2CommitsAnteriores);
        }

        private string ObterConteudoArquivo(Blob arquivo)
        {
            string conteudo;
            using (var content = new StreamReader(arquivo.GetContentStream(), Encoding.UTF8))
            {
                conteudo = content.ReadToEnd();
            }

            return conteudo;
        }
    }
}
