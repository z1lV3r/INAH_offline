//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace INAH
{
    using System;
    using System.Collections.Generic;
    
    public partial class composicion
    {
        public string Numero_de_inventario { get; set; }
        public string Materia_prima { get; set; }
        public string Tecnica_de_manufactura { get; set; }
        public string Tecnica_decorativa { get; set; }
    
        public virtual piezas piezas { get; set; }
    }
}
