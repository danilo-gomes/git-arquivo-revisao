using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using LibGit2Sharp;

namespace GitNetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string caminhoGit = "src/Sinqia.SQBI.Pipeline.API/Controllers/BuildsController.cs";
            string commit = "5858b381";

            ArquivoRevisaoGit revisao = new ArquivoRevisaoGit();

            revisao.ObterPorHeadParent(caminhoGit);
            revisao.ObterPorLookupSHA(commit, caminhoGit);

            

        }

        
    }
}
