using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore3_TableSplitting.Modelos
{
    public class Estudiante
    {
        int Id { get; set; }
        public string Nombre { get; set; }
        public EstudianteDetalle Detalles { get; set; }

    }   //*
}
