namespace Domain.Entities
{
    public class Auditoria
    {
        public int id { get; set; }
        public int usuario_id {get; set;}
        public string accion{get; set;}
        public string tabla_afectada{get; set;}
        public int registro_id{get; set;}
        public string descripcion{get; set;}
        public DateTime fecha{get; set;}
        public string ip{get;set;}
        public string user_agent{get;set;}  
        public string username {get; set;}
        public string rol {get; set;}
    }
}