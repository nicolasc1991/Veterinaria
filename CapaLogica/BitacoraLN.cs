using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidad;
using CapaAccesoDatos;

namespace CapaLogica
{
    public class BitacoraLN
    {
        #region "PATRON SINGLETON"
        private static BitacoraLN objBitacora = null;
        public BitacoraLN()
        {

        }
        public static BitacoraLN getInstance()
        {
            if (objBitacora == null)
            {
                objBitacora = new BitacoraLN();
            }
            return objBitacora;
        }
        public List<Bitacora> ListarBitacora()
        {
            try
            {
                return BitacoraDAO.getInstance().ListarBitacora();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
