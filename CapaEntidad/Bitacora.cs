using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Bitacora
    {
        public int id { get; set; }
        public String accion { get; set; }
        public String usuario { get; set; }
        public DateTime create_at { get; set; }

        public Bitacora()
        {

        }
        public Bitacora(int id,String accion,String usuario,DateTime create_at)
        {
            this.id = id;
            this.accion = accion;
            this.usuario = usuario;
            this.create_at = create_at;
        }
    }
}
