
using HtmlAgilityPack;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace DFind.Domain
{
    public class Produto
    {
        public int Id { get; set; }

        public string Titulo { get; set; }
        public string imagem { get; set; }

        public decimal Economia { get; set; }

        //id
        public int MelhorConsulta { get; set; }
        public int PiorConsulta { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        
        public override string ToString()
        {
            return this.Titulo;
        }

    }
}
