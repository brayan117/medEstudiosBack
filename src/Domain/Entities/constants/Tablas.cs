namespace Domain.Entities.Constants;

public static class Tablas
{
    // 1. USUARIOS Y SEGURIDAD
    public const string USUARIOS = "USUARIOS";
    public const string TIPOS_USUARIOS = "TIPOS_USUARIOS";
    public const string PERMISOS = "PERMISOS";
    public const string USUARIO_PERMISOS = "USUARIO_PERMISOS";

    // 2. ENTIDADES Y REGÍMENES
    public const string ENTIDADES = "ENTIDADES";
    public const string REGIMENES = "REGIMENES";

    // 3. PACIENTES
    public const string PACIENTES = "PACIENTES";

    // 4. MÉDICOS Y ESPECIALIDADES
    public const string ESPECIALIDADES = "ESPECIALIDADES";
    public const string MEDICOS = "MEDICOS";

    // 5. TÉCNICOS DE RADIOLOGÍA
    public const string TECNICOS = "TECNICOS";

    // 6. MODALIDADES Y TIPOS DE ESTUDIO
    public const string MODALIDADES = "MODALIDADES";
    public const string TIPOS_ESTUDIO = "TIPOS_ESTUDIO";

    // 7. ESTADOS DEL ESTUDIO
    public const string ESTADOS_ESTUDIO = "ESTADOS_ESTUDIO";

    // 8. ESTUDIOS PRINCIPAL
    public const string ESTUDIOS = "ESTUDIOS";

    // 9. AGENDA
    public const string AGENDA_ESTUDIOS = "AGENDA_ESTUDIOS";

    // 10. IMÁGENES DEL ESTUDIO
    public const string ESTUDIOS_IMAGENES = "ESTUDIOS_IMAGENES";

    // 11. RESULTADOS
    public const string RESULTADOS = "RESULTADOS";

    // 12. AUDITORÍA
    public const string AUDITORIA = "AUDITORIA";

    // 13. EQUIPOS MÉDICOS
    public const string EQUIPOS_MEDICOS = "EQUIPOS_MEDICOS";
    public const string ESTUDIO_EQUIPOS = "ESTUDIO_EQUIPOS";

    // 14. HISTORIAL DE CAMBIOS DE ESTADO
    public const string HISTORIAL_ESTADOS_ESTUDIO = "HISTORIAL_ESTADOS_ESTUDIO";
}