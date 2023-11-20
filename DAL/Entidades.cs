using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class Usuario
    {

        // Atributos

        [Key] // Indica que es el PK
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Hace que sea autoincrementable
        public long id_usuario { get; set; }
        public string dni_usuario { get; set; }
        public string? nombre_usuario { get; set; } // Se pone ? para indicar que puede ser NULL
        public string? apellidos_usuario { get; set; }
        public string? tlf_usuario { get; set; }
        public string? email_usuario { get; set; }
        public string clave_usuario { get; set; }
        public bool? estaBloqueado_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")] // Para hacer que sea timestamp without time zone
        public DateTime? fch_fin_bloqueo_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_alta_usuario { get; set; }
        [Column(TypeName = "timestamp without time zone")]
        public DateTime? fch_baja_usuario { get; set; }

        // FK

        [ForeignKey(name: "id_acceso")] // Para indicar a quien va a apuntar (PK de acceso)
        [Column(name: "id_acceso")] // Para indicar el nombre que se va a poner en la bd
        public long AccesoId { get; set; }
        public Acceso? Acceso { get;}

        // Constructor

        public Usuario(string dni_usuario, string? nombre_usuario, string? apellidos_usuario, string? tlf_usuario, string? email_usuario, string clave_usuario, bool? estaBloqueado_usuario, DateTime? fch_fin_bloqueo_usuario, DateTime? fch_alta_usuario, DateTime? fch_baja_usuario, long accesoId)
        {
            this.dni_usuario = dni_usuario;
            this.nombre_usuario = nombre_usuario;
            this.apellidos_usuario = apellidos_usuario;
            this.tlf_usuario = tlf_usuario;
            this.email_usuario = email_usuario;
            this.clave_usuario = clave_usuario;
            this.estaBloqueado_usuario = estaBloqueado_usuario;
            this.fch_fin_bloqueo_usuario = fch_fin_bloqueo_usuario;
            this.fch_alta_usuario = fch_alta_usuario;
            this.fch_baja_usuario = fch_baja_usuario;
            this.AccesoId = accesoId;
        }

        // toString


        public void ToString()
        {
            Console.WriteLine("Usuario [Dni:{0}, Nombre:{1}, Apellidos:{2}, Telefono:{3}, Email:{4}, Clave:{5}, EstaBloqueado:{6}, Fecha Fin Bloqueo:{7}, Fecha Alta Usuario: {8}, Fecha Baja Usuario: {9}]", dni_usuario
                                                                                                                                                                                                            , nombre_usuario
                                                                                                                                                                                                            , apellidos_usuario
                                                                                                                                                                                                            , tlf_usuario
                                                                                                                                                                                                            , email_usuario
                                                                                                                                                                                                            , clave_usuario
                                                                                                                                                                                                            , estaBloqueado_usuario
                                                                                                                                                                                                            , fch_fin_bloqueo_usuario
                                                                                                                                                                                                            , fch_alta_usuario
                                                                                                                                                                                                            , fch_baja_usuario);
        }
    }


    public class Acceso
    {
        // Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id_acceso { get; set; }
        public string? codigo_acceso { get; set; }
        public string? descripcion_acceso { get; set; }

        // Collection
        public ICollection<Usuario>? Usuarios { get;}

        // Constructor

        public Acceso(string codigo_acceso, string? descripcion_acceso)
        {
            this.codigo_acceso = codigo_acceso;
            this.descripcion_acceso = descripcion_acceso;
        }
    }
}