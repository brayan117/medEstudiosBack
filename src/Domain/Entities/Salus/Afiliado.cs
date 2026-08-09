namespace Domain.Entities.Salus{

    public class Afiliado
    {
        public int historia { get; set; }
        public string tipo_documento {get; set;}
        public string documento {get; set;}
        public string ape1 {get; set;}
        public string ape2 {get; set;}
        public string nom1 {get; set;}
        public string nom2 {get; set;}
        public DateTime fecha_nacimiento {get; set;}
        public string sexo {get; set;}  
        public string direccion {get; set;}
        public string celular {get; set;}
        public string mail {get; set;}
        public DateTime fecha_creacion {get; set;}  
        public string cod_municipio {get; set;}
        public string municipio {get; set;}
        public string cod_dpto {get; set;}
        public string departamento {get; set;}
        public string cod_eps {get; set;}
        public string regimen {get; set;}
        public string estado_paciente {get; set;}

    }
}
