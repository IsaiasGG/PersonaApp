using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonaApp
{
    public partial class FrmPersona : Form
    {
        public FrmPersona()
        {
            InitializeComponent();
            CargarPersonas();
        }

        private void CargarPersonas()
        {
            List<Persona> personas = ObtenerTodasLasPersonas();

            dataGridView1.DataSource = personas;
            dataGridView1.Columns["IdPersona"].Visible = false;
            dataGridView1.Columns["FechaDeNacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns["FechaDeNacimiento"].Width = 120;
        }

        public static List<Persona> ObtenerTodasLasPersonas()
        {
            List<Persona> personas = new List<Persona>();

            using (SqlConnection connection = new SqlConnection("Server=.\\SQLExpress;Database=EvaluacionWepsys;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("ConsultarPersonas", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Persona persona = new Persona();
                            persona.IdPersona = Convert.ToInt32(reader["IdPersona"]);
                            persona.Nombres = reader["Nombres"].ToString();
                            persona.Apellidos = reader["Apellidos"].ToString();
                            persona.Matricula = reader["Matricula"].ToString();
                            persona.FechaDeNacimiento = Convert.ToDateTime(reader["FechaDeNacimiento"]);
                            persona.UbicacionLatitud = Convert.ToDecimal(reader["UbicacionLatitud"].ToString());
                            persona.UbicacionLongitud = Convert.ToDecimal(reader["UbicacionLongitud"].ToString());
                            persona.UbicacionAltitud = Convert.ToDecimal(reader["UbicacionAltitud"].ToString());
                            personas.Add(persona);
                        }
                    }
                }
            }

            return personas;
        }
    }
}
