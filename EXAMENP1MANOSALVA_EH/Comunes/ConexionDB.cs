using EXAMENP1MANOSALVA_EH.Model;
using System.Data.SqlClient;
using System.Data;

namespace EXAMENP1MANOSALVA_EH.Comunes
{
    public class ConexionDB
    {
        private static SqlConnection conexion;

        public static SqlConnection abrirConexion()
        {
            conexion = new SqlConnection("Server = ACER\\MSSQLSERVER01; Database = PROYECTO_2; Trusted_Connection = True;");
            conexion.Open();
            return conexion;
        }
        public static List<Futbolista> Futbolistas
        {
            get
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = abrirConexion();
                cmd.CommandText = "SP_GET_FUTBOLISTAS";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                adapter.Fill(dataSet);
                return llenarFutbolistas(dataSet.Tables[0]);
            }
        }

        public static List<Futbolista> GetFutbolistas()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolistas(dataSet.Tables[0]);
        }

        public static Futbolista GetFutbolista(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_JUGADOR", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);
            return llenarFutbolistas(dataSet.Tables[0])[0];
        }

        public static void PostFutbolista(Futbolista objFutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_INS_FUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_NOMBRE", objFutbolista.Nombre);
            cmd.Parameters.AddWithValue("@PV_ACTIVO", objFutbolista.Activo);
            cmd.Parameters.AddWithValue("@PV_FECHA_INICIO", objFutbolista.FechaInicio);
            cmd.Parameters.AddWithValue("@PV_FECHA_FINAL", objFutbolista.FechaFinal);
            cmd.Parameters.AddWithValue("@PV_FECHA_MODIFICACION", objFutbolista.FechaModificacion);
            cmd.Parameters.AddWithValue("@PV_FUTBOLISTA_MODIFICACION", objFutbolista.futbolistaModificacion);
            cmd.ExecuteNonQuery();
        }

        public static void PutFutbolista(int id, Futbolista objFutbolista)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_UPD_FUTBOLISTAS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_JUGADOR", id);
            cmd.Parameters.AddWithValue("@PV_NOMBRE", objFutbolista.Nombre);
            cmd.Parameters.AddWithValue("@PV_ACTIVO", objFutbolista.Activo);
            cmd.Parameters.AddWithValue("@PV_FECHA_INICIO", objFutbolista.FechaInicio);
            cmd.Parameters.AddWithValue("@PV_FECHA_FINAL", objFutbolista.FechaFinal);
            cmd.Parameters.AddWithValue("@PV_FECHA_MODIFICACION", objFutbolista.FechaModificacion);
            cmd.Parameters.AddWithValue("@PV_FUTBOLISTA_MODIFICACION", objFutbolista.futbolistaModificacion);
            cmd.ExecuteNonQuery();
        }

        public static void DeleteFutbolista(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_DEL_FUTBOLISTA";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PV_ID_JUGADOR", id);
            cmd.ExecuteNonQuery();
        }

        private static List<Futbolista> llenarFutbolistas(DataTable dataTable)
        {
            List<Futbolista> lRespuesta = new List<Futbolista>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Futbolista objeto = new Futbolista();
                objeto.Id_jugador = Convert.ToInt32(dr["ID_JUGADOR"]);
                objeto.Nombre = dr["NOMBRE"].ToString();
                objeto.Activo = dr["ACTIVO"].ToString();
                objeto.FechaInicio = dr["FECHA_INICIO"] as DateTime?;
                objeto.FechaFinal = dr["FECHA_FINAL"] as DateTime?;
                objeto.FechaModificacion = dr["FECHA_MODIFICACION"] as DateTime?;
                objeto.futbolistaModificacion = dr["FUTBOLISTA_MODIFICACION"] as DateTime?;
                lRespuesta.Add(objeto);
            }
            return lRespuesta;
        }

        public static List<Futbolista> GetFutbolistasConEquipos()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_FUTBOLISTA_CON_EQUIPOS";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return llenarFutbolistasConEquipos(dataSet);
        }

        private static List<Futbolista> llenarFutbolistasConEquipos(DataSet dataSet)
        {
            List<Futbolista> futbolistas = new List<Futbolista>();
            Dictionary<int, Futbolista> futbolistaDict = new Dictionary<int, Futbolista>();

            DataTable futbolistaTable = dataSet.Tables[0];
            DataTable equipoTable = dataSet.Tables[1];

            foreach (DataRow dr in futbolistaTable.Rows)
            {
                int idJugador = Convert.ToInt32(dr["ID_JUGADOR"]);
                if (!futbolistaDict.ContainsKey(idJugador))
                {
                    Futbolista futbolista = new Futbolista
                    {
                        Id_jugador = idJugador,
                        Nombre = dr["NOMBRE"].ToString(),
                        Activo = dr["ACTIVO"].ToString(),
                        FechaInicio = dr["FECHA_INICIO"] as DateTime?,
                        FechaFinal = dr["FECHA_FINAL"] as DateTime?,
                        FechaModificacion = dr["FECHA_MODIFICACION"] as DateTime?,
                        futbolistaModificacion = dr["FUTBOLISTA_MODIFICACION"] as DateTime?,
                        Equipos = new List<Equipo>()
                    };
                    futbolistas.Add(futbolista);
                    futbolistaDict[idJugador] = futbolista;
                }
            }

            foreach (DataRow dr in equipoTable.Rows)
            {
                int idJugador = Convert.ToInt32(dr["ID_JUGADOR"]);
                if (futbolistaDict.ContainsKey(idJugador))
                {
                    Equipo equipo = new Equipo
                    {
                        Id_equipo = Convert.ToInt32(dr["ID_EQUIPO"]),
                        Nombre = dr["NOMBRE_EQUIPO"].ToString(),
                        FechaInicio = dr["FECHA_INICIO"] as DateTime?,
                        FechaFinal = dr["FECHA_FINAL"] as DateTime?
                    };
                    futbolistaDict[idJugador].Equipos.Add(equipo);
                }
            }

            return futbolistas;
        }

        public static List<Equipo> GetHistorial(int futbolistaId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = abrirConexion();
            cmd.CommandText = "SP_GET_Historial";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FutbolistaId", futbolistaId);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet);

            return llenarEquipos(dataSet.Tables[0]);
        }

        private static List<Equipo> llenarEquipos(DataTable dataTable)
        {
            List<Equipo> equipos = new List<Equipo>();
            foreach (DataRow dr in dataTable.Rows)
            {
                Equipo equipo = new Equipo
                {
                    Id_equipo = Convert.ToInt32(dr["Id_equipo"]),
                    Nombre = dr["NombreEquipo"].ToString(),
                    FechaInicio = dr["FechaInicio"] as DateTime?,
                    FechaFinal = dr["FechaFinal"] as DateTime?
                };
                equipos.Add(equipo);
            }
            return equipos;
        }

    }
}
